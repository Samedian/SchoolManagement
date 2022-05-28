using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolManagementBussinessLayer;
using SchoolManagementDataAcessLayer;
using SchoolManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDAL
{
    [TestClass]
    public class InsertBAL
    {
        private static Mock<ISaveDataAccessLayer> mock = new Mock<ISaveDataAccessLayer>();
        private static SaveBussinessLayer save;
        
        [ClassInitialize]
        public static void BeforeClass(TestContext testContext)
        {
            save = new SaveBussinessLayer(mock.Object);

        }

        [TestMethod]
        public void TestMethod1()
        {
            
            mock.Setup(x => x.SaveSchoolDetail(It.IsAny<SchoolDetailEntity>())).Returns(true);
            //SchoolDetailEntity schoolDetailEntity = new SchoolDetailEntity { SchoolName = "XYZ", PrincipalName = "ABC", DateOfInaugration = Convert.ToDateTime("25-12-1998") };
            var result = save.SaveSchoolDetail(It.IsAny<SchoolDetailEntity>());

            Assert.AreEqual(result, true);
      
        }


}
}
