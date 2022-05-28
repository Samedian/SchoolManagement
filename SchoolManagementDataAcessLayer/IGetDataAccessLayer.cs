using SchoolManagementEntity;
using System.Collections.Generic;

namespace SchoolManagementDataAcessLayer
{
    public interface IGetDataAccessLayer
    {
        List<SchoolEntity> GetSchool();
    }
}