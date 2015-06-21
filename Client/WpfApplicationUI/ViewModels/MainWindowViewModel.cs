using ClientInterfaces.Models;
using MvvmFoundation.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplicationUI.Dialogs;
using WpfApplicationUI.Dialogs.DialogFactory;
using WpfApplicationUI.Dialogs.DialogYesNo;

namespace WpfApplicationUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IItemsCollection model = null;
        private ClientInterfaces.Factories.IItemFactory itemFactory = null;

        private ObservableCollection<IItem> items = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> Items
        {
            get { return items; }
            set
            {
                items = value;
                //OnPropertyChanged("Items");
            }
        }

        public MainWindowViewModel(IItemsCollection model, ClientInterfaces.Factories.IItemFactory itemFactory)
        {
            this.model = model;
            this.itemFactory = itemFactory;

            //List<IItem> lst = this.model.GetItems();
            //this.items = new ObservableCollection<IItem>(lst);
            this.OnRefreshItems();

            this.editItemCommand = new RelayCommand<object>(OnEditItem);
            this.deleteItemCommand = new RelayCommand<object>(OnDeleteItem);
            this.addItemCommand = new RelayCommand(OnAddItem);
            this.refreshItemsCommand = new RelayCommand(OnRefreshItems);
        }

        #region COMMANDS

        private ICommand editItemCommand = null;
        public ICommand EditItemCommand
        {
            get { return editItemCommand; }
            set { editItemCommand = value; }
        }

        private ICommand deleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get { return deleteItemCommand; }
            set { deleteItemCommand = value; }
        }

        private ICommand addItemCommand = null;
        public ICommand AddItemCommand
        {
            get { return addItemCommand; }
            set { addItemCommand = value; }
        }

        private ICommand refreshItemsCommand = null;
        public ICommand RefreshItemsCommand
        {
            get { return refreshItemsCommand; }
            set { refreshItemsCommand = value; }
        }

        #endregion

        private void OnEditItem(object value)
        {
            if (value == null)
                return;

            Models.Models.Item item = value as Models.Models.Item;
            if (item == null)
                return;

            Dialogs.DialogItem.DialogItemViewModel vm = new Dialogs.DialogItem.DialogItemViewModel(item);
            DialogFactory dialogFactory = new DialogFactory();
            DialogResult dialogResult = dialogFactory.ShowDialog("Item", vm);
            //if (dialogResult == DialogResult.OK)
            //{
            //    OnPropertyChanged("Items");
            //}
        }

        private void OnDeleteItem(object value)
        {
            if (value == null)
                return;

            Models.Models.Item item = value as Models.Models.Item;
            if (item == null)
                return;

            string message = "Delete selected item?";
            DialogYesNoModel m = new DialogYesNoModel(message);
            DialogYesNoViewModel vm = new DialogYesNoViewModel(m);
            DialogFactory dialogFactory = new DialogFactory();
            DialogResult dialogResult = dialogFactory.ShowDialog("Delete", vm);
            if (dialogResult == DialogResult.YES)
            {
                this.model.DeleteItem(item.ID);
            }
        }

        private void OnAddItem()
        {
            IItem item = this.itemFactory.CreateItem().Result;
            Dialogs.DialogItem.DialogItemViewModel vm = new Dialogs.DialogItem.DialogItemViewModel(item);
            DialogFactory dialogFactory = new DialogFactory();
            DialogResult dialogResult = dialogFactory.ShowDialog("Item", vm);
        }

        private void OnRefreshItems()
        {
            this.Items.Clear();
            List<IItem> lst = this.model.GetItems();
            foreach (IItem i in lst)
                this.Items.Add(i);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
