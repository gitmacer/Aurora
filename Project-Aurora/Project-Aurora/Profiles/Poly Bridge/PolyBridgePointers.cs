namespace Aurora.Profiles.PolyBridge
{
    public class PointerData
    {
        public int baseAddress { get; set; }
        public int[] pointers { get; set; }
    }

    public class PolyBridgePointers
    {
        //public PointerData ManaPots;
        //public PointerData HealthPots;
        public PointerData Load;
        //public PointerData Budget;
        public PointerData Cost;
        public PointerData Budget;
    }
}