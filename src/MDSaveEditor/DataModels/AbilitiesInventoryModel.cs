using Excalibur.Wpf.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class AbilitiesInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty FloorSlideProperty;
        public static readonly DependencyProperty SpiderMagnetProperty;
        public static readonly DependencyProperty SpeedBoosterProperty;
        public static readonly DependencyProperty SpinBoostProperty;
        public static readonly DependencyProperty SpaceJumpProperty;
        public static readonly DependencyProperty ScrewAttackProperty;

        #endregion Dependency Properties

        #region Properties

        public bool FloorSlide
        {
            get => (bool)GetValue(FloorSlideProperty);
            set => SetValue(FloorSlideProperty, value);
        }

        public bool SpiderMagnet
        {
            get => (bool)GetValue(SpiderMagnetProperty);
            set => SetValue(SpiderMagnetProperty, value);
        }

        public bool SpeedBooster
        {
            get => (bool)GetValue(SpeedBoosterProperty);
            set => SetValue(SpeedBoosterProperty, value);
        }

        public bool SpinBoost
        {
            get => (bool)GetValue(SpinBoostProperty);
            set => SetValue(SpinBoostProperty, value);
        }

        public bool SpaceJump
        {
            get => (bool)GetValue(SpaceJumpProperty);
            set => SetValue(SpaceJumpProperty, value);
        }

        public bool ScrewAttack
        {
            get => (bool)GetValue(ScrewAttackProperty);
            set => SetValue(ScrewAttackProperty, value);
        }

        #endregion Properties

        #region Ctor

        static AbilitiesInventoryModel()
        {
            FloorSlideProperty = RegisterTracked("FloorSlide", typeof(bool), typeof(AbilitiesInventoryModel));
            SpiderMagnetProperty = RegisterTracked("SpiderMagnet", typeof(bool), typeof(AbilitiesInventoryModel));
            SpeedBoosterProperty = RegisterTracked("SpeedBooster", typeof(bool), typeof(AbilitiesInventoryModel));
            SpinBoostProperty = RegisterTracked("SpinBoost", typeof(bool), typeof(AbilitiesInventoryModel));
            SpaceJumpProperty = RegisterTracked("SpaceJump", typeof(bool), typeof(AbilitiesInventoryModel));
            ScrewAttackProperty = RegisterTracked("ScrewAttack", typeof(bool), typeof(AbilitiesInventoryModel));
        }

        public AbilitiesInventoryModel()
        {

        }

        #endregion Ctor
    }
}
