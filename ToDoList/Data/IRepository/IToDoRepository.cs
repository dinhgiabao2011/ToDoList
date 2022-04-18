using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Data.IRepository
{
	public interface IToDoRepository : IRepository<ToDo>
	{
		List<ToDo> ToDoGetAll();

		ToDo Get(int? Id);
	}
}
