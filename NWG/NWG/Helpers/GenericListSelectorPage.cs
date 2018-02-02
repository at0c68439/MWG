using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NWG.Helpers
{
    public class GenericListSelectorPage : ContentPage
    {
        //private string _title;

        //public string Title

        //{

        //    get { return _title; }

        //    set { _title = value; }

        //}



        public EventHandler<PickerActionEventArgs> pickerHandler { get; set; }

        private Action<string> _returnCommand;

        private string LastSelected;



        public GenericListSelectorPage(List<object> args)

        {
            //InitializeComponent();
            //if (args.Length != 1)
            //    return;
            //Title = args[0] as string;
            //GetArgValue(args, 0, typeof(string)) as string;
            //var options = args[0] as string[];
            //_returnCommand = args[3] as Action<string>;


            if (args != null)
            {
                ItemListView.ItemsSource = SingleItemMenuSelectable.StringArrayToObservableCollection(args);

            }

            BindingContext = this;

        }



        private async void OnListItemTapped(object sender, ItemTappedEventArgs e)

        {

            // don't do anything if we just de-selected the row

            if (e.Item == null) return;

            LastSelected = ((SingleItemMenuSelectable)e.Item).SelectableString;

            // do something with e.SelectedItem

            ((ListView)sender).SelectedItem = null; // de-select the row



            _returnCommand?.Invoke(LastSelected);



            if (pickerHandler != null)

            {

                pickerHandler(this, new PickerActionEventArgs(LastSelected));

                await Navigation.PopAsync();

            }

        }

    }

    public class SingleItemMenuSelectable
    {
        private string _selectableString;

        public string SelectableString
        {
            get { return _selectableString; }

            set { _selectableString = value; }
        }

        public SingleItemMenuSelectable(string dataString)
        {
            SelectableString = dataString;
        }

        public static ObservableCollection<SingleItemMenuSelectable> StringArrayToObservableCollection(List<object> selections)
        {
            ObservableCollection<SingleItemMenuSelectable> collection = new ObservableCollection<SingleItemMenuSelectable>();

            foreach (string s in selections)

            {
                collection.Add(new SingleItemMenuSelectable(s));
            }
            return collection;

        }
    }
    }

