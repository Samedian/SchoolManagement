using SchoolManagementEntity;
using SchoolManagementPresentationLayer.Models;
using System.Collections.Generic;

namespace SchoolManagementPresentationLayer
{
    public interface IBreakData
    {
        List<School> ConvertEntityToModel(List<SchoolEntity> schoolEntity);
        SchoolDetailEntity GetSchoolDetail(School school);
        SchoolShiftEntity GetSchoolShift(School school);
        SchoolTypeEntity GetSchoolType(School school);
    }
}