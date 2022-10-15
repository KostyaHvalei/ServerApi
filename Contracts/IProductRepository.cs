using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IProductRepository
	{
		IQueryable<Product> FindAll(bool trackChanges);
		IQueryable<Product> FindByCondition(Expression<Func<Product, bool>> expression, bool trackChanges);
		void Create(Product entity);
		void Update(Product entity);
		void Delete(Product entity);
	}
}
