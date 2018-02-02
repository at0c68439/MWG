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
                    OnPropertyChanged("AddButtonVisibility");
                    OnPropertyChanged("ExpandButtonVisibility");
                    OnPropertyChanged("StatusCount1IconVisibility");
                    OnPropertyChanged("StatusCount2IconVisibility");

                }
            }
        }

        public bool AddButtonVisibility
        {
            get { return FoodCount != 2; }

        }

        public bool ExpandButtonVisibility
        {
            get { return FoodCount >0 ; }

        }

        public bool StatusCount1IconVisibility
        {
            get { return FoodCount >0; }

        }

        public bool StatusCount2IconVisibility
        {
            get { return FoodCount > 1; }

        }

        private string _statusCount1StatusIcon;
        public string StatusCount1StatusIcon
        {
            get { return _statusCount1StatusIcon; }
            set {
                    _statusCount1StatusIcon = value;
            }
        }

        private string _statusCount2StatusIcon;
        public string StatusCount2StatusIcon
        {
            get { return _statusCount2StatusIcon; }

            set
            {
               
                    _statusCount2StatusIcon = value;
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
                    new Food { Name = "Exacavation 1", IsReviewed= false },
                    new Food { Name = "Exacavation 2" }
                },
                new FoodGroup("Pipeline 2"){
                    new Food { Name = "Exacavation 1"},
                    new Food { Name = "Exacavation 2", IsReviewed = false }
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