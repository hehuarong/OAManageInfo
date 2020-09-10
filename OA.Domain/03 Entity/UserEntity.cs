using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Domain
{
    public  class UserEntity
    {
        public int objid { get; set; }
        public int UserID { get; set; }
        public string RealName { get; set; }

        public string NickName { get; set; }

        public string HeadIcon { get; set; }

        public string Birthday { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string QQ { get; set; }

        public string WeChat { get; set; }

        public string ManageID { get; set; }

        public string SecurityLevel { get; set; }

        public string CorpID { get; set; }

        public string DeptID { get; set; }

        public string IsAdministrator { get; set; }

        public string State { get; set; }

        public string Description { get; set; }
        public string Ctime { get; set; }
        public string DeleteTime { get; set; }

    }
}
