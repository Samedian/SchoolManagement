using Microsoft.AspNetCore.Mvc;
using SchoolManagementPresentationLayer.Models;
using SchoolManagementEntity;
using SchoolManagementBussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementPresentationLayer.Controllers
{
    public class SchoolController : Controller
    {
        IBreakData _breakData;
        ISaveBussinessLayer _saveBussinessLayer;
        IGetBussinessLayer _getBussinessLayer;
        IFileWrite _fileWrite;
        
        public SchoolController(IBreakData breakData , ISaveBussinessLayer saveBussinessLayer,IGetBussinessLayer getBussinessLayer,IFileWrite fileWrite)
        {
            _breakData = breakData;
            _saveBussinessLayer = saveBussinessLayer;
            _getBussinessLayer = getBussinessLayer;
            _fileWrite = fileWrite;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(School school, string Submit)
        {
            await Save();
            if (!String.IsNullOrEmpty(Submit))
            {
                SchoolDetailEntity schoolDetailEntity = _breakData.GetSchoolDetail(school);
                SchoolTypeEntity schoolTypeEntity = _breakData.GetSchoolType(school);
                SchoolShiftEntity schoolShiftEntity = _breakData.GetSchoolShift(school);

                try
                {
                    _saveBussinessLayer.SaveSchoolDetail(schoolDetailEntity);
                    _saveBussinessLayer.SaveSchoolType(schoolTypeEntity);
                    _saveBussinessLayer.SaveSchoolShift(schoolShiftEntity);
                    _fileWrite.WriteData(school.SchoolName+" - "+school.SchoolShift+" - "+school.SchoolType+"   "+"Data Added to Database\n");


                }catch(Exception ex)
                {
                    _fileWrite.WriteData(school.SchoolName + " - " + school.SchoolShift + " - " + school.SchoolType + "   " + "Data Not added due to exception \n"+ex.Message);
                    ViewBag.Error = ex.Message;

                }
            }
            else
            {
                return View("Index");
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<SchoolEntity> schoolEntities=null;
            try
            {
                schoolEntities = _getBussinessLayer.GetSchool();
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            HashSet<SchoolEntity> data = new HashSet<SchoolEntity>();

            foreach (var item in schoolEntities)
            {
                data.Add(item);
            }
            ViewBag.Data = data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Get(string schoolName,string Submit)
        {
            await Get();
            List<SchoolEntity> schoolEntities = null;
            if (!String.IsNullOrEmpty(Submit))
            {
                try
                {
                   schoolEntities = _getBussinessLayer.GetSchool().FindAll(x => x.SchoolName == schoolName);
                }catch(Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }

                List<School> schools = _breakData.ConvertEntityToModel(schoolEntities);

                GetBySchoolName(schools);
                _fileWrite.WriteData(schoolName + "Data Fetched from Database\n");

                return View("GetBySchoolName");

            }
            else
                return View("Index");
            
        }

        [HttpGet]
        public void GetBySchoolName(List<School> schools)
        {
            ViewBag.Data = schools;
        }

    }
}
