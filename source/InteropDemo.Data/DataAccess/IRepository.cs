using System.Collections.Generic;
using InteropDemo.Domain;

namespace InteropDemo.Data.DataAccess
{
	public interface IRepository<T> where T : BaseEntity 
	{
		IEnumerable<T> GetAll();
		T Get(int id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
