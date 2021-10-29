using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class BeamsInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty WideBeamProperty;
        public static readonly DependencyProperty PlasmaBeamProperty;
        public static readonly DependencyProperty WaveBeamProperty;
        public static readonly DependencyProperty HyperBeamProperty;
        public static readonly DependencyProperty ChargeBeamProperty;
        public static readonly DependencyProperty DiffusionBeamProperty;
        public static readonly DependencyProperty GrappleBeamProperty;
        public static readonly DependencyProperty OmegaCannonProperty;
        public static readonly DependencyProperty IsOmegaStreamDisabledProperty;

        #endregion Dependency Properties

        #region Properties

        public bool WideBeam
        {
            get => (bool)GetValue(WideBeamProperty);
            set => SetValue(WideBeamProperty, value);
        }

        public bool PlasmaBeam
        {
            get => (bool)GetValue(PlasmaBeamProperty);
            set => SetValue(PlasmaBeamProperty, value);
        }

        public bool WaveBeam
        {
            get => (bool)GetValue(WaveBeamProperty);
            set => SetValue(WaveBeamProperty, value);
        }

        public bool HyperBeam
        {
            get => (bool)GetValue(HyperBeamProperty);
            set => SetValue(HyperBeamProperty, value);
        }

        public bool ChargeBeam
        {
            get => (bool)GetValue(ChargeBeamProperty);
            set => SetValue(ChargeBeamProperty, value);
        }

        public bool DiffusionBeam
        {
            get => (bool)GetValue(DiffusionBeamProperty);
            set => SetValue(DiffusionBeamProperty, value);
        }

        public bool GrappleBeam
        {
            get => (bool)GetValue(GrappleBeamProperty);
            set => SetValue(GrappleBeamProperty, value);
        }

        public bool OmegaCannon
        {
            get => (bool)GetValue(OmegaCannonProperty);
            set => SetValue(OmegaCannonProperty, value);
        }

        public bool IsOmegaStreamDisabled
        {
            get => (bool)GetValue(IsOmegaStreamDisabledProperty);
            set => SetValue(IsOmegaStreamDisabledProperty, value);
        }

        #endregion Properties

        #region Ctor

        static BeamsInventoryModel()
        {
            WideBeamProperty = RegisterTracked("WideBeam", typeof(bool), typeof(BeamsInventoryModel));
            PlasmaBeamProperty = RegisterTracked("PlasmaBeam", typeof(bool), typeof(BeamsInventoryModel));
            WaveBeamProperty = RegisterTracked("WaveBeam", typeof(bool), typeof(BeamsInventoryModel));
            HyperBeamProperty = RegisterTracked("HyperBeam", typeof(bool), typeof(BeamsInventoryModel));
            ChargeBeamProperty = RegisterTracked("ChargeBeam", typeof(bool), typeof(BeamsInventoryModel));
            DiffusionBeamProperty = RegisterTracked("DiffusionBeam", typeof(bool), typeof(BeamsInventoryModel));
            GrappleBeamProperty = RegisterTracked("GrappleBeam", typeof(bool), typeof(BeamsInventoryModel));
            OmegaCannonProperty = RegisterTracked("OmegaCannon", typeof(bool), typeof(BeamsInventoryModel));
            IsOmegaStreamDisabledProperty = RegisterTracked("IsOmegaStreamDisabled", typeof(bool), typeof(BeamsInventoryModel));
        }

        public BeamsInventoryModel()
        {

        }

        #endregion Ctor
    }
}
