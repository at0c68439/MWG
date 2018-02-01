using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NWG.Model;
using Xamarin.Forms;

namespace NWG.View
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            SetGroupList();
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");


        }

        public ObservableCollection<EventGroupModel<string, EventModel>> _eventGroupProperty;
        public ObservableCollection<EventGroupModel<string, EventModel>> EventGroupProperty
        {
            get
            {
                return _eventGroupProperty;
            }

            set
            {
                _eventGroupProperty = value;
            }
        }

        void SetGroupList()
        {
            //   var result = _eventService.GetEventsAsync(); ;
            var eventList = getGroupList();

            var groupedData = eventList.GroupBy(p => p.Month)
                                       .Select(p => new EventGroupModel<string, EventModel>(p))
            .ToList();
            EventGroupProperty = new ObservableCollection<EventGroupModel<string, EventModel>>(groupedData);

        }

        List<EventModel> getGroupList()
        {

            var resultList = new List<EventModel> {
                new EventModel{ AboutEvent = "it is good", DateName = "25", EventTopic = "education",Month = "01"},
                new EventModel{ AboutEvent = "it is very good", DateName = "26", EventTopic = "cyber",Month = "02"},
                new EventModel{ AboutEvent = "it is super good", DateName = "27", EventTopic = "cyber",Month = "01"},
                new EventModel{ AboutEvent = "it is very very good", DateName = "28", EventTopic = "education",Month = "02"}

            };
            return resultList;
        }
    }
}
