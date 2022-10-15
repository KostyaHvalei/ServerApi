using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class FridgeModelRepository : RepositoryBase<FridgeModel>, IFridgeModelRepository
	{
		public FridgeModelRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}

		public IEnumerable<FridgeModel> GetAllFridgeModels(bool trackChanges) =>
			FindAll(trackChanges)
			.OrderBy(fm => fm.Name)
			.ToList();
	}
}
