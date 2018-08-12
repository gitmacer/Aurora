using System;
using Aurora.EffectsEngine;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using Aurora.Utils;
using System.Drawing.Drawing2D;
using Aurora.Settings;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Aurora.Profiles.PolyBridge.GSI;
using Aurora.Profiles.PolyBridge.GSI.Nodes;

namespace Aurora.Profiles.PolyBridge
{
    public class GameEvent_PolyBridge : LightEvent
    {
        private bool isInitialized = false;

        //Pointers
        private PolyBridgePointers pointers;

        public GameEvent_PolyBridge() : base()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = System.IO.Path.Combine(Global.ExecutingDirectory, "Pointers");
            watcher.Changed += DHPointers_Changed;
            watcher.EnableRaisingEvents = true;

            ReloadPointers();
        }

        private void DHPointers_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Equals("PolyBridge.json") && e.ChangeType == WatcherChangeTypes.Changed)
                ReloadPointers();
        }

        private void ReloadPointers()
        {
            string path = System.IO.Path.Combine(Global.ExecutingDirectory, "Pointers", "PolyBridge.json");
            
            if (File.Exists(path))
            {
                try
                {
                    // deserialize JSON directly from a file
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var sr = new StreamReader(fs, System.Text.Encoding.Default))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        pointers = (PolyBridgePointers)serializer.Deserialize(sr, typeof(PolyBridgePointers));
                    }
                }
                catch (Exception exc)
                {
                    Global.logger.Error(exc.Message);
                    isInitialized = false;
                }

                isInitialized = true;
            }
            else
            {
                isInitialized = false;
            }
        }

        public override void ResetGameState()
        {
            _game_state = new GameState_PolyBridge();
        }

        public new bool IsEnabled
        {
            get { return this.Application.Settings.IsEnabled && isInitialized; }
        }

        public override void UpdateLights(EffectFrame frame)
        {

            Queue<EffectLayer> layers = new Queue<EffectLayer>();

            PolyBridgeProfile settings = (PolyBridgeProfile)this.Application.Profile;

            Process[] process_search = Process.GetProcessesByName("PolyBridge");

            if (process_search.Length != 0)
            {
                using (MemoryReader memread = new MemoryReader(process_search[0]))
                {
                    (_game_state as GameState_PolyBridge).Player.Load = memread.ReadFloat(pointers.Load.baseAddress, pointers.Load.pointers) * 100;
                    Global.logger.Info("Load: " + memread.ReadFloat(pointers.Load.baseAddress, pointers.Load.pointers) * 100);

                    int budget = memread.ReadInt(pointers.Budget.baseAddress, pointers.Budget.pointers);
                    int cost = memread.ReadInt(pointers.Cost.baseAddress, pointers.Cost.pointers);
                    if (budget == 0)
                        cost = -1;

                    (_game_state as GameState_PolyBridge).Player.Budget = budget;
                        Global.logger.Info("Budget: " + budget);
                    (_game_state as GameState_PolyBridge).Player.MaximumCost = budget + (budget / 2);
                    (_game_state as GameState_PolyBridge).Player.OverBudget = cost - budget;

                    (_game_state as GameState_PolyBridge).Player.MaximumOverBudget = (budget + (budget / 2) - budget);
                    //Global.logger.Info("Max over budget: " + ((budget + (budget / 2)) - budget));


                    (_game_state as GameState_PolyBridge).Player.Cost = cost;
                    Global.logger.Info("Cost: " + cost);


                    //(_game_state as GameState_PolyBridge).Player.ManaPots = memread.ReadInt(pointers.ManaPots.baseAddress, pointers.ManaPots.pointers);
                    //(_game_state as GameState_PolyBridge).Player.HealthPots = memread.ReadInt(pointers.HealthPots.baseAddress, pointers.HealthPots.pointers);
                }
            }
            foreach (var layer in this.Application.Profile.Layers.Reverse().ToArray())
            {
                if (layer.Enabled && layer.LogicPass)
                    layers.Enqueue(layer.Render(_game_state));
            }

            //Scripts
            this.Application.UpdateEffectScripts(layers);

            frame.AddLayers(layers.ToArray());
        }

        public override void SetGameState(IGameState new_game_state)
        {
            //UpdateLights(frame);
        }
    }
}
