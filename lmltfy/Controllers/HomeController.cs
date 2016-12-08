using System.Linq;
using System.Web;
using System.Web.Mvc;
using lmltfy.Factories;
using lmltfy.Models;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace lmltfy.Controllers
{
    public class HomeController : Controller
    {

        [Route("")]
        [Route("h/{application}")]
        [OutputCache(Duration = int.MaxValue, Location = System.Web.UI.OutputCacheLocation.ServerAndClient, VaryByParam = "application")]
        public ActionResult Index(string application = ApplicationBrand.Lycos)
        {
            if (ApplicationBrand.Brands.All(a => !a.Equals(application)))
            {
                return new HttpStatusCodeResult(404);
            }
            return View(new ApplicationBrandingFactory().ResoleBrand(application));
        }


        [HttpPost]
        [Route("")]
        public string Index([Bind(Include = "Search,Brand")] SearchModel searchModel)
        {
            searchModel.Url = new UrlGeneration().Generate();
            while (MvcApplication.azuredb.GetModelByKey(searchModel.Url) != null)
            {
                searchModel.Url = new UrlGeneration().Generate();
            }
            if (!ModelState.IsValid || !ApplicationBrand.Brands.Any(a => a.Equals(searchModel.Brand)))
            {
                throw new HttpException(500, "Error parsing query");
            }
            MvcApplication.azuredb.Save(new[] { searchModel });
            return Url.Action("Search", "Home", new { url = searchModel.Url }, "https");
        }


        [HttpGet]
        [Route("{url}")]
        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.ServerAndClient, VaryByParam = "url")]
        public ActionResult Search(string url)
        {
            var model = MvcApplication.azuredb.GetModelByKey(url);
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

            }
            base.Dispose(disposing);
        }
    }
}