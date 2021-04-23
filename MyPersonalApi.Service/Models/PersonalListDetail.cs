using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalApi.Service.Models
{
    public class PersonalListDetail
    {
        public List<PersonalDetail> personalListDetail { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
}
