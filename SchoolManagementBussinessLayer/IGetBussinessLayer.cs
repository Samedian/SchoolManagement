using SchoolManagementEntity;
using System.Collections.Generic;

namespace SchoolManagementBussinessLayer
{
    public interface IGetBussinessLayer
    {
        List<SchoolEntity> GetSchool();
    }
}