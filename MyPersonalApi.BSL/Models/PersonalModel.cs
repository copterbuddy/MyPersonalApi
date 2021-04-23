using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalApi.BSL.Models
{
    [Serializable]
    public class PersonalModel
    {
        public int Id { get; set; }
        public string CizId { get; set; }
        public string CizName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
}
