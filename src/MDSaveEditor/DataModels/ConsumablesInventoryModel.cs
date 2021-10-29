using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class ConsumablesInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty MaxEnergyProperty;
        public static readonly DependencyProperty CurrentEnergyProperty;
        public static readonly DependencyProperty LifeShardsProperty;
        public static readonly DependencyProperty EnergyTankShardsProperty;
        public static readonly DependencyProperty MaxAeionEnergyProperty;
        public static readonly DependencyProperty CurrentAeionEnergyProperty;
        public static readonly DependencyProperty MaxMissilesProperty;
        public static readonly DependencyProperty CurrentMissilesProperty;
        public static readonly DependencyProperty MaxPowerBombsProperty;
        public static readonly DependencyProperty CurrentPowerBombsProperty;

        #endregion Dependency Properties

        #region Properties

        public int MaxEnergy
        {
            get => (int)GetValue(MaxEnergyProperty);
            set => SetValue(MaxEnergyProperty, value);
        }

        public int CurrentEnergy
        {
            get => (int)GetValue(CurrentEnergyProperty);
            set => SetValue(CurrentEnergyProperty, value);
        }

        public int LifeShards
        {
            get => (int)GetValue(LifeShardsProperty);
            set => SetValue(LifeShardsProperty, value);
        }

        public int EnergyTankShards
        {
            get => (int)GetValue(EnergyTankShardsProperty);
            set => SetValue(EnergyTankShardsProperty, value);
        }

        public int MaxAeionEnergy
        {
            get => (int)GetValue(MaxAeionEnergyProperty);
            set => SetValue(MaxAeionEnergyProperty, value);
        }

        public int CurrentAeionEnergy
        {
            get => (int)GetValue(CurrentAeionEnergyProperty);
            set => SetValue(CurrentAeionEnergyProperty, value);
        }

        public int MaxMissiles
        {
            get => (int)GetValue(MaxMissilesProperty);
            set => SetValue(MaxMissilesProperty, value);
        }

        public int CurrentMissiles
        {
            get => (int)GetValue(CurrentMissilesProperty);
            set => SetValue(CurrentMissilesProperty, value);
        }

        public int MaxPowerBombs
        {
            get => (int)GetValue(MaxPowerBombsProperty);
            set => SetValue(MaxPowerBombsProperty, value);
        }

        public int CurrentPowerBombs
        {
            get => (int)GetValue(CurrentPowerBombsProperty);
            set => SetValue(CurrentPowerBombsProperty, value);
        }

        #endregion Properties

        #region Ctor

        static ConsumablesInventoryModel()
        {
            MaxEnergyProperty = RegisterTracked("MaxEnergy", typeof(int), typeof(ConsumablesInventoryModel));
            CurrentEnergyProperty = RegisterTracked("CurrentEnergy", typeof(int), typeof(ConsumablesInventoryModel));
            LifeShardsProperty = RegisterTracked("LifeShards", typeof(int), typeof(ConsumablesInventoryModel));
            EnergyTankShardsProperty = RegisterTracked("EnergyTankShards", typeof(int), typeof(ConsumablesInventoryModel));
            MaxAeionEnergyProperty = RegisterTracked("MaxAeionEnergy", typeof(int), typeof(ConsumablesInventoryModel));
            CurrentAeionEnergyProperty = RegisterTracked("CurrentAeionEnergy", typeof(int), typeof(ConsumablesInventoryModel));
            MaxMissilesProperty = RegisterTracked("MaxMissiles", typeof(int), typeof(ConsumablesInventoryModel));
            CurrentMissilesProperty = RegisterTracked("CurrentMissiles", typeof(int), typeof(ConsumablesInventoryModel));
            MaxPowerBombsProperty = RegisterTracked("MaxPowerBombs", typeof(int), typeof(ConsumablesInventoryModel));
            CurrentPowerBombsProperty = RegisterTracked("CurrentPowerBombs", typeof(int), typeof(ConsumablesInventoryModel));
        }

        public ConsumablesInventoryModel()
        {

        }

        #endregion Ctor
    }
}
