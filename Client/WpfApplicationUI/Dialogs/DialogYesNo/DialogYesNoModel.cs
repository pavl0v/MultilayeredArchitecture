namespace WpfApplicationUI.Dialogs.DialogYesNo
{
    class DialogYesNoModel
    {
        #region PROPERTIES

        private string message = "";
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        #endregion

        public DialogYesNoModel(string message)
        {
            this.message = message;
        }
    }
}
