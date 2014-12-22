

using System.Collections.Generic;
using System.Linq;

namespace TestApplication
{
    public class ListPlay
    {

        public void ListStringReplace()
        {
            List<FeeRetainerStatusList> list = new List<FeeRetainerStatusList>()
                                                   {
                                                       new FeeRetainerStatusList()
                                                           {
                                                               Status = "Due"
                                                           },
                                                       new FeeRetainerStatusList()
                                                           {
                                                               Status = "Draft"
                                                           },
                                                       new FeeRetainerStatusList()
                                                           {
                                                               Status = "Active"
                                                           }

                                                   };

            ReplaceRetainerActiveType(list);


        }

        private string ReplaceDueActiveString()
        {
            return string.Format("{0}/{1}", "Due", "Active");
        }

        private void ReplaceRetainerActiveType(List<FeeRetainerStatusList> feeRetainerStatusList)
        {
            foreach (var retainerStatusList in feeRetainerStatusList)
            {
                
                if (retainerStatusList.Status == "Active")
                    retainerStatusList.Status = ReplaceDueActiveString();
            }
        }
    }

    public class FeeRetainerStatusList 
    {
        public string Status { get; set; }
    }
}
