using System;
using System.Collections.Generic;
using System.Text;

namespace HFrame.Common.Model
{
    public class ResultModel
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
        #region 私有属性
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

        }
        public ResultModel(string ErrorMsg)
        {
            this.ErrorMsg = ErrorMsg;
        }
        public ResultModel(string ErrorMsg,int ErrorCode)
        {
            this.ErrorMsg = ErrorMsg;
            this.ErrorCode = ErrorCode;
        }
        public ResultModel(string ErrorMsg, int ErrorCode, Dictionary<string, object> Data)
        {
            this.ErrorMsg = ErrorMsg;
            this.ErrorCode = ErrorCode;
            this.Data = Data;
        }
        #endregion
    }
}
