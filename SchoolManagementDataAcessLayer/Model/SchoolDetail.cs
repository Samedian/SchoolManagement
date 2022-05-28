using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagementDataAcessLayer.Model
{
    public partial class SchoolDetail
    {
        public SchoolDetail()
        {
            SchoolShifts = new HashSet<SchoolShift>();
            SchoolTypes = new HashSet<SchoolType>();
        }

        public string SchoolName { get; set; }
        public string PrincipalName { get; set; }
        public DateTime DateOfInaugration { get; set; }

        public virtual ICollection<SchoolShift> SchoolShifts { get; set; }
        public virtual ICollection<SchoolType> SchoolTypes { get; set; }
    }
}
