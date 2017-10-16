using System.Linq;
using InteropDemo.Data.DataAccess;
using InteropDemo.Domain;
using InteropDemo.Web.Models;
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
			var coursesViewModel = _courseRepository.GetAll().Select(c=> new CourseViewModel
			{
				Id = c.Id,
				Title = c.Title,
				Description = c.Description,
				Investment = c.Investment,
				Room = c.Room
			});

			return View(coursesViewModel);
		}

		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CourseViewModel courseViewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(courseViewModel);

				var courseDb = new Course
				{
					Title = courseViewModel.Title,
					Description = courseViewModel.Description,
					Investment = courseViewModel.Investment,
					Room = courseViewModel.Room
				};

				_courseRepository.Insert(courseDb);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(courseViewModel);
			}
		}

		public ActionResult Edit(int id)
		{
			var courseDb = _courseRepository.Get(id);

			if (courseDb == null)
				return RedirectToAction(nameof(Index));

			var courseViewModel = new CourseViewModel
			{				
				Id = courseDb.Id,
				Title = courseDb.Title,
				Description = courseDb.Description,
				Investment = courseDb.Investment,
				Room = courseDb.Room
			};

			return View(courseViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CourseViewModel courseViewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(courseViewModel);

				var courseDb = _courseRepository.Get(courseViewModel.Id);
				courseDb.Title = courseViewModel.Title;
				courseDb.Description = courseViewModel.Description;
				courseDb.Investment = courseViewModel.Investment;
				courseDb.Room = courseViewModel.Room;

				_courseRepository.Update(courseDb);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
		
		public ActionResult Delete(int id)
		{
			var courseDb = _courseRepository.Get(id);

			if (courseDb != null)
				_courseRepository.Delete(courseDb);

			return RedirectToAction(nameof(Index));
		}
	}
}