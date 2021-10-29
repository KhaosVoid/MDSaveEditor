using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class SuitsInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty VariaSuitProperty;
        public static readonly DependencyProperty GravitySuitProperty;
        public static readonly DependencyProperty MetroidSuitProperty;

        #endregion Dependency Properties

        #region Properties

        public bool VariaSuit
        {
            get => (bool)GetValue(VariaSuitProperty);
            set => SetValue(VariaSuitProperty, value);
        }

        public bool GravitySuit
        {
            get => (bool)GetValue(GravitySuitProperty);
            set => SetValue(GravitySuitProperty, value);
        }

        public bool MetroidSuit
        {
            get => (bool)GetValue(MetroidSuitProperty);
            set => SetValue(MetroidSuitProperty, value);
        }

        #endregion Properties

        #region Ctor

        static SuitsInventoryModel()
        {
            VariaSuitProperty = RegisterTracked("VariaSuit", typeof(bool), typeof(SuitsInventoryModel));
            GravitySuitProperty = RegisterTracked("GravitySuit", typeof(bool), typeof(SuitsInventoryModel));
            MetroidSuitProperty = RegisterTracked("MetroidSuit", typeof(bool), typeof(SuitsInventoryModel));
        }

        public SuitsInventoryModel()
        {

        }

        #endregion Ctor
    }
}
