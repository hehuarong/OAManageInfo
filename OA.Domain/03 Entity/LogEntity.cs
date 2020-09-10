using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Domain
{
    /// <summary>
    /// 日志类（包括各种日志）
    /// </summary>
    public class LogEntity

    {
        public int objid { get; set; }

        public int parentid { get; set; }
        /// <summary>
        /// 操作IP
        /// </summary>
        public string objIP { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string objuserID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string objuserName { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime objctime { get; set; }

        /// <summary>
        /// 操作类型（DBLogType）
        /// </summary>
        public string objtype { get; set; }

        /// <summary>
        /// 操作备注
        /// </summary>
        public string objnote { get; set; }
       /// <summary>
       /// 操作结果
       /// </summary>
        public string objresult { get; set; }
       /// <summary>
       /// 操作单据号
       /// </summary>
        public string objectID { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string objectName { get; set; }


    }
}
