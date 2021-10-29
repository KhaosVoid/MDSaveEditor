using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class CollectablesInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty TotalLifeShardsProperty;
        public static readonly DependencyProperty EnergyTanksProperty;
        public static readonly DependencyProperty MissileTanksProperty;
        public static readonly DependencyProperty MissilePlusTanksProperty;
        public static readonly DependencyProperty PowerBombTanksProperty;

        #endregion Dependency Properties

        #region Properties

        public int TotalLifeShards
        {
            get => (int)GetValue(TotalLifeShardsProperty);
            set => SetValue(TotalLifeShardsProperty, value);
        }

        public int EnergyTanks
        {
            get => (int)GetValue(EnergyTanksProperty);
            set => SetValue(EnergyTanksProperty, value);
        }

        public int MissileTanks
        {
            get => (int)GetValue(MissileTanksProperty);
            set => SetValue(MissileTanksProperty, value);
        }
        public int MissilePlusTanks
        {
            get => (int)GetValue(MissilePlusTanksProperty);
            set => SetValue(MissilePlusTanksProperty, value);
        }

        public int PowerBombTanks
        {
            get => (int)GetValue(PowerBombTanksProperty);
            set => SetValue(PowerBombTanksProperty, value);
        }

        #endregion Properties

        #region Ctor

        static CollectablesInventoryModel()
        {
            TotalLifeShardsProperty = RegisterTracked("TotalLifeShards", typeof(int), typeof(CollectablesInventoryModel));
            EnergyTanksProperty = RegisterTracked("EnergyTanks", typeof(int), typeof(CollectablesInventoryModel));
            MissileTanksProperty = RegisterTracked("MissileTanks", typeof(int), typeof(CollectablesInventoryModel));
            MissilePlusTanksProperty = RegisterTracked("MissilePlusTanks", typeof(int), typeof(CollectablesInventoryModel));
            PowerBombTanksProperty = RegisterTracked("PowerBombTanks", typeof(int), typeof(CollectablesInventoryModel));
        }

        public CollectablesInventoryModel()
        {

        }

        #endregion Ctor
    }
}
