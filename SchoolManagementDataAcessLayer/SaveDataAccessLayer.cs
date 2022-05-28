using System;
using SchoolManagementDataAcessLayer.Model;
using SchoolManagementEntity;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace SchoolManagementDataAcessLayer
{
    public class SaveDataAccessLayer : ISaveDataAccessLayer
    {
        IConvertEntityToDatabaseEntity _convertEntityToDatabaseEntity;
        private readonly SchoolContext _schoolContext;

        public SaveDataAccessLayer()
        {

        }
        public SaveDataAccessLayer(IConvertEntityToDatabaseEntity convertEntityToDatabaseEntity,SchoolContext schoolContext)
        {
            _convertEntityToDatabaseEntity = convertEntityToDatabaseEntity;
            _schoolContext = schoolContext;
        }

        /// <summary>
        /// This function add school details to database if its not present 
        /// </summary>
        /// <param name="schoolDetailEntity"></param>
        public bool SaveSchoolDetail(SchoolDetailEntity schoolDetailEntity)
        {
            SchoolDetail schoolDetail = _convertEntityToDatabaseEntity.ConvertSchoolDetail(schoolDetailEntity);
            try
            {
                using (var context = _schoolContext)
                {
                    var data = (from item in context.SchoolDetails where item.SchoolName == schoolDetail.SchoolName select item).FirstOrDefault();

                    if (data == null)
                    {
                        context.Add(schoolDetail);
                        context.SaveChanges();
                    }
                    return true;
                }
            }catch(SqlException ex)
            {
                throw ex.InnerException;
            }catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// This function add school type to database 
        /// </summary>
        /// <param name="schoolTypeEntity"></param>
        public bool SaveSchoolType(SchoolTypeEntity schoolTypeEntity)
        {
            SchoolType schoolType = _convertEntityToDatabaseEntity.ConvertSchoolType(schoolTypeEntity);
            try
            {
                using (var context = _schoolContext)
                {
                    var data = (from item in context.SchoolTypes
                                where item.SchoolName == schoolType.SchoolName && item.SchoolTypeProp == schoolType.SchoolTypeProp
                                select item).FirstOrDefault();

                    if (data == null)
                    {
                        context.Add(schoolType);
                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        /// <summary>
        /// This function add school shift to database
        /// </summary>
        /// <param name="schoolShiftEntity"></param>
        public bool SaveSchoolShift(SchoolShiftEntity schoolShiftEntity)
        {
            SchoolShift schoolShift = _convertEntityToDatabaseEntity.ConvertSchoolShift(schoolShiftEntity);
            try
            {
                using (var context = _schoolContext)
                {
                    var data = (from item in context.SchoolShifts
                                where item.SchoolName == schoolShift.SchoolName && item.SchoolShiftProp == schoolShift.SchoolShiftProp
                                select item).FirstOrDefault();

                    if (data == null)
                    {
                        context.Add(schoolShift);
                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex.InnerException;

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
