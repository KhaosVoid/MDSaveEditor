using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MDSaveEditor.Controls
{
    public class AttachedProperties
    {
        #region Dependency Properties

        public static readonly DependencyProperty ButtonVectorIconProperty;

        #endregion Dependency Properties

        #region Ctor

        static AttachedProperties()
        {
            ButtonVectorIconProperty = DependencyProperty.RegisterAttached("ButtonVectorIcon", typeof(DrawingBrush), typeof(AttachedProperties));
        }

        #endregion Ctor

        #region Methods

        public static DrawingBrush GetButtonVectorIcon(Button button)
        {
            return (DrawingBrush)button.GetValue(ButtonVectorIconProperty);
        }

        public static void SetButtonVectorIcon(Button button, DrawingBrush value)
        {
            button.SetValue(ButtonVectorIconProperty, value);
        }

        #endregion Methods
    }
}
