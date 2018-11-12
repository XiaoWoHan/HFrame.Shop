using HFrame.Common.Helper;
using HFrame.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HFrame.CommonBS.Validation
{
    public class FormValidationAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
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
