using InteropDemo.Data.DataAccess;
using InteropDemo.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InteropDemo.Web.Controllers
{
	public class CourseController : Controller
	{
		private readonly IRepository<Course> _courseRepository;

		public CourseController(IRepository<Course> courseRepository)
		{
			this._courseRepository = courseRepository;
		}

		public ActionResult Index()
		{
			var courses = _courseRepository.GetAll();
			return View(courses);
		}

		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Course model)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model);

				_courseRepository.Insert(model);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(model);
			}
		}

		public ActionResult Edit(int id)
		{
			var model = _courseRepository.Get(id);

			if (model == null)
				return RedirectToAction(nameof(Index));

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Course model)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model);

				_courseRepository.Update(model);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
		
		public ActionResult Delete(int id)
		{
			var model = _courseRepository.Get(id);

			if (model != null)
				_courseRepository.Delete(model);

			return RedirectToAction(nameof(Index));
		}
	}
}