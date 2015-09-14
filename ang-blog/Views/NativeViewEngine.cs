using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ang_blog.Views
{
    public class NativeViewEngine : RazorViewEngine
    {
        public NativeViewEngine()
        {
            ViewLocationFormats = new[] {
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx",
                "~/Views/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = ViewLocationFormats;

        }
    }
}