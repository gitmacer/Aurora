using Aurora.Profiles.PolyBridge.GSI.Nodes;
using System;

namespace Aurora.Profiles.PolyBridge.GSI
{
    /// <summary>
    /// A class representing various information relating to PolyBridge
    /// </summary>
    public class GameState_PolyBridge : GameState<GameState_PolyBridge>
    {
        private Player_PolyBridge player;

        /// <summary>
        /// Information about the local player
        /// </summary>
        public Player_PolyBridge Player
        {
            get
            {
                if (player == null)
                    player = new Player_PolyBridge("");

                return player;
            }
        }

        /// <summary>
        /// Creates a default GameState_Dishonored instance.
        /// </summary>
        public GameState_PolyBridge() : base()
        {
        }

        /// <summary>
        /// Creates a GameState instance based on the passed json data.
        /// </summary>
        /// <param name="json_data">The passed json data</param>
        public GameState_PolyBridge(string json_data) : base(json_data)
        {
        }

        /// <summary>
        /// A copy constructor, creates a GameState_Dishonored instance based on the data from the passed GameState instance.
        /// </summary>
        /// <param name="other_state">The passed GameState</param>
        public GameState_PolyBridge(IGameState other_state) : base(other_state)
        {
        }
    }
}
