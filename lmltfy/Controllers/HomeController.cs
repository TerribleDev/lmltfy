using System.Linq;
using System.Web;
using System.Web.Mvc;
using lmltfy.Factories;
using lmltfy.Models;
using lmltfy.Util;

namespace lmltfy.Controllers
{
    public class HomeController : Controller
    {
        private lmltfyContext db = new lmltfyContext();

        [Route("")]
        [Route("h/{application}")]
        [OutputCache(Duration = int.MaxValue, Location = System.Web.UI.OutputCacheLocation.ServerAndClient, VaryByParam = "application")]
        public ActionResult Index(string application = AppNames.Lycos)
        {
            var app = application.ToAppEnum();
            if (!app.HasValue)
            {
                return new HttpStatusCodeResult(404);
            }
            return View(new ApplicationBrandingFactory().ResoleBrand(app.Value));
        }
       

        [HttpPost]
        [Route("")]
        public string Index([Bind(Include = "Search,Brand")] SearchModel searchModel)
        {
            searchModel.Url = new UrlGeneration().Generate();
            while (db.SearchModels.Any(a => a.Url == searchModel.Url))
            {
                searchModel.Url = new UrlGeneration().Generate();
            }
            if (!ModelState.IsValid) throw new HttpException(500, "Error parsing query");
            db.SearchModels.Add(searchModel);
            db.SaveChanges();
            return Url.Action("Search", "Home", new { url = searchModel.Url }, Request.Url.Scheme);
        }


        [HttpGet]
        [Route("{url}")]
        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.ServerAndClient, VaryByParam = "url")]             
        public ActionResult Search(string url)
        {
            var model = db.SearchModels.FirstOrDefault(a => a.Url == url);
            if (model == null)
            {
                return new HttpStatusCodeResult(404, "Not found");
            }
            
            return View(new SearchResultsViewModel(model, new UrlResolverFactory().UrlGenerate(model.Brand, model.Search), new ApplicationBrandingFactory().ResoleBrand(model.Brand)));
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