using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Data.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		IToDoRepository ToDoes { get; }

		void SaveChanges();
	}
}
