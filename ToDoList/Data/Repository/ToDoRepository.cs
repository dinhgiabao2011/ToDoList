using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data.IRepository;
using ToDoList.Models;

namespace ToDoList.Data.Repository
{
	public class ToDoRepository : Repository<ToDo>, IToDoRepository
	{
		private readonly ApplicationDbContext _context;

		public ToDoRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public ToDo Get(int? Id)
		{
			return _context.Set<ToDo>().Find(Id);
		}

		public List<ToDo> ToDoGetAll()
		{
			return _context.ToDoes.ToList();
		}

		public new void Create(ToDo entity)
		{
			_context.ToDoes.Add(entity);
		}

		public new List<ToDo> GetAll()
		{
		  return _context.Set<ToDo>().ToList();
		}
	}
}
