using System.Collections.ObjectModel;
using System.ComponentModel;
namespace NWG.Model
{
    public class ExcavationGroupModel : ObservableCollection<NewActivityModel>, INotifyPropertyChanged
    {

        private bool _expanded;

        public bool IsDMO { get; set; }

        public bool IsNotEmptyRowPresent { get; set; } = true;

        public string Title { get; set; }

        public string GroupID { get; set; }

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
            get { return FoodCount < 2 && IsDMO ; } // TODo

        }

        public bool ExpandButtonVisibility
        {
            get { return FoodCount >0 && IsNotEmptyRowPresent; }

        }

        public bool StatusCount1IconVisibility
        {
            get { return FoodCount >0 && IsNotEmptyRowPresent; }

        }

        public bool StatusCount2IconVisibility
        {
            get { return FoodCount > 1; }

        }

        private string _statusCount1StatusIcon="";
        public string StatusCount1StatusIcon
        {
            get { return _statusCount1StatusIcon; }
            set {
                    _statusCount1StatusIcon = value;
            }
        }

        private string _statusCount2StatusIcon="";
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

        public ExcavationGroupModel(string title, string groupID, bool expanded = true)
        {
            Title = title;
            GroupID = groupID;
            Expanded = expanded;
        }

        public static ObservableCollection<ExcavationGroupModel> All {  set; get; }

        //static ExcavationGroupModel()
        //{
        //    ObservableCollection<ExcavationGroupModel> Groups = new ObservableCollection<ExcavationGroupModel>{
        //        new ExcavationGroupModel("Pipeline 1", "1"){
        //            new NewActivityModel { Name = "Exacavation 1", IsReviewed= false },
        //            new NewActivityModel { Name = "Exacavation 2" }
        //        },
        //        new ExcavationGroupModel("Pipeline 2", "2"){
        //            new NewActivityModel { Name = "Exacavation 1"},
        //            new NewActivityModel { Name = "Exacavation 2", IsReviewed = false }
        //        }
        //    };
        //    All = Groups;
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}