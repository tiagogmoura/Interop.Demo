using System;
using System.Collections.Generic;
using System.Linq;
using InteropDemo.Data.Context;
using InteropDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace InteropDemo.Data.DataAccess
{
    public class Repository<T>: IRepository<T> where T : BaseEntity
    {
		private readonly InteropDemoContext _context;
		private readonly DbSet<T> _entities;

		public Repository(InteropDemoContext context)
		{
			this._context = context;
			_entities = context.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return _entities.AsEnumerable();
		}

		public T Get(int id)
		{
			return _entities.SingleOrDefault(s => s.Id == id);
		}

		public void Insert(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_entities.Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_context.Update(entity);
			_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_entities.Remove(entity);
			_context.SaveChanges();
		}
	}
}