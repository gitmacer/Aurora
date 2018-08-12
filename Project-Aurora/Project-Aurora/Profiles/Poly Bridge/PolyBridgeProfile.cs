using Aurora.EffectsEngine;
using Aurora.Settings;
using Aurora.Settings.Layers;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Aurora.Profiles.PolyBridge
{
    public class PolyBridgeProfile : ApplicationProfile
    {
        public PolyBridgeProfile() : base()
        {
            
        }

        public override void Reset()
        {
            base.Reset();
            Layers = new System.Collections.ObjectModel.ObservableCollection<Layer>()
            {
                new Layer("Over Budget Indicator", new PercentLayerHandler()
                {
                    Properties = new PercentLayerHandlerProperties()
                    {
                        _PercentType = PercentEffectType.Progressive_Gradual,
                        _BlinkThreshold = 0.0,
                        _BlinkDirection = false,
                        _VariablePath = "Player/OverBudget",
                       _MaxVariablePath = "Player/MaximumOverBudget",
                        _SecondaryColor = Color.Transparent,
                        _PrimaryColor = Color.Red,
                        _Sequence = new KeySequence(new Devices.DeviceKeys[] {
                            Devices.DeviceKeys.ONE, Devices.DeviceKeys.TWO, Devices.DeviceKeys.THREE, Devices.DeviceKeys.FOUR, Devices.DeviceKeys.FIVE,
                            Devices.DeviceKeys.SIX, Devices.DeviceKeys.SEVEN, Devices.DeviceKeys.EIGHT, Devices.DeviceKeys.NINE, Devices.DeviceKeys.ZERO,
                            Devices.DeviceKeys.MINUS, Devices.DeviceKeys.EQUALS
                        })
                    },
                }),

                new Layer("Cost Indicator", new PercentLayerHandler()
                {
                    Properties = new PercentLayerHandlerProperties()
                    {
                        _PercentType = PercentEffectType.Progressive_Gradual,
                        _BlinkThreshold = 0.0,
                        _BlinkDirection = false,
                        _VariablePath = "Player/Cost",
                        _MaxVariablePath = "Player/Budget",
                        _SecondaryColor = Color.FromArgb(255,0,70,0),
                        _PrimaryColor =  Color.FromArgb(0, 255, 0),
                        _Sequence = new KeySequence(new Devices.DeviceKeys[] {
                            Devices.DeviceKeys.ONE, Devices.DeviceKeys.TWO, Devices.DeviceKeys.THREE, Devices.DeviceKeys.FOUR, Devices.DeviceKeys.FIVE,
                            Devices.DeviceKeys.SIX, Devices.DeviceKeys.SEVEN, Devices.DeviceKeys.EIGHT, Devices.DeviceKeys.NINE, Devices.DeviceKeys.ZERO,
                            Devices.DeviceKeys.MINUS, Devices.DeviceKeys.EQUALS
                        })
                    },
                }),

                new Layer("Load Indicator", new PercentLayerHandler()
                {
                    Properties = new PercentLayerHandlerProperties()
                    {
                        _PercentType = PercentEffectType.Progressive_Gradual,
                        _BlinkThreshold = 0.0,
                        _BlinkDirection = false,
                        _VariablePath = "Player/Load",
                        _MaxVariablePath = "100",
                        _SecondaryColor = Color.Green,
                        _PrimaryColor = Color.Red,
                        _Sequence = new KeySequence(new Devices.DeviceKeys[] {
                            Devices.DeviceKeys.Q, Devices.DeviceKeys.W, Devices.DeviceKeys.E, Devices.DeviceKeys.R, Devices.DeviceKeys.T,
                            Devices.DeviceKeys.Y, Devices.DeviceKeys.U, Devices.DeviceKeys.I, Devices.DeviceKeys.O, Devices.DeviceKeys.P,
                            Devices.DeviceKeys.OPEN_BRACKET
                        })
                    },
                }),

                new Layer("Mouse Load Indicator", new PercentLayerHandler()
                {
                    Properties = new PercentLayerHandlerProperties()
                    {
                        _PercentType = PercentEffectType.AllAtOnce,
                        _BlinkThreshold = 0.0,
                        _BlinkDirection = false,
                        _VariablePath = "Player/Load",
                        _MaxVariablePath = "100",
                        _SecondaryColor = Color.Green,
                        _PrimaryColor = Color.Red,
                        _Sequence = new KeySequence(new Devices.DeviceKeys[] {
                            Devices.DeviceKeys.Peripheral_Logo
                        })
                    },
                }),

                new Layer("Background", new SolidFillLayerHandler(){
                    Properties = new SolidFillLayerHandlerProperties()
                    {
                        _PrimaryColor = Color.Gray
                    }
                })
            };
        }
    }
}
