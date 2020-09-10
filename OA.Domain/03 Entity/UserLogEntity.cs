using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Domain
{
    public  class UserLogEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 明码
        /// </summary>
        public string UserPassWord { get; set; }
        /// <summary>
        /// md5加密密码
        /// </summary>
        public string UserMD5PassWord { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string UserSecretKey { get; set; }
        /// <summary>
        /// 允许操作开始时间
        /// </summary>
        public string AllowStateTime { get; set; }
        /// <summary>
        /// 允许操作结束时间
        /// </summary>
        public string AllowEndTime { get; set; }
        /// <summary>
        /// 用户锁定时间
        /// </summary>
        public string LockStateTime{ get; set; }
        /// <summary>
        /// 用户锁定结束时间
        /// </summary>
        public string LockEndTime { get; set; }
        /// <summary>
        /// 首次登陆时间
        /// </summary>
        public string FirstVisitTime { get; set; }
        /// <summary>
        /// 上一次登陆时间
        /// </summary>
        public string PreVisitTime { get; set; }
        /// <summary>
        /// 最后一次登陆时间
        /// </summary>
        public string LastVisitTime { get; set; }
        /// <summary>
        /// 最后一次修改密码时间
        /// </summary>
        public string ChangePWDDate { get; set; }
        /// <summary>
        /// 是否允许多地登陆
        /// </summary>
        public string MulitUserLogin{ get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public string LogOnCount { get; set; }
        /// <summary>
        /// 问题
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string AnswerQuention { get; set; }
        /// <summary>
        /// 第一次登陆IP
        /// </summary>
        public string FirstIpAddress { get; set; }
        /// <summary>
        /// 上一次登陆IP
        /// </summary>
        public string PreIPAddress { get; set; }
        /// <summary>
        /// 最后一次登陆IP
        /// </summary>
        public string LastIPAddress { get; set; }
    }
}
