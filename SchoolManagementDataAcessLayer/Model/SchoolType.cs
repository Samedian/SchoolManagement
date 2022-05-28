using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagementDataAcessLayer.Model
{
    public partial class SchoolType
    {
        public string SchoolName { get; set; }
        public string SchoolTypeProp { get; set; }

        public virtual SchoolDetail SchoolNameNavigation { get; set; }
    }
}
