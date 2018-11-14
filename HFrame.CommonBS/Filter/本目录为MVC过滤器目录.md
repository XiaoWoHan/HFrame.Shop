### 本目录为MVC过滤器目录

详细：https://www.cnblogs.com/seeworld/p/6922407.html

1.定义继承ActionFilterAttribute抽象类

2.重写方法：

```c#
//    在Action执行之后由 MVC 框架调用。
public virtual void OnActionExecuted(ActionExecutedContext filterContext);
//     在Action执行之前由 MVC 框架调用。
public virtual void OnActionExecuting(ActionExecutingContext filterContext);
//     在执行Result后由 MVC 框架调用。
public virtual void OnResultExecuted(ResultExecutedContext filterContext);
//     在执行Result之前由 MVC 框架调用。
public virtual void OnResultExecuting(ResultExecutingContext filterContext);
```

3.加入全局过滤器

在文件夹 App_Start下的 FilterConfig.cs中写入:

```c#
filters.Add(new [过滤器名称]());
```

4.表单验证

```C#
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
```



