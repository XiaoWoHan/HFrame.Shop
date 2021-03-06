﻿using HFrame.Common.Helper;
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
        /// 查询商品类型
        /// </summary>
        /// <returns></returns>
        public static UIGoodsType GetGoodsType(string OID)
        {
            var GoodsTypes = Data_GoodsType.Current.GetFirst(m=>m.OID==OID);
            var UIModel = new UIGoodsType {
                OID=GoodsTypes?.OID,
                GoodsType=GoodsTypes?.TypeName,
                Sort=GoodsTypes?.Sort??default(int)
            };
            return UIModel;
        }
        /// <summary>
        /// 查询分页商品类型
        /// </summary>
        /// <returns></returns>
        public static List<UIGoodsType> GetPageGoodsType()
        {
            var GoodsTypes = Data_GoodsType.Current.GetPage(1,1);
            var UITypeList = GoodsTypes.Page.Select(m => new UIGoodsType {
                OID=m.OID,
                GoodsType=m.TypeName,
                CreateTime=m.CreateTime
            }).ToList();
            return UITypeList;
        }

        /// <summary>
        /// 更新/保存商品类型
        /// </summary>
        /// <returns></returns>
        public static bool SaveGoodsType(ResultModel result,UIGoodsType Model)
        {
            if (!String.IsNullOrEmpty(Model.OID))
            {
                var DbTypeModel = Data_GoodsType.Current.GetFirst(m=>m.OID.Equals(Model.OID));
                if (DbTypeModel == null)
                {
                    result.ErrorCode = -1;
                    result.ErrorMsg = "未找到商品类型";
                    return false;
                }
                else
                {
                    DbTypeModel.TypeName = Model.GoodsType;
                    DbTypeModel.Sort = Model.Sort;
                    return DbTypeModel.Update(result);
                }
            }
            else
            {
                Data_GoodsType GoodsType = new Data_GoodsType
                {
                    OID = StringHelper.GuidStr,
                    TypeName = Model.GoodsType,
                    Sort = Model.Sort,
                    CreateTime = DateTime.Now,
                    CreateUserOID = result.MemberOID,
                    CreateUserName = result.MemberName
                };
                return GoodsType.Add(result);
            }
        }
        /// <summary>
        /// 删除商品类型
        /// </summary>
        /// <param name="result"></param>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static bool DeleteGoodsType(ResultModel result, string OID)
        {
            if (String.IsNullOrEmpty(OID))
            {
                result.ErrorCode = -1;
                result.ErrorMsg = "未找到商品类型";
                return false;
            }

            var DbModel=Data_GoodsType.Current.GetFirst(m=>m.OID==OID);
            if (DbModel == null)
            {
                result.ErrorCode = -1;
                result.ErrorMsg = "未找到商品类型";
                return false;
            }
            return DbModel.Delete();
        }
    }
}