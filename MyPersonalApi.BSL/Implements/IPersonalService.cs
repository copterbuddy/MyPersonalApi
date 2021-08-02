using MyPersonalApi.BSL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonalApi.BSL.Implements
{
    public interface IPersonalService
    {
        PersonalModel GetInfo();

        PersonalListModel GetInfoList();
    }
}
