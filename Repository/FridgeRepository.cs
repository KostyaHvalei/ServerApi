using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
	{
		public FridgeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		public IEnumerable<Fridge> GetAllFridges(bool trackChanges) =>
			FindAll(trackChanges)
			.Include(f => f.FridgeModel)
			.OrderBy(f => f.Name)
			.ToList();

		public Fridge GetFridge(Guid fridgeId, bool trackChanges) =>
			FindByCondition(f => f.Id.Equals(fridgeId), trackChanges).Include(f => f.Products).Include(f => f.FridgeModel).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).SingleOrDefault();

		public void CreateFridge(Fridge fridge) => Create(fridge);
	}
}
