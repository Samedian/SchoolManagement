using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagementDataAcessLayer.Model
{
    public partial class SchoolShift
    {
        public string SchoolName { get; set; }
        public string SchoolShiftProp { get; set; }

        public virtual SchoolDetail SchoolNameNavigation { get; set; }
    }
}
