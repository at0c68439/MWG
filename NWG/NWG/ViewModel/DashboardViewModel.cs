using System;
using System.Collections.ObjectModel;
using System.Linq;
using NWG.Model;

namespace NWG.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<ExcavationGroupModel> Groups;
        public DashboardViewModel()
        {
        }

        public void CreateExcavationGroupModel()
        {
            Groups = new ObservableCollection<ExcavationGroupModel>{
                    new ExcavationGroupModel("Pipeline 1", "1"){
                    new NewActivityModel { IsNotEmptyRow = false}
                    },
                    new ExcavationGroupModel("Pipeline 2", "2"){
                    new NewActivityModel{ IsNotEmptyRow = false }

                    }
                };
           
        }

        public ObservableCollection<ExcavationGroupModel> LoadAllExcavationGroups()
        {
            var groups = new ObservableCollection<ExcavationGroupModel>();
            groups = Groups;

            var vList = App.DAUtil.GetAllEmployees();
            var firstGroupExcavationList = vList.Where((it) => it.GroupId.Equals("1")).Take(2).ToList();
            var secondGroupExcavationList = vList.Where((it) => it.GroupId.Equals("2")).Take(2).ToList();
            if (firstGroupExcavationList.Count() > 0)
            {
                groups[0].RemoveAt(0);
                for (int index = 0; index < firstGroupExcavationList.Count(); index++)
                {
                    NewActivityModel activitityModel = firstGroupExcavationList[index];

                    if (index == 0)
                    {
                        activitityModel.Name = "Excavation 1";
                    }
                    else
                    {
                        activitityModel.Name = "Excavation 2";
                    }

                    groups[0].Add(activitityModel);
                }
            }

            if (secondGroupExcavationList.Count() > 0)
            {
                groups[1].RemoveAt(0);
                for (int index = 0; index < secondGroupExcavationList.Count(); index++)
                {
                    NewActivityModel activitityModel = secondGroupExcavationList[index];
                    if (index == 0)
                    {
                        activitityModel.Name = "Excavation 1";
                    }
                    else
                    {
                        activitityModel.Name = "Excavation 2";
                    }

                    groups[1].Add(activitityModel);
                }
            }

            return groups;
        }
    }
}
