using Aurora.Controls;
using Aurora.Profiles.PolyBridge.GSI;
using Aurora.Profiles.PolyBridge.GSI.Nodes;
using Aurora.Settings;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace Aurora.Profiles.PolyBridge
{
    /// <summary>
    /// Interaction logic for Control_PolyBridge.xaml
    /// </summary>
    public partial class Control_PolyBridge : UserControl
    {
        private Application profile_manager;

        public Control_PolyBridge(Application profile)
        {
            InitializeComponent();

            profile_manager = profile;

            SetSettings();

            profile_manager.ProfileChanged += Profile_manager_ProfileChanged;
        }

        private void Profile_manager_ProfileChanged(object sender, EventArgs e)
        {
            SetSettings();
        }

        private void SetSettings()
        {
            this.game_enabled.IsChecked = profile_manager.Settings.IsEnabled;
        }

        private void game_enabled_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                profile_manager.Settings.IsEnabled = (this.game_enabled.IsChecked.HasValue) ? this.game_enabled.IsChecked.Value : false;
                profile_manager.SaveProfiles();
            }
        }
        private void preview_Load_amount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider)
            {
                this.preview_Load_amount_label.Text = (int)((sender as Slider).Value) + "%";

                if (IsLoaded)
                {
                    (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.Load = (int)((sender as Slider).Value);
                }
            }
        }

        private void preview_Cost_amount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider)
            {
                this.preview_Cost_amount_label.Text = (int)((sender as Slider).Value) + "%";

                if (IsLoaded)
                {
                    int cost = (int)((sender as Slider).Value);
                    int budget = 100;
                    (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.Cost = cost;
                    (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.Budget = budget;
                    (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.MaximumOverBudget = (budget + (budget / 2)) - budget;
                    (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.OverBudget = cost - budget;
                    (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.MaximumCost = budget + (budget / 2);
                    Global.logger.Info("Max over budget: " + ((budget + (budget / 2)) - budget));
                    Global.logger.Info("over budget: " + (cost - budget));
                }
            }
        }

        /*private void preview_manapots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsLoaded && sender is IntegerUpDown && (sender as IntegerUpDown).Value.HasValue)
                (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.ManaPots = (sender as IntegerUpDown).Value.Value;
        }

        private void preview_healthpots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsLoaded && sender is IntegerUpDown && (sender as IntegerUpDown).Value.HasValue)
                (profile_manager.Config.Event._game_state as GameState_PolyBridge).Player.HealthPots = (sender as IntegerUpDown).Value.Value;
        }*/
    }
}
