using System;
using SchoolManagementEntity;
using System.Collections.Generic;
using System.Text;
using SchoolManagementDataAcessLayer.Model;

namespace SchoolManagementDataAcessLayer
{
    public class ConvertEntityToDatabaseEntity : IConvertEntityToDatabaseEntity
    {
        /// <summary>
        /// This function convert school detail from entity layer to school detail data access layer
        /// </summary>
        /// <param name="schoolDetailEntity"></param>
        /// <returns></returns>
        public SchoolDetail ConvertSchoolDetail(SchoolDetailEntity schoolDetailEntity)
        {
            SchoolDetail schoolDetail = new SchoolDetail();
            schoolDetail.SchoolName = schoolDetailEntity.SchoolName;
            schoolDetail.PrincipalName = schoolDetailEntity.PrincipalName;
            schoolDetail.DateOfInaugration = schoolDetailEntity.DateOfInaugration;

            return schoolDetail;
        }

        /// <summary>
        /// This function convert school type from entity layer to school detail data access layer
        /// </summary>
        /// <param name="schoolTypeEntity"></param>
        /// <returns></returns>
        public SchoolType ConvertSchoolType(SchoolTypeEntity schoolTypeEntity)
        {
            SchoolType schoolType = new SchoolType();
            schoolType.SchoolName = schoolTypeEntity.SchoolName;
            schoolType.SchoolTypeProp = schoolTypeEntity.SchoolType;

            return schoolType;
        }

        /// <summary>
        /// This function convert school shift from entity layer to school detail data access layer
        /// </summary>
        /// <param name="schoolShiftEntity"></param>
        /// <returns></returns>
        public SchoolShift ConvertSchoolShift(SchoolShiftEntity schoolShiftEntity)
        {
            SchoolShift schoolShift = new SchoolShift();
            schoolShift.SchoolName = schoolShiftEntity.SchoolName;
            schoolShift.SchoolShiftProp = schoolShiftEntity.SchoolShift;

            return schoolShift;
        }
    }
}
