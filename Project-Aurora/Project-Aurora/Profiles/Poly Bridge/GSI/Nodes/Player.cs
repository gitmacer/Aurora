namespace Aurora.Profiles.PolyBridge.GSI.Nodes
{
    /// <summary>
    /// Class representing player information
    /// </summary>
    public class Player_PolyBridge : Node<Player_PolyBridge>
    {
        /// <summary>
        /// Player's boost amount [0.0f, 1.0f]
        /// </summary>
        public float Load = 0;
        public int Cost = 0;
        public int Budget = 0;
        public int OverBudget = 0;
        public int MaximumCost = 0;
        public int MaximumOverBudget = 0;

        internal Player_PolyBridge(string json_data) : base(json_data)
        {

        }
    }
}
