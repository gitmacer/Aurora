using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Profiles
{
    public interface IStringProperty
    {
        object GetValueFromString(string name, object input = null);
        void SetValueFromString(string name, object value);
        IStringProperty Clone();
    }

    public abstract class StringProperty<T> : IStringProperty
    {
        public static Dictionary<string, Member> PropertyLookup { get; set; } = null;
        public static object DictLock = new object();

        public StringProperty() {
            lock (DictLock) {
                if (PropertyLookup != null)
                    return;

                PropertyLookup = new Dictionary<string, Member>();
                var thisType = typeof(T);

                // For every member in the type extending this class
                foreach (var member in thisType.GetMembers()) {
                    ParameterExpression paramExpression = Expression.Parameter(thisType);

                    // Ignore anything not a field or property (methods, ctors, etc.)
                    if (member.MemberType != MemberTypes.Property && member.MemberType != MemberTypes.Field)
                        continue;

                    // Get the type represented by this member
                    var memberType = member.MemberType == MemberTypes.Property ? ((PropertyInfo)member).PropertyType : ((FieldInfo)member).FieldType;


                    // Create a getter lambda that will take an instance of type T and return the value of this member in that instance
                    var getter = Expression.Lambda<Func<T, object>>(
                        // Body
                        Expression.Convert(
                            Expression.PropertyOrField(paramExpression, member.Name),
                            typeof(object)
                        ),
                        // Params
                        paramExpression
                    ).Compile();


                    // Create a setter lambda that will take an instance of type T and a value and set the instance's member to value
                    Action<T, object> setter = null;
                    if (!(member.MemberType == MemberTypes.Property && ((PropertyInfo)member).SetMethod == null)) {
                        ParameterExpression objectTypeParam = Expression.Parameter(typeof(object));
                        MemberExpression propertyGetterExpression = Expression.PropertyOrField(paramExpression, member.Name);

                        setter = Expression.Lambda<Action<T, object>>(
                            // Body
                            Expression.Assign(
                                propertyGetterExpression,
                                Expression.ConvertChecked(objectTypeParam, memberType)
                            ),
                            // Params
                            paramExpression, objectTypeParam
                        ).Compile();
                    }

                    // Add this member to the property lookup dictionary. Now with named struct instead of nameless tuples :)
                    if (!PropertyLookup.ContainsKey(member.Name))
                        PropertyLookup.Add(member.Name, new Member {
                            get = getter,
                            set = setter,
                            memberType = memberType,
                            nonNullableMemberType = Utils.TypeUtils.GetNonNullableOf(memberType)
                        });
                }
            }
        }

        public object GetValueFromString(string name, object input = null) =>
            PropertyLookup.ContainsKey(name) ? PropertyLookup[name].get((T)(object)this) : null;

        public void SetValueFromString(string name, object value) {
            if (PropertyLookup.ContainsKey(name))
                // Convert the value to the right type, though if null is given, don't try to cast it
                PropertyLookup[name].set((T)(object)this, value == null ? null : Convert.ChangeType(value, PropertyLookup[name].nonNullableMemberType));
        }

        public IStringProperty Clone() => (IStringProperty)MemberwiseClone();


        /// <summary>
        /// Struct that holds pre-compiled delegates for getting/setting a particular property of by name.
        /// </summary>
        public struct Member {
            /// <summary>A function that when called and provided with an instance of T, returns the value of this member.</summary>
            public Func<T, object> get;

            /// <summary>An action that when called and provided with an instance of T and an object, will set the value of this member on T to the value.</summary>
            public Action<T, object> set;

            /// <summary>The type of member as it appears in the T definition.</summary>
            public Type memberType;

            /// <summary>The type of member, coerced to be non-nullable. If <see cref="memberType"/> is non-nullable, this will be the same.</summary>
            public Type nonNullableMemberType;
        }
    }
}
