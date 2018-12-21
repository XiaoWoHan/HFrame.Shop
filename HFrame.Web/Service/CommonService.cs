using HFrame.CommonDal.Model;
using HFrame.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFrame.Web.Service
{
    public class CommonService
    {
        public static List<MenuTree> GetMenus()
        {
            return Data_Menu.Current.GetList().Select(m=>new MenuTree
            {
                Icon=m.Icon,
                Link=m.LinkHref,
                Title=m.Title
            }).ToList();
        }
    }
}