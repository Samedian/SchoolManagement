using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagementEntity;
using SchoolManagementDataAcessLayer;

namespace SchoolManagementBussinessLayer
{
    public class GetBussinessLayer : IGetBussinessLayer
    {
        IGetDataAccessLayer _getDataAccessLayer;
        public GetBussinessLayer(IGetDataAccessLayer getDataAccessLayer)
        {
            _getDataAccessLayer = getDataAccessLayer;
        }

        /// <summary>
        /// This function fetch data from data access layer  and send to presentation layer
        /// </summary>
        /// <returns></returns>
        public List<SchoolEntity> GetSchool()
        {
            List<SchoolEntity> schoolEntities = _getDataAccessLayer.GetSchool();
            return schoolEntities;
        }
    }
}
