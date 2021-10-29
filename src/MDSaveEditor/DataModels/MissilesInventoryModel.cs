using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class MissilesInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty SuperMissileProperty;
        public static readonly DependencyProperty IceMissileProperty;
        public static readonly DependencyProperty StormMissilesProperty;

        #endregion Dependency Properties

        #region Properties

        public bool SuperMissile
        {
            get => (bool)GetValue(SuperMissileProperty);
            set => SetValue(SuperMissileProperty, value);
        }

        public bool IceMissile
        {
            get => (bool)GetValue(IceMissileProperty);
            set => SetValue(IceMissileProperty, value);
        }

        public bool StormMissiles
        {
            get => (bool)GetValue(StormMissilesProperty);
            set => SetValue(StormMissilesProperty, value);
        }

        #endregion Properties

        #region Ctor

        static MissilesInventoryModel()
        {
            SuperMissileProperty = RegisterTracked("SuperMissile", typeof(bool), typeof(MissilesInventoryModel));
            IceMissileProperty = RegisterTracked("IceMissile", typeof(bool), typeof(MissilesInventoryModel));
            StormMissilesProperty = RegisterTracked("StormMissiles", typeof(bool), typeof(MissilesInventoryModel));
        }

        public MissilesInventoryModel()
        {

        }

        #endregion Ctor
    }
}
