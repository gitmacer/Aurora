using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using Aurora.Profiles;
using Newtonsoft.Json;
using Xceed.Wpf.Toolkit;

namespace Aurora.Settings.Overrides.Logic {

    /// <summary>
    /// Constant color that allows the user to select it from a color picker.
    /// </summary>
    [Evaluatable("Color (From picker)", category: OverrideLogicCategory.Logic)]
    public class ColorConstant : IEvaluatable<Color> {
        /// <summary>Creates a new constant color.</summary>
        public ColorConstant() { Color = Color.Red; }
        /// <summary>Creates a new constant color with the given color.</summary>
        public ColorConstant(Color color) { Color = color; }
        /// <summary>Creates a new constant color with the given RGBA values.</summary>
        public ColorConstant(int r, int b, int g, int a = 255) { Color = Color.FromArgb(a, r, g, b); }

        /// <summary>The value held by this constant value.</summary>
        public Color Color { get; set; }

        // Create a checkbox to use to set the constant value
        [JsonIgnore]
        private ColorPicker control;
        public System.Windows.Media.Visual GetControl(Application application) {
            if (control == null) {
                control = new ColorPicker { ColorMode = ColorMode.ColorCanvas };
                control.SetBinding(ColorPicker.SelectedColorProperty, new Binding("Color") { Source = this, Mode = BindingMode.TwoWay, Converter = new Utils.ColorConverter() });
            }
            return control;
        }

        // Simply return the current color
        public Color Evaluate(IGameState _) => Color;
        object IEvaluatable.Evaluate(IGameState gameState) => Evaluate(gameState);

        // Application-independent evaluatable, do nothing.
        public void SetApplication(Application application) { }

        // Creates a new ColorConstant
        public IEvaluatable<Color> Clone() => new ColorConstant { Color = Color };
        IEvaluatable IEvaluatable.Clone() => Clone();
    }


    [Evaluatable("Color (From values)", category: OverrideLogicCategory.Logic)]
    public class ColorFromValues : IEvaluatable<Color> {
        /// <summary>Creates a new color calculated from the default number evaluatables.</summary>
        public ColorFromValues() : this(new NumberConstant(255), new NumberConstant(0), new NumberConstant(0)) { }
        /// <summary>Creates a new color that is created from the result of the given RGB evaluatables.</summary>
        public ColorFromValues(IEvaluatable<double> r, IEvaluatable<double> g, IEvaluatable<double> b) : this(r, g, b, new NumberConstant(255)) { }
        /// <summary>Creates a new color that is created from the result of the given RGBA evaluatables.</summary>
        public ColorFromValues(IEvaluatable<double> r, IEvaluatable<double> g, IEvaluatable<double> b, IEvaluatable<double> a) { Red = r; Green = g; Blue = b; Alpha = a; }

        /// <summary>The amount of red that makes up this color.</summary>
        public IEvaluatable<double> Red { get; set; }
        /// <summary>The amount of green that makes up this color.</summary>
        public IEvaluatable<double> Green { get; set; }
        /// <summary>The amount of blue that makes up this color.</summary>
        public IEvaluatable<double> Blue { get; set; }
        /// <summary>The opacity of this color.</summary>
        public IEvaluatable<double> Alpha { get; set; }
        /// <summary>Whether to use a 0-255 scale (true) or a 0-1 scale (false)</summary>
        public bool Use255Scale { get; set; } = true;

        // Create a checkbox to use to set the constant value
        [JsonIgnore]
        private Control_ColorFromValues control;
        public System.Windows.Media.Visual GetControl(Application application) => control ?? (control = new Control_ColorFromValues(application, this));

        // Create the color and return it
        public Color Evaluate(IGameState gs) =>
            Color.FromArgb(
                GetColorComponent(Alpha.Evaluate(gs)),
                GetColorComponent(Red.Evaluate(gs)),
                GetColorComponent(Green.Evaluate(gs)),
                GetColorComponent(Blue.Evaluate(gs))
            );
        object IEvaluatable.Evaluate(IGameState gameState) => Evaluate(gameState);

        /// <summary>Returns a value between 0-255 based on the the given double and <see cref="Use255Scale"/>.</summary>
        private int GetColorComponent(double val) {
            // If using 0-1 scale, we need to multiply incoming by 255
            if (!Use255Scale) val *= 255;
            return Math.Min(255, Math.Max(0, (int)val));
        }

        // Propagate the application to the child evaluatables
        public void SetApplication(Application application) {
            Red?.SetApplication(application);
            Green?.SetApplication(application);
            Blue?.SetApplication(application);
            Alpha?.SetApplication(application);
            control?.SetApplication(application);
        }

        // Creates a new ColorFromValues
        public IEvaluatable<Color> Clone() => new ColorFromValues { Red = Red.Clone(), Green = Green.Clone(), Blue = Blue.Clone(), Alpha = Alpha.Clone() };
        IEvaluatable IEvaluatable.Clone() => Clone();
    }
}
