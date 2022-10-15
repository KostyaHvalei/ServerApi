using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IFridgeModelRepository
	{
		IQueryable<FridgeModel> FindAll(bool trackChanges);
		IQueryable<FridgeModel> FindByCondition(Expression<Func<FridgeModel, bool>> expression, bool trackChanges);
		void Create(FridgeModel entity);
		void Update(FridgeModel entity);
		void Delete(FridgeModel entity);
	}
}
