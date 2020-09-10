using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OA.Data;
using System.Data.SqlClient;

namespace OA.DAL
{
    public class UserInfo
    {

        public DataTable GetUserListInfo()
        {
            DataTable dt = new DataTable();


            return dt;
        }


        public DataTable LoginInfo(string username,string pwd)
        {
            DataTable dt = new DataTable();
            string sqlcmd = string.Format(@"select OA_User.UserID, RealName, NickName, HeadIcon, Birthday, MobilePhone, Email, QQ, WeChat, ManageID, SecurityLevel, CorpID, DeptID, IsAdministrator, State, Description, Ctime,
 UserPassWord, UserMD5PassWord, UserSecretkey, AllowStateTime, AllowEndTime, LockStartTime, LockEndTime, FirstVisitTime, PreVisitTime, LastVisitTime, ChangePWDDate, MulitUserLogin, LogOnCount, Question, AnswerQuention, FirstIPAddress, PreviousIPAddress, LastIPAddress
from  OA_User
left join dbo.OA_UserLogON on OA_User.UserID=OA_UserLogON.UserID
where (OA_User.UserID=@UserID or RealName=@UserID ) and UserMD5PassWord=@pwd
");
            SqlParameter []pares = new  SqlParameter[2];
            dt = SqlHelper.Fill(SqlHelper.CONN_Code,CommandType.Text,sqlcmd,)
            return dt;
        }
    }
}
