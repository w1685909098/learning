using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModel.Register;

namespace WebUI.Helper
{
    public static class CookieHelper
    {
        public static void AddCookie(int userId,string password/*, bool rememberMe = false*/)
        {
            HttpCookie cookie = new HttpCookie("user");
            cookie.Values.Add("id", userId.ToString());
            cookie.Values.Add("password", password);
            //if (rememberMe==true)
            //{
            //    cookie.Expires = DateTime.Now.AddDays(14);
            //}
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static void RemoveCookie(/*int userId, string password*/)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
            cookie.Expires = DateTime.Now.AddDays(-99);
            //cookie.Values.Clear();
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}