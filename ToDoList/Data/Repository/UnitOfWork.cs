using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data.IRepository;

namespace ToDoList.Data.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public IToDoRepository ToDoes { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			ToDoes = new ToDoRepository(_context);
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
