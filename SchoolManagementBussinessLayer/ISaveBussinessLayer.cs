using SchoolManagementEntity;

namespace SchoolManagementBussinessLayer
{
    public interface ISaveBussinessLayer
    {
        bool SaveSchoolDetail(SchoolDetailEntity schoolDetailEntity);
        bool SaveSchoolShift(SchoolShiftEntity schoolShiftEntity);
        bool SaveSchoolType(SchoolTypeEntity schoolTypeEntity);
    }
}