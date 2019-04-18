using Aurora.Profiles;
using Newtonsoft.Json;
using System.Windows.Data;

namespace Aurora.Settings.Overrides.Logic {

    /// <summary>
    /// A constant KeySequence value that allows the user to select with a control.
    /// </summary>
    [Evaluatable("Key Sequence (From picker)", category: OverrideLogicCategory.Logic)]
    public class KeySequenceConstant : IEvaluatable<KeySequence> {

        public KeySequence Sequence { get; set; }

        /// <summary>Creates a new KeySequence constant with an empty sequence.</summary>
        public KeySequenceConstant() { Sequence = new KeySequence(); }

        /// <summary>Creates a new KeySequence constant with the given sequence.</summary>
        public KeySequenceConstant(KeySequence sequence) { Sequence = sequence; }

        [JsonIgnore]
        private Controls.KeySequence control;
        public System.Windows.Media.Visual GetControl(Application application) {
            if (control == null) {
                control = new Controls.KeySequence { RecordingTag = "Key Sequence Constant", Title = "Key Sequence Constant" };
                control.SetBinding(Controls.KeySequence.SequenceProperty, new Binding("Sequence") { Source = this, Mode = BindingMode.TwoWay });
            }
            return control;
        }

        /// <summary>Evaluate conditions and return the appropriate evaluation.</summary>
        public KeySequence Evaluate(IGameState gameState) => Sequence;

        object IEvaluatable.Evaluate(IGameState gameState) => Evaluate(gameState);

        /// <summary>Application-independent </summary>
        public void SetApplication(Application application) { }

        /// <summary>Clones this KeySequenceConstant.</summary>
        public IEvaluatable<KeySequence> Clone() => new KeySequenceConstant((KeySequence)Sequence.Clone());
        IEvaluatable IEvaluatable.Clone() => Clone();
    }
}
