using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Data.IRepository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
	public class ToDoListController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;

		public ToDoListController(ApplicationDbContext context, IUnitOfWork unitOfWork)
		{
			_context = context;
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			var obj = _unitOfWork.ToDoes.ToDoGetAll();
			return View(obj);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(ToDo model)
		{
			if (ModelState.IsValid)
			{
				if (model.Id == 0)
				{
					_unitOfWork.ToDoes.Create(model);
					_unitOfWork.SaveChanges();
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}


	}
}
