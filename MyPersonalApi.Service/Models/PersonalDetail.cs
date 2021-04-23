using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalApi.Service.Models
{
    public class PersonalDetail
    {
        public int Id { get; set; }
        public string CizId { get; set; }
        public string CizName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
}
