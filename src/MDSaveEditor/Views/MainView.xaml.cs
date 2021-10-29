using BMSSV.IO.MetroidDread;
using Excalibur.Wpf.Core.Commands;
using Excalibur.Wpf.Core.DataModels.Extensions;
using Excalibur.Wpf.Core.Views;
using MDSaveEditor.DataModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.Views
{
    public class MainView : ViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty PlayerInventoryProperty;
        public static readonly DependencyPropertyKey OpenFileCommandPropertyKey;
        public static readonly DependencyProperty OpenFileCommandProperty;
        public static readonly DependencyPropertyKey SaveFileCommandPropertyKey;
        public static readonly DependencyProperty SaveFileCommandProperty;

        #endregion Dependency Properties

        #region Properties

        public PlayerInventoryModel PlayerInventory
        {
            get => (PlayerInventoryModel)GetValue(PlayerInventoryProperty);
            set => SetValue(PlayerInventoryProperty, value);
        }

        public string AppVersion
        {
            get => GetType().Assembly.GetName().Version.ToString();
        }

        public DelegateCommand OpenFileCommand
        {
            get => (DelegateCommand)GetValue(OpenFileCommandProperty);
            private set => SetValue(OpenFileCommandPropertyKey, value);
        }

        public DelegateCommand SaveFileCommand
        {
            get => (DelegateCommand)GetValue(SaveFileCommandProperty);
            private set => SetValue(SaveFileCommandPropertyKey, value);
        }

        #endregion Properties

        #region Members

        private MetroidDreadBMSSVFile _commonBMSSV;

        #endregion Members

        #region Ctor

        static MainView()
        {
            PlayerInventoryProperty = DependencyProperty.Register("PlayerInventory", typeof(PlayerInventoryModel), typeof(MainView), new PropertyMetadata(PlayerInventoryPropertyChanged));
            OpenFileCommandPropertyKey = DependencyProperty.RegisterReadOnly("OpenFileCommand", typeof(DelegateCommand), typeof(MainView), null);
            OpenFileCommandProperty = OpenFileCommandPropertyKey.DependencyProperty;
            SaveFileCommandPropertyKey = DependencyProperty.RegisterReadOnly("SaveFileCommand", typeof(DelegateCommand), typeof(MainView), null);
            SaveFileCommandProperty = SaveFileCommandPropertyKey.DependencyProperty;
        }

        public MainView()
        {
            InitializeComponent(
                relativeXamlPath: "/Views/MainView.xaml");

            OpenFileCommand = new DelegateCommand(OpenFile);
            SaveFileCommand = new DelegateCommand(SaveFile, CanSaveFile);
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void PlayerInventoryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MainView view)
            {
                if (e.OldValue is PlayerInventoryModel oldPlayerInventory)
                {
                    oldPlayerInventory.ModelPropertyChanged -= view.PlayerInventory_ModelPropertyChanged;
                }

                if (e.NewValue is PlayerInventoryModel newPlayerInventory)
                {
                    newPlayerInventory.ModelPropertyChanged -= view.PlayerInventory_ModelPropertyChanged;
                    newPlayerInventory.ModelPropertyChanged += view.PlayerInventory_ModelPropertyChanged;
                }

                view.SaveFileCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        private void PlayerInventory_ModelPropertyChanged(DependencyProperty p, object newValue)
        {
            SaveFileCommand.RaiseCanExecuteChanged();
        }

        private void OpenFile(object parameter = null)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Open common.bmssv",
                Filter = "common.bmssv (common.bmssv)|common.bmssv",
                FilterIndex = 0,
                AddExtension = true
            };

            bool dialogSuccess = openFileDialog.ShowDialog().Value;

            if (dialogSuccess)
            {
                _commonBMSSV = MetroidDreadBMSSVFile.OpenFile(openFileDialog.FileName);

                PlayerInventory = PlayerInventoryModel.FromBMSSVSection(
                    _commonBMSSV.Sections["PLAYER_INVENTORY"]).Initialize();

                SaveFileCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanSaveFile(object parameter = null)
        {
            return _commonBMSSV != null && PlayerInventory.HasChanges;
        }

        private void SaveFile(object parameter = null)
        {
            PlayerInventory.SaveChanges();

            _commonBMSSV.Sections["PLAYER_INVENTORY"] = PlayerInventoryModel.ToSection(PlayerInventory);

            MetroidDreadBMSSVFile.SaveFile(_commonBMSSV);
            SaveFileCommand.RaiseCanExecuteChanged();
        }

        #endregion Methods
    }
}
