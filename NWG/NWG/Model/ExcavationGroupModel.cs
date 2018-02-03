using System.Collections.ObjectModel;
using System.ComponentModel;
namespace NWG.Model
{
    public class ExcavationGroupModel : ObservableCollection<ExcavationModel>, INotifyPropertyChanged
    {

        private bool _expanded;

        public bool IsDMO { get; set; } 

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
            get { return FoodCount <= 2 && IsDMO; } // TODo

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

        public ExcavationGroupModel(string title, bool expanded = true)
        {
            Title = title;
            Expanded = expanded;
        }

        public static ObservableCollection<ExcavationGroupModel> All { private set; get; }

        static ExcavationGroupModel()
        {
            ObservableCollection<ExcavationGroupModel> Groups = new ObservableCollection<ExcavationGroupModel>{
                new ExcavationGroupModel("Pipeline 1"){
                    new ExcavationModel { Name = "Exacavation 1", IsReviewed= false },
                    new ExcavationModel { Name = "Exacavation 2" }
                },
                new ExcavationGroupModel("Pipeline 2"){
                    new ExcavationModel { Name = "Exacavation 1"},
                    new ExcavationModel { Name = "Exacavation 2", IsReviewed = false }
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