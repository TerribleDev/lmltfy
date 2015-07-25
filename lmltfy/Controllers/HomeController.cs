using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CsQuery;
using lmltfy.Models;
using lmltfy.Factories;
namespace lmltfy.Controllers
{
    public class HomeController : Controller
    {
        private lmltfyContext db = new lmltfyContext();
        private Regex reg = new Regex(@"(\$\('#keyvol'\).val\('(?<key>.*)\'\)\;)", RegexOptions.Compiled);
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
       

        [HttpPost]
        [Route("")]
        public string Index([Bind(Include = "Search")] SearchModel searchModel)
        {
            searchModel.Url = new UrlGeneration().Generate();
            while (db.SearchModels.Any(a => a.Url == searchModel.Url))
            {
                searchModel.Url = new UrlGeneration().Generate();
            }

            db.SearchModels.Add(searchModel);
            db.SaveChanges();
            return Url.Action("Search", "Home", new { url = searchModel.Url}, Request.Url.Scheme);
        }


        [HttpGet]
        [Route("{url}")]
        public ActionResult Search(string url)
        {
            var model = db.SearchModels.FirstOrDefault(a => a.Url == url);
            if(model == null)
            {
                return new HttpStatusCodeResult(404, "Not found");
            }
            WebClient client = new WebClient();
            string downloadString = client.DownloadString("http://lycos.com");
            var key = reg.Match(downloadString).Groups["key"].Value;
            return View(new SearchResultsViewModel(model, key));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}