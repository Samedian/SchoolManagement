using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManagementEntity;
using System.Threading.Tasks;
using SchoolManagementPresentationLayer.Models;

namespace SchoolManagementPresentationLayer
{
    public class BreakData : IBreakData
    {
        /// <summary>
        /// This function break model school entity(presentation layer) to schooldetailentity(entity layer)
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        public SchoolDetailEntity GetSchoolDetail(School school)
        {
            SchoolDetailEntity schoolDetailEntity = new SchoolDetailEntity();
            schoolDetailEntity.SchoolName = school.SchoolName;
            schoolDetailEntity.PrincipalName = school.PrincipalName;
            schoolDetailEntity.DateOfInaugration = school.DateOfInaugration;

            return schoolDetailEntity;
        }

        /// <summary>
        /// This function break model school entity(presentation layer) to schooltypeentity(entity layer)
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        public SchoolTypeEntity GetSchoolType(School school)
        {
            SchoolTypeEntity schoolTypeEntity = new SchoolTypeEntity();
            schoolTypeEntity.SchoolName = school.SchoolName;
            schoolTypeEntity.SchoolType = school.SchoolType;

            return schoolTypeEntity;
        }

        /// <summary>
        /// This function break model school entity(presentation layer) to schoolshiftentity(entity layer)
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        public SchoolShiftEntity GetSchoolShift(School school)
        {
            SchoolShiftEntity schoolShiftEntity = new SchoolShiftEntity();
            schoolShiftEntity.SchoolName = school.SchoolName;
            schoolShiftEntity.SchoolShift = school.SchoolShift;

            return schoolShiftEntity;
        }

        /// <summary>
        /// This function convert entity layer entity to model school entity
        /// </summary>
        /// <param name="schoolEntity"></param>
        /// <returns></returns>
        public List<School> ConvertEntityToModel(List<SchoolEntity> schoolEntity)
        {
            List<School> schools = new List<School>();

            foreach (var item in schoolEntity)
            {
                School school = new School();
                school.SchoolName = item.SchoolName;
                school.PrincipalName = item.PrincipalName;
                school.SchoolType = item.SchoolType;
                school.SchoolShift = item.SchoolShift;
                school.DateOfInaugration = item.DateOfInaugration;

                schools.Add(school);
            }

            return schools;
        }
    }
}
