using MvvmFoundation.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApplicationUI.Dialogs.DialogFactory;

namespace WpfApplicationUI.Dialogs.DialogItem
{
    public class DialogItemViewModel : IDialogViewModel
    {
        public event EventHandler<DialogCloseEventArgs> DialogCloseEventHandler;

        private ClientInterfaces.Models.IItem item = null;
        private ClientInterfaces.Models.IItem itemPre = null;

        #region PROPERTIES

        public string Name
        {
            get;
            set;
        }

        public double A
        {
            get;
            set;
        }

        public double B
        {
            get;
            set;
        }

        #endregion

        public DialogItemViewModel(ClientInterfaces.Models.IItem item)
        {
            this.item = item;
            this.itemPre = item.Clone();

            this.Name = item.Name;
            this.A = item.ParameterA;
            this.B = item.ParameterB;

            this.onOKClickCommand = new RelayCommand(OnOKClick);
            this.onCancelClickCommand = new RelayCommand(OnCancelClick);
        }

        #region COMMANDS

        private ICommand onOKClickCommand = null;
        public ICommand OnOKClickCommand
        {
            get { return onOKClickCommand; }
            set { onOKClickCommand = value; }
        }

        private ICommand onCancelClickCommand = null;
        public ICommand OnCancelClickCommand
        {
            get { return onCancelClickCommand; }
            set { onCancelClickCommand = value; }
        }

        #endregion

        private void OnOKClick()
        {
            this.item.Name = this.Name;
            this.item.ParameterA = this.A;
            this.item.ParameterB = this.B;
            this.item.Product = this.item.ParameterA * this.item.ParameterB;

            bool save = this.item.Save();
            DialogResult dr = DialogResult.UNDEFINED;
            if (save)
            {
                dr = DialogResult.OK;
            }
            else
            {
                this.item.Name = this.itemPre.Name;
                this.item.ParameterA = this.itemPre.ParameterA;
                this.item.ParameterB = this.itemPre.ParameterB;
                this.item.Product = this.item.ParameterA * this.item.ParameterB;
            }

            if (this.DialogCloseEventHandler != null)
                this.DialogCloseEventHandler(this, new DialogCloseEventArgs(false, dr));
        }

        private void OnCancelClick()
        {
            if (this.DialogCloseEventHandler != null)
                this.DialogCloseEventHandler(this, new DialogCloseEventArgs(false, DialogResult.UNDEFINED));
        }
    }
}
