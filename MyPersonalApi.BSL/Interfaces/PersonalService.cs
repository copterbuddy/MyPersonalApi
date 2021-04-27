using Dapper;
using MyPersonalApi.BSL.Implements;
using MyPersonalApi.BSL.Models;
using MyPersonalApi.DAL.Interfaces;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPersonalApi.BSL.Interfaces
{
    public class PersonalService : IPersonalService
    {
        public readonly IBaseRepository baseRepository;

        public PersonalService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public PersonalModel GetInfo()
        {
            PersonalModel result = new PersonalModel();
            var dynamicParameter = new DynamicParameters();
            try
            {

                string sql = "SELECT * FROM \"PersonalSchemas\".\"CustomerInfoTable\" ORDER BY \"Id\" ASC";
                var value = baseRepository.Query<PersonalModel>(sql).FirstOrDefault();
                result = value;

            }
            catch(Exception ex)
            {
                result.ErrorCode = "9999";
                result.ErrorMessage = $"GetInfo Service error :{ex}";
            }

            return result;
        }

        public PersonalListModel GetInfoList()
        {
            PersonalListModel resultList = new PersonalListModel();
            resultList.personalListModels = new List<PersonalModel>();

            List<PersonalModel> tempList = new List<PersonalModel>();
            var dynamicParameter = new DynamicParameters();

            try
            {
                string sql = "SELECT * FROM \"PersonalSchemas\".\"CustomerInfoTable\" ORDER BY \"Id\" ASC";
                var value = baseRepository.Query<PersonalModel>(sql).ToList();

                resultList.personalListModels = value;
                resultList.ErrorCode = "0000";
                resultList.ErrorMessage = "Success";

            }
            catch (Exception ex)
            {
                resultList.ErrorCode = "9999";
                resultList.ErrorMessage = $"GetInfo Service error :{ex}";
            }

            return resultList;
        }
    }
}
