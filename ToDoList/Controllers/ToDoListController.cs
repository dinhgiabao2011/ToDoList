using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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

		public IActionResult Update(int? Id)
		{
			var obj = _unitOfWork.ToDoes.Get(Id);
			if (Id == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int? Id, ToDo toDo)
		{
			if(toDo.Id != Id)
			{
				return NotFound();
			}
			if(ModelState.IsValid)
			{
				_context.ToDoes.Update(toDo);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(toDo);
		}

		[HttpGet]
		
		public IActionResult Delete(int? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}
			var obj = _context.ToDoes.FirstOrDefault(x => x.Id.Equals(Id));
			return View(obj);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> Confirm(int? Id)
		{
			var obj = _context.ToDoes.Find(Id);
			_context.ToDoes.Remove(obj);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

	}
}
