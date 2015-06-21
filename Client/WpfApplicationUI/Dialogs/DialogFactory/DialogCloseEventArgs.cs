using System;

namespace WpfApplicationUI.Dialogs.DialogFactory
{
    public class DialogCloseEventArgs : EventArgs
    {
        public bool DialogResult
        {
            get;
            private set;
        }

        public DialogResult UserDialogResult
        {
            get;
            private set;
        }

        public DialogCloseEventArgs(bool dialogResult, DialogResult userDialogResult)
        {
            this.DialogResult = dialogResult;
            this.UserDialogResult = userDialogResult;
        }
    }
}
