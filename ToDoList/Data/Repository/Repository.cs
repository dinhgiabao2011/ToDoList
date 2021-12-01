using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data.IRepository;

namespace ToDoList.Data.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;

		public Repository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Create(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}
	}
}
