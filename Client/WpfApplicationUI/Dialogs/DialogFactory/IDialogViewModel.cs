using System;

namespace WpfApplicationUI.Dialogs.DialogFactory
{
    public interface IDialogViewModel
    {
        event EventHandler<DialogCloseEventArgs> DialogCloseEventHandler;
    }
}
