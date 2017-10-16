using System.Linq;
using InteropDemo.Data.DataAccess;
using InteropDemo.Domain;
using InteropDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InteropDemo.Web.Controllers
{
	public class StudentController : Controller
	{
		private readonly IRepository<Student> _studentRepository;
		private readonly IRepository<Course> _courseRepository;

		public StudentController(IRepository<Student> studentRepository, IRepository<Course> courseRepository)
		{
			_studentRepository = studentRepository;
			_courseRepository = courseRepository;
		}

		public IActionResult Index()
		{
			var studentsViewModel = _studentRepository.GetAll().Select(s => new StudentViewModel
			{
				Id = s.Id,
				Name = s.Name,
				Email = s.Email,
				Phone = s.Phone,
				CourseId = s.CourseId
			}).ToList();

			foreach (var student in studentsViewModel)
			{
				var courseDb = _courseRepository.Get(student.CourseId);

				student.Course = new CourseViewModel
				{
					Id = courseDb.Id,
					Title = courseDb.Title,
					Description = courseDb.Description,
					Investment = courseDb.Investment,
					Room = courseDb.Room
				};
			}

			return View(studentsViewModel);
		}

		public ActionResult Create()
		{
			FillCourseList();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(StudentViewModel studentViewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(studentViewModel);

				var studentDb = new Student
				{
					Id = studentViewModel.Id,
					Name = studentViewModel.Name,
					Email = studentViewModel.Email,
					Phone = studentViewModel.Phone,
					CourseId = studentViewModel.CourseId
				};

				_studentRepository.Insert(studentDb);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int id)
		{
			var studentDb = _studentRepository.Get(id);

			if (studentDb == null)
				return RedirectToAction(nameof(Index));

			var studentViewModel = new StudentViewModel
			{
				Id = studentDb.Id,
				Name = studentDb.Name,
				Email = studentDb.Email,
				Phone = studentDb.Phone,
				CourseId = studentDb.CourseId
			};

			FillCourseList();

			return View(studentViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(StudentViewModel studentViewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(studentViewModel);

				var studentDb = _studentRepository.Get(studentViewModel.Id);
				studentDb.Name = studentViewModel.Name;
				studentDb.Phone = studentViewModel.Phone;
				studentDb.Email = studentViewModel.Email;
				studentDb.CourseId = studentViewModel.CourseId;

				_studentRepository.Update(studentDb);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(int id)
		{
			var studentDb = _studentRepository.Get(id);

			if (studentDb != null)
				_studentRepository.Delete(studentDb);

			return RedirectToAction(nameof(Index));
		}

		private void FillCourseList()
		{
			@ViewBag.CourseList = _courseRepository.GetAll().Select(c=> new CourseViewModel
			{
				Id = c.Id,
				Title = c.Title
			});
		}
	}
}