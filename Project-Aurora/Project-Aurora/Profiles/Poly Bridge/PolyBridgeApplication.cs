using Aurora.Profiles.PolyBridge.GSI;
using Aurora.Settings;
using Aurora.Settings.Layers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Aurora.Profiles.PolyBridge
{
    public class PolyBridge : Application
    {
        public PolyBridge()
            : base(new LightEventConfig { Name = "PolyBridge", ID = "PolyBridge", ProcessNames = new[] { "polybridge.exe" }, ProfileType = typeof(PolyBridgeProfile), OverviewControlType = typeof(Control_PolyBridge), GameStateType = typeof(GameState_PolyBridge), Event = new GameEvent_PolyBridge(), IconURI = "Resources/PolyBridge.png" })
        {
        }
    }
}
