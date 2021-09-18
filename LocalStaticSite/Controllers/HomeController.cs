using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LocalStaticSite.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment env;
        public HomeController(IWebHostEnvironment _env)
        {

            env = _env;
        }
        public IActionResult Index()
        {
            var rootPath = env.WebRootPath;
            string path = Path.Combine(rootPath, "Download/");
            var list = System.IO.Directory.GetFiles(path).ToList();
            for (int i = 0; i < list.Count; i++)
            {
               list[i]= Path.GetFileName(list[i]);
            }

            return View(list);
        }
        public IActionResult Download(string filename) {
             
            return Redirect("/Download/"+ filename);
        }
    }
}
