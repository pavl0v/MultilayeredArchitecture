using MvvmFoundation.Wpf;
using System;
using System.Windows.Input;
using WpfApplicationUI.Dialogs.DialogFactory;

namespace WpfApplicationUI.Dialogs.DialogYesNo
{
    class DialogYesNoViewModel : IDialogViewModel
    {
        public event EventHandler<DialogCloseEventArgs> DialogCloseEventHandler;

        #region PROPERTIES

        private DialogYesNoModel model = null;
        public DialogYesNoModel Model
        {
            get { return model; }
            set { model = value; }
        }

        #endregion

        #region COMMANDS

        private ICommand onYesClickCommand = null;
        public ICommand OnYesClickCommand
        {
            get { return onYesClickCommand; }
            set { onYesClickCommand = value; }
        }

        private ICommand onNoClickCommand = null;
        public ICommand OnNoClickCommand
        {
            get { return onNoClickCommand; }
            set { onNoClickCommand = value; }
        }

        #endregion

        public DialogYesNoViewModel(DialogYesNoModel model)
        {
            this.model = model;
            this.onYesClickCommand = new RelayCommand(() => OnYesClick());
            this.onNoClickCommand = new RelayCommand(() => OnNoClick());
        }

        private void OnYesClick()
        {
            if (this.DialogCloseEventHandler != null)
                this.DialogCloseEventHandler(this, new DialogCloseEventArgs(false, DialogResult.YES));
        }

        private void OnNoClick()
        {
            if (this.DialogCloseEventHandler != null)
                this.DialogCloseEventHandler(this, new DialogCloseEventArgs(false, DialogResult.NO));
        }
    }
}
