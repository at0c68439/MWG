using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace NWG.Model
{
        public class EventGroupModel<S, T> : ObservableCollection<T>
        {
            private readonly S _key;

            public EventGroupModel(IGrouping<S, T> group)
            : base(group)
            {
                _key = group.Key;
            }

            public S Key
            {
                get { return _key; }
            }
        }

    public class EventModel
    {
        public string Month { get; set; } = "";
        public string DateName { get; set; } = "";
        public string EventTopic { get; set; } = "";
        public string AboutEvent { get; set; } = "";
       }


    }