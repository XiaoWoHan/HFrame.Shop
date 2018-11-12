﻿using HFrame.CommonDal.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace HFrame.CommonDal.Sql
{
    internal class LambdaRouter
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// sql参数集合
        /// </summary>
        public List<DataParameter> Parameters { get; set; }

        /// <summary>
        /// 带sql参数的构造函数
        /// </summary>
        /// <param name="parameters"></param>
        public LambdaRouter(List<DataParameter> parameters = null)
        {
            this.Parameters = parameters;
            if (this.Parameters == null)
            {
                this.Parameters = new List<DataParameter>();
            }
        }

        /// <summary>
        /// 解析表达式
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public string ExpressionRouter(Expression exp)
        {
            var obj = new ParserBuilder()
            {
                ArgumentsStartIndex = this.Parameters.Count
            };
            obj.InitBuild(exp);

            this.Result = obj.Result;
            foreach (DictionaryEntry item in obj.Arguments)
            {
                if (item.Value == null)
                {
                    var rex = "\\((.*?)" + item.Key.ToString() + "\\)";
                    var arr = Regex.Matches(this.Result, rex);
                    foreach (var _temp in arr)
                    {
                        var name = "";
                        var value = "";
                        if (_temp.ToString().IndexOf("<>") > -1)
                        {
                            name = Regex.Split(_temp.ToString(), "<>")[0].Trim().Remove(0, 1);//移除左侧括号
                            value = " IS NOT NULL";
                        }
                        else if (_temp.ToString().IndexOf("=") > -1)
                        {
                            name = Regex.Split(_temp.ToString(), "=")[0].Trim().Remove(0, 1);
                            value = " IS NULL";
                        }
                        this.Result = this.Result.Replace(_temp.ToString(), string.Format("({0} {1})", name, value));
                    }
                }
                else
                {
                    this.Parameters.Add(new DataParameter(item.Key.ToString(), item.Value));
                }
            }
            return obj.Result;
        }
    }
}
