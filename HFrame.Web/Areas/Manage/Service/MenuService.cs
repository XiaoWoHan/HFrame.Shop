using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonDal.Model;
using HFrame.Web.Areas.Manage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFrame.Web.Areas.Manage.Service
{
    public class MenuService
    {
        /// <summary>
        /// 查询商品类型列表
        /// </summary>
        /// <returns></returns>
        public static List<UIMenu> GetPageMenus()
        {
            var Menus = Data_Menu.Current.GetList();
            var UITypeList = Menus.Select(m => new UIMenu
            {
                OID = m?.OID,
                Title = m?.Title,
                Icon = m?.Icon,
                Link = m?.LinkHref,
                Layer = m?.Layer ?? default(int),
                CreateTime = m?.CreateTime ?? default(DateTime)
            }).ToList();
            return UITypeList;
        }
        /// <summary>
        /// 获取按钮
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static UIMenu GetMenu(string OID)
        {
            var MenuModel = Data_Menu.Current.GetFirst(m => m.OID == OID);
            var UIModel = new UIMenu
            {
                OID = MenuModel?.OID,
                Title = MenuModel?.Title,
                Icon = MenuModel?.Icon,
                Link = MenuModel?.LinkHref,
                Layer = MenuModel?.Layer ?? default(int),
                CreateTime = MenuModel?.CreateTime ?? default(DateTime)
            };
            return UIModel;
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="result"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool SaveMenu(ResultModel result,UIMenu Model)
        {
            if (!String.IsNullOrEmpty(Model.OID))
            {
                var DbMenu = Data_Menu.Current.GetFirst(m => m.OID.Equals(Model.OID));
                if (DbMenu == null)
                {
                    result.ErrorCode = -1;
                    result.ErrorMsg = "未找到商品类型";
                    return false;
                }
                else
                {
                    DbMenu.Title = Model.Title;
                    DbMenu.Layer = Model.Layer;
                    DbMenu.Icon = Model.Icon;
                    DbMenu.LinkHref = Model.Link;
                    DbMenu.Layer = Model.Layer;
                    return DbMenu.Update(result);
                }
            }
            else
            {
                Data_Menu Menu = new Data_Menu
                {
                    OID = StringHelper.GuidStr,
                    Icon=Model.Icon,
                    Layer=Model.Layer,
                    LinkHref=Model.Link,
                    Title=Model.Title,
                    CreateTime = DateTime.Now,
                    CreateUserOID = result.MemberOID,
                    CreateUserName = result.MemberName
                };
                return Menu.Add(result);
            }
        }
    }
}