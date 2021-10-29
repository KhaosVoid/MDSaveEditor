using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class MorphBallAbilitiesInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty MorphBallProperty;
        public static readonly DependencyProperty MorphBallBombProperty;
        public static readonly DependencyProperty MorphBallLineBombProperty;
        public static readonly DependencyProperty PowerBombProperty;

        #endregion Dependency Properties

        #region Properties

        public bool MorphBall
        {
            get => (bool)GetValue(MorphBallProperty);
            set => SetValue(MorphBallProperty, value);
        }

        public bool MorphBallBomb
        {
            get => (bool)GetValue(MorphBallBombProperty);
            set => SetValue(MorphBallBombProperty, value);
        }

        public bool MorphBallLineBomb
        {
            get => (bool)GetValue(MorphBallLineBombProperty);
            set => SetValue(MorphBallLineBombProperty, value);
        }

        public bool PowerBomb
        {
            get => (bool)GetValue(PowerBombProperty);
            set => SetValue(PowerBombProperty, value);
        }

        #endregion Properties

        #region Ctor

        static MorphBallAbilitiesInventoryModel()
        {
            MorphBallProperty = RegisterTracked("MorphBall", typeof(bool), typeof(MorphBallAbilitiesInventoryModel));
            MorphBallBombProperty = RegisterTracked("MorphBallBomb", typeof(bool), typeof(MorphBallAbilitiesInventoryModel));
            MorphBallLineBombProperty = RegisterTracked("MorphBallLineBomb", typeof(bool), typeof(MorphBallAbilitiesInventoryModel));
            PowerBombProperty = RegisterTracked("PowerBomb", typeof(bool), typeof(MorphBallAbilitiesInventoryModel));
        }

        public MorphBallAbilitiesInventoryModel()
        {

        }

        #endregion Ctor
    }
}
