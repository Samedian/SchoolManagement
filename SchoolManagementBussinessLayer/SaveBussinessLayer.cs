using System;
using SchoolManagementEntity;
using SchoolManagementDataAcessLayer;
namespace SchoolManagementBussinessLayer
{
    public class SaveBussinessLayer : ISaveBussinessLayer
    {
        ISaveDataAccessLayer _saveDataAccessLayer;
        public SaveBussinessLayer()
        {
                
        }
        public SaveBussinessLayer(ISaveDataAccessLayer saveDataAccessLayer)
        {
            _saveDataAccessLayer = saveDataAccessLayer;
        }

        /// <summary>
        /// This function calls data access layer save class to add school details
        /// </summary>
        /// <param name="schoolDetailEntity"></param>
        public bool SaveSchoolDetail(SchoolDetailEntity schoolDetailEntity)
        {
            bool result;
            result = _saveDataAccessLayer.SaveSchoolDetail(schoolDetailEntity);
            return result;
        }

        /// <summary>
        /// This function calls data access layer save class to add school type
        /// </summary>
        /// <param name="schoolTypeEntity"></param>
        public bool SaveSchoolType(SchoolTypeEntity schoolTypeEntity)
        {
            bool result;
            result = _saveDataAccessLayer.SaveSchoolType(schoolTypeEntity);
            return result;
        }

        /// <summary>
        /// This function calls data access layer save class to add school shift
        /// </summary>
        /// <param name="schoolShiftEntity"></param>
        public bool SaveSchoolShift(SchoolShiftEntity schoolShiftEntity)
        {
            bool result;
            result = _saveDataAccessLayer.SaveSchoolShift(schoolShiftEntity);
            return result;
        }
    }
}
