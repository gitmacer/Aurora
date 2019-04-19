using Aurora.Settings;
using Aurora.Utils;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Aurora.Profiles.SIG
{
    public class SIG : Application
    {
        public SIG()
            : base(new LightEventConfig { Name = "Super Inefficient Golf", ID = "SIG", ProcessNames = new[] { "stickysnowball-Win64-Shipping.exe" }, ProfileType = typeof(SIGProfile), OverviewControlType = typeof(Control_SIG), GameStateType = typeof(GameState_Wrapper), Event = new GameEvent_Generic(), IconURI = "Resources/SIG.png" })
        {
            Config.ExtraAvailableLayers.Add("WrapperLights");
            binder = new SIGSerializationBinder();
        }
    }

    public class SIGSerializationBinder : AuroraSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (typeName == "Aurora.Profiles.WrapperProfile")
                return typeof(SIGProfile);

            return base.BindToType(assemblyName, typeName);
        }
    }
}
