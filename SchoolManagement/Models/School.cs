using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementPresentationLayer.Models
{
    public class School
    {
        [Required(ErrorMessage ="School Name is Required")]
        [Display(Name ="SchoolName")]   
        public string SchoolName { get; set; }

        [Required(ErrorMessage ="Principal Name is Required")]
        [Display(Name = "PrincipalName")]
        public string PrincipalName { get; set; }

        [Required(ErrorMessage ="Date of InAugration is Required")]
        [Display(Name = "DateOfInaugration")]
        public DateTime DateOfInaugration { get; set; }

        [Required(ErrorMessage ="School Type is Required")]
        [Display(Name = "SchoolType")]
        public string SchoolType { get; set; }

        [Display(Name = "SchoolShift")]
        [Required(ErrorMessage ="School Shift is Required")]
        public string SchoolShift { get; set; }

    }
}
