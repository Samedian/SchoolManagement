using SchoolManagementEntity;
using System.Threading.Tasks;

namespace SchoolManagementDataAcessLayer
{
    public interface ISaveDataAccessLayer
    {
        bool SaveSchoolDetail(SchoolDetailEntity schoolDetailEntity);
        bool SaveSchoolShift(SchoolShiftEntity schoolShiftEntity);
        bool SaveSchoolType(SchoolTypeEntity schoolTypeEntity);
    }
}