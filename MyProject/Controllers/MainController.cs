using System.Threading.Tasks;
using System.Web.Mvc;
using MyProject.Wrappers.ConfigurationManagerWrapper;
using MyProject.Wrappers.HttpClientWrapper;
using MyProject.Wrappers.MyProjectApi;

namespace MyProject.Controllers
{
    public class MainController : Controller
    {
        private readonly IMyProjectApi _projectApi;
        public MainController() : this(new MyProjectApi(new ConfigurationManagerWrapper(), new HttpClientWrapper())) {
            
        }

        public MainController(IMyProjectApi projectApi)
        {
            _projectApi = projectApi;
        }

        public async Task<ActionResult> Index()
        {
            var response = await _projectApi.GetAllBlogs();
            return View(response);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}