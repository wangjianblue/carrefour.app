using Carrefour.Core.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Carrefour.Core;
using Carrefour.WebApp;
using Microsoft.AspNetCore.Http;

namespace Carrefour.Web.Framework
{
    public class WorkContext : IWorkContext
    {
        private Customer _cachedCustomer;

        public WorkContext(Customer cachedCustomer)
        {
            _cachedCustomer = cachedCustomer;
        }

        public Customer CurrentCustomer
        {
            get
            {
                if (_cachedCustomer != null)
                    return _cachedCustomer; 
                Customer customer = null;
                if (AppHttpContext.Current == null)
                {
                    customer=new Customer()
                    {
                        id = 009,
                        Username = "admin"
                    };
                }
                _cachedCustomer = customer;
                return _cachedCustomer;
            }
            set
            {
                SetCustomerCookie(value.CustomerGuid);
                _cachedCustomer = value;
            }
        }
        protected  void SetCustomerCookie(Guid customerGuid)
        {
            if (AppHttpContext.Current != null && AppHttpContext.Current.Response != null)
            {
                AppHttpContext.Current.Response.Cookies.Append(MyAuthorization.UserAuthenticationScheme, customerGuid.ToString(), new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(24 * 365)
                }); 
            }
        }
    }
}
