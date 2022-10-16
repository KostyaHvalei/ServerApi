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

		public FridgeModel GetFridgeModel(Guid fridgeModelId, bool trackChanges) =>
			FindByCondition(fm => fm.Id.Equals(fridgeModelId), trackChanges).SingleOrDefault();

		public void CreateFridgeModel(FridgeModel fridgeModel) => Create(fridgeModel);

		public void DeleteFridgeModel(FridgeModel fridge) => Delete(fridge);
	}
}
