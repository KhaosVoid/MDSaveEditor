using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class AeionAbilitiesInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty PhantomCloakProperty;
        public static readonly DependencyProperty FlashShiftProperty;
        public static readonly DependencyProperty PulseRadarProperty;

        #endregion Dependency Properties

        #region Properties

        public bool PhantomCloak
        {
            get => (bool)GetValue(PhantomCloakProperty);
            set => SetValue(PhantomCloakProperty, value);
        }

        public bool FlashShift
        {
            get => (bool)GetValue(FlashShiftProperty);
            set => SetValue(FlashShiftProperty, value);
        }

        public bool PulseRadar
        {
            get => (bool)GetValue(PulseRadarProperty);
            set => SetValue(PulseRadarProperty, value);
        }

        #endregion Properties

        #region Ctor

        static AeionAbilitiesInventoryModel()
        {
            PhantomCloakProperty = RegisterTracked("PhantomCloak", typeof(bool), typeof(AeionAbilitiesInventoryModel));
            FlashShiftProperty = RegisterTracked("FlashShift", typeof(bool), typeof(AeionAbilitiesInventoryModel));
            PulseRadarProperty = RegisterTracked("PulseRadar", typeof(bool), typeof(AeionAbilitiesInventoryModel));
        }

        public AeionAbilitiesInventoryModel()
        {

        }

        #endregion Ctor
    }
}
