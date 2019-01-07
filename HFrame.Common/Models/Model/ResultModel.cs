using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HFrame.Common.Model
{
    public class ResultModel : MemberModel
    {
        #region 属性
        /// <summary>
        /// 返回信息
        /// </summary>
        public string ErrorMsg { get; set; } = "成功";
        /// <summary>
        /// 返回码
        /// </summary>
        public int ErrorCode { get; set; } = 0;
        /// <summary>
        /// 返回参数
        /// </summary>
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 跳转页面
        /// </summary>
        public string CallbackPage { get; set; }
        /// <summary>
        /// 响应时间
        /// </summary>
        public long ResponseTime
        {
            get
            {
                return Timer.ElapsedMilliseconds;
            }
        }
        #region 私有属性
        /// <summary>
        /// 计时器
        /// </summary>
        private Stopwatch Timer { get; set; } = new Stopwatch();
        /// <summary>
        /// 是否成功
        /// </summary>
        internal bool IsSuccess
        {
            get
            {
                return ErrorCode == 0;
            }
        }
        #endregion
        #endregion

        #region 构造函数
        public ResultModel()
        {
            Timer.Start();
        }
        public ResultModel(string ErrorMsg)
            : this()
        {
            this.ErrorMsg = ErrorMsg;
        }
        public ResultModel(string ErrorMsg, int ErrorCode)
            : this(ErrorMsg)
        {
            this.ErrorCode = ErrorCode;
        }
        public ResultModel(string ErrorMsg, int ErrorCode, Dictionary<string, object> Data)
            : this(ErrorMsg, ErrorCode)
        {
            this.Data = Data;
        }
        #endregion

        #region 析构函数
        ~ResultModel()
        {
            Timer.Stop();
        }
        #endregion
    }
}
