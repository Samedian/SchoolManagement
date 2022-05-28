using SchoolManagementDataAcessLayer.Model;
using SchoolManagementEntity;
using System.Threading.Tasks;

namespace SchoolManagementDataAcessLayer
{
    public interface IConvertEntityToDatabaseEntity
    {
        SchoolDetail ConvertSchoolDetail(SchoolDetailEntity schoolDetailEntity);
        SchoolShift ConvertSchoolShift(SchoolShiftEntity schoolShiftEntity);
        SchoolType ConvertSchoolType(SchoolTypeEntity schoolTypeEntity);
    }
}