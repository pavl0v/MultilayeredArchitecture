using MvvmFoundation.Wpf;
using System;
using System.Windows.Input;
using WpfApplicationUI.Dialogs.DialogFactory;

namespace WpfApplicationUI.Dialogs.DialogOK
{
    class DialogOKViewModel : IDialogViewModel
    {
        public event EventHandler<DialogCloseEventArgs> DialogCloseEventHandler;

        #region PROPERTIES
        
        private DialogOKModel model = null;
        public DialogOKModel Model
        {
            get { return model; }
            set { model = value; }
        }

        #endregion

        #region COMMANDS

        private ICommand onOKClickCommand = null;
        public ICommand OnOKClickCommand
        {
            get { return onOKClickCommand; }
            set { onOKClickCommand = value; }
        }

        #endregion

        public DialogOKViewModel(DialogOKModel model)
        {
            this.model = model;
            this.onOKClickCommand = new RelayCommand(() => OnOKClick());
        }

        private void OnOKClick()
        {
            if (this.DialogCloseEventHandler != null)
                this.DialogCloseEventHandler(this, new DialogCloseEventArgs(false, DialogResult.OK));
        }
    }
}
