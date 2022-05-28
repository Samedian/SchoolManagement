using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagementDataAcessLayer;
using SchoolManagementDataAcessLayer.Model;
using SchoolManagementEntity;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace SchoolManagementDataAcessLayer
{
    public class GetDataAccessLayer : IGetDataAccessLayer
    {
        private readonly SchoolContext _schoolContext;

        public GetDataAccessLayer(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        /// <summary>
        /// This function fetch all school details from database
        /// </summary>
        /// <returns></returns>
        public List<SchoolEntity> GetSchool()
        {
            List<SchoolEntity> schoolEntities = new List<SchoolEntity>();
            try
            {
                using (var context = _schoolContext)
                {
                    var school = (from data in context.SchoolDetails
                                  join item in context.SchoolTypes on data.SchoolName equals item.SchoolName
                                  select new
                                  {
                                      SchoolName = data.SchoolName,
                                      PrincipalName = data.PrincipalName,
                                      SchoolTypeProp = item.SchoolTypeProp,
                                      DateOfInaugration = data.DateOfInaugration
                                  }).ToList();

                    var schoolList = (from data in school
                                      join item in context.SchoolShifts on data.SchoolName equals item.SchoolName
                                      select new
                                      {
                                          SchoolName = data.SchoolName,
                                          PrincipalName = data.PrincipalName,
                                          SchoolTypeProp = data.SchoolTypeProp,
                                          SchoolShiftProp = item.SchoolShiftProp,
                                          DateOfInaugration = data.DateOfInaugration
                                      }).ToList();

                    foreach (var item in schoolList)
                    {
                        SchoolEntity entity = new SchoolEntity();
                        entity.SchoolName = item.SchoolName;
                        entity.PrincipalName = item.PrincipalName;
                        entity.SchoolType = item.SchoolTypeProp;
                        entity.SchoolShift = item.SchoolShiftProp;
                        entity.DateOfInaugration = item.DateOfInaugration;

                        schoolEntities.Add(entity);
                    }

                }
            }catch(SqlException ex)
            {
                throw ex.InnerException;
            }
            return schoolEntities;
        }
    }
}
