using System.Collections.ObjectModel;
using System.ComponentModel;
namespace NWG.Model
{
    public class FoodGroup : ObservableCollection<Food>, INotifyPropertyChanged
    {

        private bool _expanded;

        public string Title { get; set; }

        public string TitleWithItemCount
        {
            get { return string.Format("{0} ({1})", Title, FoodCount); }
        }

        public string ShortName { get; set; }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string StateIcon
        {
            get { return Expanded ? "Expand.png" : "Collapse.png"; }
        }

        public int FoodCount { get; set; }

        public FoodGroup(string title, bool expanded = true)
        {
            Title = title;
            Expanded = expanded;
        }

        public static ObservableCollection<FoodGroup> All { private set; get; }

        static FoodGroup()
        {
            ObservableCollection<FoodGroup> Groups = new ObservableCollection<FoodGroup>{
                new FoodGroup("Pipeline 1"){
                    new Food { Name = "Exacavation 1" },
                    new Food { Name = "Exacavation 2" }
                },
                new FoodGroup("Pipeline 2"){
                    new Food { Name = "Exacavation 1"},
                    new Food { Name = "Exacavation 2"}
                }
            };
            All = Groups;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}