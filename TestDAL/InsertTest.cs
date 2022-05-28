using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolManagementDataAcessLayer;
using SchoolManagementEntity;
using System;

namespace TestDAL
{
   
    [TestClass]
    public class InsertTest
    {
        private static Mock<ISaveDataAccessLayer> mock;
        [ClassInitialize]
        public static void InsertTestStart(TestContext testContext)
        {
            mock = new Mock<ISaveDataAccessLayer>();
            Console.WriteLine("Insert Testing Started");

        }

        [TestMethod]
        public  void TestMethod1()
        {
            SchoolDetailEntity schoolDetailEntity = new SchoolDetailEntity { SchoolName = "ABC",
                PrincipalName = "XYZ", DateOfInaugration = Convert.ToDateTime("25-12-1998") };
            mock.Setup(x => x.SaveSchoolDetail(schoolDetailEntity)).Returns(true);
            var expected = mock.Object.SaveSchoolDetail(schoolDetailEntity);
            Assert.AreEqual(expected, true);

        }

        [TestMethod]
        public void TestMethod2()
        {
        
            SchoolTypeEntity schoolTypeEntity = new SchoolTypeEntity
            {
                SchoolName = "ABC",
                SchoolType = "Primary"
            };

            mock.Setup(x => x.SaveSchoolType(schoolTypeEntity)).Returns(true);
            Assert.AreEqual(mock.Object.SaveSchoolType(schoolTypeEntity), true);
        }

        [TestMethod]
        public void TestMethod3()
        {
            SchoolShiftEntity schoolShiftEntity = new SchoolShiftEntity
            {
                SchoolName = "ABC",
                SchoolShift = "Morning"
            };

            mock.Setup(x => x.SaveSchoolShift(schoolShiftEntity)).Returns(true);
            Assert.AreEqual(mock.Object.SaveSchoolShift(schoolShiftEntity), true);

        }

        [ClassCleanup]
        public static void InsertEnd()
        {
            Console.WriteLine("Insert Testing Completed");
        }

    }
}
