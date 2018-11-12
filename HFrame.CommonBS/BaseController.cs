using HFrame.Common.Model;
using HFrame.CommonBS.Filter;
using HFrame.CommonBS.Helper;
using System.Web.Mvc;
/// <summary>
/// 默认登陆后控制器
/// </summary>
namespace HFrame.CommonBS.Controllers
{
    [CheckLogin]//验证登陆
    public class BaseController : Controller
    {
        public static MemberModel result => LoginHelper.CurrentMember();
    }//TODO 缺少验证
}