using System;
using System.Collections.ObjectModel;
using NWG.Helpers;
using NWG.Model;
using Xamarin.Forms;

namespace NWG.View
{
    public partial class Dashboard : ContentPage
    {

        private ObservableCollection<ExcavationGroupModel> _allGroups;
        private ObservableCollection<ExcavationGroupModel> _expandedGroups;

        public Dashboard()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            _allGroups = ExcavationGroupModel.All;
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {

            int selectedIndex = _expandedGroups.IndexOf(
                ((ExcavationGroupModel)((Button)sender).CommandParameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        private void AddButtonTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ExcavationInfoPage());
        }

        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<ExcavationGroupModel>();

        for (int i = 0; i < _allGroups.Count;i++ )
            {
                ExcavationGroupModel group = _allGroups[i];

                for (int j = 0; j < group.Count; j++)
                {
                    ExcavationModel food = group[j];

                    switch (j)
                    {
                        
                        case 0:
                            _allGroups[i].StatusCount1StatusIcon = food.IsReviewed ? "Green.png" : "Red.png";
                                break;
                        case 1:
                            _allGroups[i].StatusCount2StatusIcon = food.IsReviewed ? "Green.png" : "Red.png";
                            break;

                        default:
                            break;
                    }
                }
                ExcavationGroupModel oldGroup = _allGroups[i];

                oldGroup.IsDMO = Settings.Role.Equals(Constants.DMO);
                //Create new FoodGroups so we do not alter original list
                ExcavationGroupModel newGroup = new ExcavationGroupModel(oldGroup.Title, oldGroup.Expanded);
                //Add the count of food items for Lits Header Titles to use
                newGroup.FoodCount = oldGroup.Count;
                newGroup.StatusCount1StatusIcon = oldGroup.StatusCount1StatusIcon;
                newGroup.StatusCount2StatusIcon = oldGroup.StatusCount2StatusIcon;
                newGroup.IsDMO = oldGroup.IsDMO;
                if (group.Expanded)
                {
                    foreach (ExcavationModel food in oldGroup)
                    {
                        newGroup.Add(food);
                    }
                }
                _expandedGroups.Add(newGroup);
            }
            GroupedView.ItemsSource = _expandedGroups;
        }
    }
}
