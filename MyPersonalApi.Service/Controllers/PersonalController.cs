using Microsoft.AspNetCore.Mvc;
using MyPersonalApi.BSL.Implements;
using MyPersonalApi.BSL.Models;
using MyPersonalApi.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalApi.Service.Controllers
{
    [Route("api/[controller]")]
    public class PersonalController : Controller
    {
        private readonly IPersonalService personalService;

        public PersonalController(IPersonalService personalService)
        {
            this.personalService = personalService;
        }

        [HttpGet("MyInfo")]
        public IActionResult Get()
        {
            PersonalDetail result = new PersonalDetail();
            try
            {
                var data = personalService.GetInfo();
                result.CizId = data.CizId;
                result.CizName = data.CizName;
                result.ErrorCode = "0000";
                result.ErrorMessage = "Success";

            }
            catch (Exception ex)
            {
                result.ErrorCode = "9999";
                result.ErrorMessage = $"MyInfo Controller error :{ex}";
            }

            var myJson =  JsonConvert.SerializeObject(result);
            return Ok(myJson);

        }

        [HttpGet("MyInfoList")]
        public IActionResult GetList()
        {
            PersonalListDetail resultList = new PersonalListDetail();
            resultList.personalListDetail = new List<PersonalDetail>();

            try
            {
                var data = personalService.GetInfoList();

                resultList.personalListDetail = data.personalListModels.Select(s => new PersonalDetail()
                {
                    Id = s.Id,
                    CizId = s.CizId,
                    CizName = s.CizName,
                }).ToList();

                resultList.ErrorCode = data.ErrorCode;
                resultList.ErrorMessage = data.ErrorMessage;

            }
            catch (Exception ex)
            {
                resultList.ErrorCode = "9999";
                resultList.ErrorMessage = $"MyInfoList Controller error :{ex}";
            }

            var myJson = JsonConvert.SerializeObject(resultList);
            return Ok(myJson);

        }

    }
}
