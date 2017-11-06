using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyProject.DTOs;
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

        // GET: Blog
        public async Task<ActionResult> Index()
        {
            var response = await _projectApi.GetAllBlogs();
            return View(response);
        }

        // GET: Blog/5
        public async Task<ActionResult> Details(int id)
        {
            var blog = await _projectApi.GetBlog(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
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

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BlogDto blog)
        {
            try
            {
                await _projectApi.CreateBlog(blog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var blog = await _projectApi.GetBlog(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BlogDto blog)
        {
            try
            {
                await _projectApi.UpdateBlog(id, blog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var blog = await _projectApi.GetBlog(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, FormCollection notUsed)
        {
            try
            {
                await _projectApi.DeleteBlog(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}