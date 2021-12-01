using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Data.IRepository
{
	public interface IRepository<T> where T : class
	{
		List<T> GetAll();

		void Create(T entity);

		void Remove(T entity);
	}
}
