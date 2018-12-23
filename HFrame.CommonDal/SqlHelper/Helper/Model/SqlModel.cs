using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.CommonDal.Sql
{
    internal class SqlModel
    {
        internal const string SELECT = " SELECT  ";//查询
        internal const string FROM = "   FROM    ";//从
        internal const string COUNT = "  COUNT   ";//数量
        internal const string ORDERBY = "    ORDER   BY  ";//排序
        internal const string TOP = "    TOP     ";//前{0}条记录


        internal const string MAX = "    MAX     ";//最大
        internal const string MIN = "    MIN     ";//最小
        internal const string SUM = "    SUM     ";//和
        internal const string AVG = "    AVG     ";//平均


        internal const string WHERE = "  WHERE   ";//条件
        internal const string AND = "   AND     ";//并且
        internal const string OR = "   OR     ";//或者


        internal const string INSERT = "   INSERT    INTO    ";//插入
        internal const string VALUES = "   VALUES    ";//值
                 

        internal const string DELETE = "   DELETE    ";//删除
                 

        internal const string UPDATE = "   UPDATE    ";//更新
        internal const string SET = "   SET    ";//集
        internal const string AS = " AS  ";
    }
    internal enum EnumSortingType
    {
        /// <summary>
        /// 倒序
        /// </summary>
        DESC=0,
        /// <summary>
        /// 正序
        /// </summary>
        ASC=1
    }
}
