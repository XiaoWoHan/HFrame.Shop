﻿using HFrame.Common.Model;
using HFrame.CommonBS.Helper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
/// <summary>
/// 表单验证过滤器
/// </summary>
namespace HFrame.CommonBS.Filter
{
    public class FormValidationAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpHelper.IsPost)
            {
                foreach (var item in filterContext.ActionParameters)
                {
                    #region 模型表单验证
                    ValidationContext context = new ValidationContext(item.Value, null, null);
                    List<ValidationResult> results = new List<ValidationResult>();
                    var valid = Validator.TryValidateObject(item.Value, context, results, true);
                    if (!valid)
                    {
                        ResultModel result = new ResultModel();
                        result.ErrorCode = -1;
                        result.ErrorMsg = results.FirstOrDefault()?.ErrorMessage;
                        filterContext.Result = new JsonResult { Data = result };
                    }
                    #endregion
                }
            }
        }
    }
}
