using System;
using System.Collections.ObjectModel;
using NWG.Model;
using Xamarin.Forms;

namespace NWG.View
{
    public partial class Dashboard : ContentPage
    {

        private ObservableCollection<FoodGroup> _allGroups;
        private ObservableCollection<FoodGroup> _expandedGroups;

        public Dashboard()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            _allGroups = FoodGroup.All;
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedGroups.IndexOf(
                ((FoodGroup)((Button)sender).CommandParameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        private void AddButtonTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ExcavationInfoPage());
        }

        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<FoodGroup>();

        for (int i = 0; i < _allGroups.Count;i++ )
            {
                FoodGroup group = _allGroups[i];

                for (int j = 0; j < group.Count; j++)
                {
                    Food food = group[j];

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
                FoodGroup oldGroup = _allGroups[i];

                //Create new FoodGroups so we do not alter original list
                FoodGroup newGroup = new FoodGroup(oldGroup.Title, oldGroup.Expanded);
                //Add the count of food items for Lits Header Titles to use
                newGroup.FoodCount = oldGroup.Count;
                newGroup.StatusCount1StatusIcon = oldGroup.StatusCount1StatusIcon;
                newGroup.StatusCount2StatusIcon = oldGroup.StatusCount2StatusIcon;
                if (group.Expanded)
                {
                    foreach (Food food in oldGroup)
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
