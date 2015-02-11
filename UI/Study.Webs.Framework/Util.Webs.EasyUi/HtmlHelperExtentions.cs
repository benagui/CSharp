﻿using System.Web.Mvc;
using Util.Webs.EasyUi.Services;

namespace Study.Webs.Framework 
{
    /// <summary>
    /// HtmlHelper扩展 - EasyUi扩展
    /// </summary>
    public static class HtmlHelperExtentions 
    {
        /// <summary>
        /// 创建EasyUi服务
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        public static IEasyUiService<T> EasyUi<T>( this HtmlHelper<T> helper ) 
        {
            return EasyUiFactory<T>.CreateEasyUiService( helper );
        }
    }
}
