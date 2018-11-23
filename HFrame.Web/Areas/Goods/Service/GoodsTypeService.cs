using HFrame.Common.Helper;
using HFrame.Common.Model;
using HFrame.CommonDal.Model;
using HFrame.Web.Areas.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HFrame.Web.Areas.Goods.Service
{
    public class GoodsTypeService
    {
        /// <summary>
        /// 查询分页商品类型
        /// </summary>
        /// <returns></returns>
        public static List<UIGoodsType> GetPageGoodsType()
        {
            var GoodsTypes = Data_GoodsType.Current.GetList();
            var UITypeList = GoodsTypes.Select(m => new UIGoodsType {
                GoodsType=m.TypeName,
                CreateTime=m.CreateTime
            }).ToList();
            return UITypeList;
        }

        /// <summary>
        /// 查询分页商品类型
        /// </summary>
        /// <returns></returns>
        public static bool SaveGoodsType(MemberModel result,UIGoodsType Model)
        {
            Data_GoodsType GoodsType = new Data_GoodsType
            {
                OID = StringHelper.GuidStr,
                TypeName = Model.GoodsType,
                Sort = Model.Sort,
                CreateTime = DateTime.Now,
                CreateUserOID = result.MemberOID,
                CreateUserName = result.MemberName,
                ParentOID = ""
            };
            return GoodsType.Add();
        }
    }
}