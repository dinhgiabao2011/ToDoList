using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;

namespace ToDoList.Controllers
{
	public class ToDoListController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ToDoListController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var obj = _context.ToDoes.ToList();
			return View(obj);
		}


	}
}
