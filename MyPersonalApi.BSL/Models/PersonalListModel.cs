using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalApi.BSL.Models
{
    [Serializable]
    public class PersonalListModel
    {
        public List<PersonalModel> personalListModels { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
}
