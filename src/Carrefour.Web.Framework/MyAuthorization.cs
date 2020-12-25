using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Carrefour.WebApp
{
    /// <summary>
    /// 跳过检查属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class SkipUserAuthorizeAttribute : Attribute, IFilterMetadata
    {
    }

    public class MyAuthorization : IAuthorizationFilter
    {
        public const string UserAuthenticationScheme = "UserAuthenticationScheme"; //自定义一个默认的登录方案

        public void OnAuthorization(AuthorizationFilterContext context)
        {


            //获取对应Scheme方案的登录用户呢？使用HttpContext.AuthenticateAsync
            var authenticate = context.HttpContext.AuthenticateAsync(MyAuthorization.UserAuthenticationScheme).Result;

            if ((authenticate != null && authenticate.Succeeded) || this.SkipUserAuthorize(context.ActionDescriptor))
            {
                return;
            }

            HttpRequest httpRequest = context.HttpContext.Request;
            string url = ("~/Login");
            url = string.Concat(url, "?returnUrl=", httpRequest.Path);

            RedirectResult redirectResult = new RedirectResult(url);
            context.Result = redirectResult;
            return;
        }

        protected virtual bool SkipUserAuthorize(ActionDescriptor actionDescriptor)
        {
            bool skipAuthorize = actionDescriptor.FilterDescriptors.Any(a => a.Filter is SkipUserAuthorizeAttribute);
            if (skipAuthorize)
            {
                return true;
            }

            return false;
        }


    }
}
