namespace WpfApplicationUI.Dialogs.DialogOK
{
    class DialogOKModel
    {
        #region PROPERTIES

        private string message = "";
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        #endregion

        public DialogOKModel(string message)
        {
            this.message = message;
        }
    }
}
