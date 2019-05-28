using Aurora.Settings.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Aurora.Settings {
    /// <summary>
    /// Enum list for the percent effect type
    /// </summary>
    public enum PercentEffectType
    {
        /// <summary>
        /// All at once
        /// </summary>
        [Description("All at once")]
        AllAtOnce = 0,

        /// <summary>
        /// Progressive
        /// </summary>
        [Description("Progressive")]
        Progressive = 1,

        /// <summary>
        /// Progressive (Gradual)
        /// </summary>
        [Description("Progressive (Gradual)")]
        Progressive_Gradual = 2
    }

    public enum IdleEffects
    {
        [Description("None")]
        None = 0,
        [Description("Dim")]
        Dim = 1,
        [Description("Color Breathing")]
        ColorBreathing = 2,
        [Description("Rainbow Shift (Horizontal)")]
        RainbowShift_Horizontal = 3,
        [Description("Rainbow Shift (Vertical)")]
        RainbowShift_Vertical = 4,
        [Description("Star Fall")]
        StarFall = 5,
        [Description("Rain Fall")]
        RainFall = 6,
        [Description("Blackout")]
        Blackout = 7,
        [Description("Matrix")]
        Matrix = 8
    }

    /// <summary>
    /// Enum list for the layer effects
    /// </summary>
    public enum LayerEffects
    {
        /// <summary>
        /// None
        /// </summary>
        [Description("None")]
        None = 0,

        /// <summary>
        /// Single Color Overlay
        /// </summary>
        [Description("Single Color Overlay")]
        ColorOverlay = 1,

        /// <summary>
        /// Color Breathing
        /// </summary>
        [Description("Color Breathing")]
        ColorBreathing = 2,

        /// <summary>
        /// Rainbow Shift (Horizontal)
        /// </summary>
        [Description("Rainbow Shift (Horizontal)")]
        RainbowShift_Horizontal = 3,

        /// <summary>
        /// Rainbow Shift (Vertical)
        /// </summary>
        [Description("Rainbow Shift (Vertical)")]
        RainbowShift_Vertical = 4,

        /// <summary>
        /// Rainbow Shift (Diagonal)
        /// </summary>
        [Description("Rainbow Shift (Diagonal)")]
        RainbowShift_Diagonal = 5,

        /// <summary>
        /// Rainbow Shift (Other Diagonal)
        /// </summary>
        [Description("Rainbow Shift (Other Diagonal)")]
        RainbowShift_Diagonal_Other = 6,

        /// <summary>
        /// Rainbow Shift (Custom Angle)
        /// </summary>
        [Description("Rainbow Shift (Custom Angle)")]
        RainbowShift_Custom_Angle = 7,

        /// <summary>
        /// Gradient Shift (Custom Angle)
        /// </summary>
        [Description("Gradient Shift (Custom Angle)")]
        GradientShift_Custom_Angle = 8,
    }

    public enum AppExitMode
    {
        [LocalizedDescription("exit_mode.ask")]
        Ask = 0,
        [LocalizedDescription("exit_mode.minimize")]
        Minimize = 1,
        [LocalizedDescription("exit_mode.exit")]
        Exit = 2
    }

    public enum MouseOrientationType
    {
        [LocalizedDescription("mouse.right_handed")]
        RightHanded = 1,
        [LocalizedDescription("mouse.left_handed")]
        LeftHanded = 2
    }

    public enum PreferredKeyboard
    {
        [Description("None")]
        None = 0,

        [Description("Generic Laptop")]
        GenericLaptop = 1,

        [Description("Generic Laptop (Numpad)")]
        GenericLaptopNumpad = 2,
        /*
        [Description("Logitech")]
        Logitech = 1,
        [Description("Corsair")]
        Corsair = 2,
        [Description("Razer")]
        Razer = 3,
        
        [Description("Clevo")]
        Clevo = 4,
        [Description("Cooler Master")]
        CoolerMaster = 5,
        */

        //Logitech range is 100-199
        [Description("Logitech - G910")]
        Logitech_G910 = 100,
        [Description("Logitech - G410")]
        Logitech_G410 = 101,
        [Description("Logitech - G810")]
        Logitech_G810 = 102,
        [Description("Logitech - GPRO")]
        Logitech_GPRO = 103,
		[Description("Logitech - G213")]
        Logitech_G213 = 104,

        //Corsair range is 200-299
        [Description("Corsair - K95")]
        Corsair_K95 = 200,
        [Description("Corsair - K70")]
        Corsair_K70 = 201,
        [Description("Corsair - K65")]
        Corsair_K65 = 202,
        [Description("Corsair - STRAFE")]
        Corsair_STRAFE = 203,
        [Description("Corsair - K95 Platinum")]
        Corsair_K95_PL = 204,
        [Description("Corsair - K68")]
        Corsair_K68 = 205,
        [Description("Corsair - K70 MK2")]
        Corsair_K70MK2 = 206
            ,
        //Razer range is 300-399
        [Description("Razer - Blackwidow")]
        Razer_Blackwidow = 300,
        [Description("Razer - Blackwidow X")]
        Razer_Blackwidow_X = 301,
        [Description("Razer - Blackwidow Tournament Edition")]
        Razer_Blackwidow_TE = 302,
        [Description("Razer - Blade")]
        Razer_Blade = 303,

        //Clevo range is 400-499

        //Cooler Master range is 500-599
        [Description("Cooler Master - Masterkeys Pro L")]
        Masterkeys_Pro_L = 500,
        [Description("Cooler Master - Masterkeys Pro S")]
        Masterkeys_Pro_S = 501,
        [Description("Cooler Master - Masterkeys Pro M")]
        Masterkeys_Pro_M = 502,
        [Description("Cooler Master - Masterkeys MK750")]
        Masterkeys_MK750 = 503,

        //Roccat range is 600-699
        [Description("Roccat Ryos")]
        Roccat_Ryos = 600,

        //Steelseries range is 700-799
        [Description("SteelSeries Apex M800")]
        SteelSeries_Apex_M800 = 700,
        [Description("SteelSeries Apex M750")]
        SteelSeries_Apex_M750 = 701,
        [Description("SteelSeries Apex M750 TKL")]
        SteelSeries_Apex_M750_TKL = 702,

        [Description("Wooting One")]
        Wooting_One = 800,
        [Description("Wooting Two")]
        Wooting_Two = 801,

        [Description("Asus Strix Flare")]
        Asus_Strix_Flare = 900,

        //Drevo range is 1000-1099
        [Description("Drevo BladeMaster")]
        Drevo_BladeMaster = 1000,

	//Creative range is 1100-1199
        [Description("SoundBlasterX VanguardK08")]
        SoundBlasterX_Vanguard_K08 = 1100,
    }

    public enum PreferredKeyboardLocalization
    {
        [Description("Automatic Detection")]
        None = 0,
        [Description("International")]
        intl = 1,
        [Description("United States")]
        us = 2,
        [Description("United Kingdom")]
        uk = 3,
        [Description("Russian")]
        ru = 4,
        [Description("French")]
        fr = 5,
        [Description("Deutsch")]
        de = 6,
        [Description("Japanese")]
        jpn = 7,
        [Description("Turkish")]
        tr = 8,
        [Description("Nordic")]
        nordic = 9,
        [Description("Swiss")]
        swiss = 10,
        [Description("Portuguese (Brazilian ABNT2)")]
        abnt2 = 11,
        [Description("DVORAK (US)")]
        dvorak = 12,
        [Description("DVORAK (INT)")]
        dvorak_int = 13,
        [Description("Hungarian")]
        hu = 14,
        [Description("Italian")]
        it = 15
    }

    public enum PreferredMouse
    {
        [Description("None")]
        None = 0,

        [Description("Generic Peripheral")]
        Generic_Peripheral = 1,
        [Description("Razer/Corsair Mousepad + Mouse")]
        Generic_Mousepad = 2,

        //Logitech range is 100-199
        [Description("Logitech - G900")]
        Logitech_G900 = 100,
        [Description("Logitech - G502")]
        Logitech_G502 = 101,

        //Corsair range is 200-299
        [Description("Corsair - Sabre")]
        Corsair_Sabre = 200,
        [Description("Corsair - M65")]
        Corsair_M65 = 201,
        [Description("Corsair - Katar")]
        Corsair_Katar = 202,

        //Razer range is 300-399

        //Clevo range is 400-499
        [Description("Clevo - Touchpad")]
        Clevo_Touchpad = 400,

        //Cooler Master range is 500-599

        //Roccat range is 600-699

        //Steelseries range is 700-799
        [Description("SteelSeries - Rival 300")]
        SteelSeries_Rival_300 = 700,
        [Description("SteelSeries - Rival 300 HP OMEN Edition")]
        SteelSeries_Rival_300_HP_OMEN_Edition = 701,
        [Description("SteelSeries - QcK Prism Mousepad + Mouse")]
        SteelSeries_QcK_Prism = 702,
        [Description("SteelSeries - Two-zone QcK Mousepad + Mouse")]
        SteelSeries_QcK_2_Zone = 703,
        //Asus range is 900-999
        [Description("Asus - Pugio")]
        Asus_Pugio = 900
    }

    public enum KeycapType
    {
        [LocalizedDescription("default")]
        Default = 0,
        [LocalizedDescription("keycap.default_backglow")]
        Default_backglow = 1,
        [LocalizedDescription("keycap.default_backonly")]
        Default_backglow_only = 2,
        [LocalizedDescription("keycap.colorized")]
        Colorized = 3,
        [LocalizedDescription("keycap.colorized_blank")]
        Colorized_blank = 4
    }

    public enum ApplicationDetectionMode
    {
        [LocalizedDescription("app_detection.windows")]
        WindowsEvents = 0,

        [LocalizedDescription("app_detection.foreground")]
        ForegroroundApp = 1
    }

    public enum BitmapAccuracy
    {
        [LocalizedDescription("bitmap.best")]
        Best = 1,
        [LocalizedDescription("bitmap.great")]
        Great = 3,
        [LocalizedDescription("bitmap.good")]
        Good = 6,
        [LocalizedDescription("bitmap.okay")]
        Okay = 9,
        [LocalizedDescription("bitmap.fine")]
        Fine = 12
    }

    public class ConfigManager
    {
        private static string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aurora", "Config");
        private const string ConfigExtension = ".json";

        private static long _last_save_time = 0L;
        private readonly static long _save_interval = 300L;

        public static Configuration Load()
        {
            var configPath = ConfigPath + ConfigExtension;

            if (!File.Exists(configPath))
                return CreateDefaultConfigurationFile();

            string content = File.ReadAllText(configPath, Encoding.UTF8);

            if (String.IsNullOrWhiteSpace(content))
                return CreateDefaultConfigurationFile();

            Configuration config = JsonConvert.DeserializeObject<Configuration>(content, new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace, TypeNameHandling = TypeNameHandling.All, SerializationBinder = Aurora.Utils.JSONUtils.SerializationBinder, Error = DeserializeErrorHandler });

            if (!config.UnifiedHidDisabled)
            {
                config.DevicesDisabled.Add(typeof(Devices.UnifiedHID.UnifiedHIDDevice));
                config.UnifiedHidDisabled = true;
            }

            return config;
        }

        private static void DeserializeErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            if (e.ErrorContext.Error.Message.Contains("Aurora.Devices.SteelSeriesHID.SteelSeriesHIDDevice") && e.CurrentObject is HashSet<Type> dd)
            {
                dd.Add(typeof(Aurora.Devices.UnifiedHID.UnifiedHIDDevice));
                e.ErrorContext.Handled = true;
            }
        }

        public static void Save(Configuration configuration)
        {
            long current_time = Utils.Time.GetMillisecondsSinceEpoch();

            if (_last_save_time + _save_interval > current_time)
                return;
            else
                _last_save_time = current_time;

            var configPath = ConfigPath + ConfigExtension;
            string content = JsonConvert.SerializeObject(configuration, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Binder = Aurora.Utils.JSONUtils.SerializationBinder });

            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(configPath));
            File.WriteAllText(configPath, content, Encoding.UTF8);
        }

        private static Configuration CreateDefaultConfigurationFile()
        {
            Configuration config = new Configuration();
            var configData = JsonConvert.SerializeObject(config, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Binder = Aurora.Utils.JSONUtils.SerializationBinder });
            var configPath = ConfigPath + ConfigExtension;

            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(configPath));
            File.WriteAllText(configPath, configData, Encoding.UTF8);

            return config;
        }
    }
}