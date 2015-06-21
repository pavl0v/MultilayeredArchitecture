using System.Windows;

namespace WpfApplicationUI.Dialogs.DialogFactory
{
    public partial class DialogWindow : Window
    {
        public DialogResult UserDialogResult
        {
            get;
            private set;
        }

        public DialogWindow()
        {
            InitializeComponent();
            
            this.UserDialogResult = Dialogs.DialogResult.UNDEFINED;
            this.ContentPresenter.DataContextChanged += ContentPresenter_DataContextChanged;
        }

        void ContentPresenter_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Each dialog has the same DialogWindow as a container for dialog view
            // But any dialog has its own logic (view model) with DialogCloseEventHandler in common
            // That is why view model interface is very useful for this case
            IDialogViewModel d = e.NewValue as IDialogViewModel;

            if (d == null)
                return;

            d.DialogCloseEventHandler += OnDialogClose;
        }

        private void OnDialogClose(object sender, DialogCloseEventArgs e)
        {
            this.UserDialogResult = e.UserDialogResult;
            
            // Magic property! 
            // This DIALOG window will close when the property changes its value :)
            // That is why DialogFactory open this window as modal using ShowDialog() method
            this.DialogResult = e.DialogResult;
        }
    }
}
