using InteropDemo.Data.DataAccess;
using InteropDemo.Domain;
using Microsoft.AspNetCore.Http;
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
		    var students = _studentRepository.GetAll();

		    foreach (var student in students)
		    {
			    student.Course = _courseRepository.Get(student.CourseId);
		    }

            return View(students);
        }

	    public ActionResult Create()
	    {
		    return View();
	    }

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public ActionResult Create(Student model)
	    {
		    try
		    {
			    if (!ModelState.IsValid)
				    return View(model);

			    _studentRepository.Insert(model);

			    return RedirectToAction(nameof(Index));
			}
			catch
		    {
			    return View();
		    }
	    }

	    public ActionResult Edit(int id)
	    {
		    var model = _studentRepository.Get(id);

			if (model == null)
				return RedirectToAction(nameof(Index));

			return View(model);
	    }

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public ActionResult Edit(Student model)
	    {
		    try
		    {
			    if (!ModelState.IsValid)
				    return View(model);

			    _studentRepository.Update(model);

				return RedirectToAction(nameof(Index));
		    }
		    catch
		    {
			    return View();
		    }
	    }

	    public ActionResult Delete(int id)
	    {
		    var model = _studentRepository.Get(id);

		    if (model != null)
			    _studentRepository.Delete(model);

		    return RedirectToAction(nameof(Index));
	    }
	}
}