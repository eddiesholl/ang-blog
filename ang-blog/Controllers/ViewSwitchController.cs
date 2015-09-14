using ang_blog.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ang_blog.Controllers
{
    public class ViewSwitchController : Controller
    {
        public ActionResult ViewNative(string url)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new NativeViewEngine());

            return Redirect(url);
        }

        public ActionResult ViewAngular(string url)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new AngularViewEngine());

            return Redirect(url);
        }
    }
}