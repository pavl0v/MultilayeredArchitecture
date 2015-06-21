namespace WpfApplicationUI.Dialogs.DialogFactory
{
    public class DialogFactory
    {
        public DialogResult ShowDialog(string title, IDialogViewModel datacontext)
        {
            DialogResult res = DialogResult.UNDEFINED;
            DialogWindow win = null;

            //App.Current.Dispatcher.Invoke((Action)delegate
            //{
                win = new DialogWindow();
                win.Title = title;
                win.DataContext = datacontext;
                win.ShowDialog();
                res = win.UserDialogResult;
            //});

            return res;
        }
    }
}
