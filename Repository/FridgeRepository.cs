using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
	{
		private readonly RepositoryContext context;

		public FridgeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
			context = repositoryContext;
		}

		public IEnumerable<Fridge> GetAllFridges(bool trackChanges) =>
			FindAll(trackChanges)
			.Include(f => f.FridgeModel)
			.OrderBy(f => f.Name)
			.ToList();

		public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges) =>
			await FindAll(trackChanges)
			.Include(f => f.FridgeModel)
			.OrderBy(f => f.Name)
			.ToListAsync();

		public Fridge GetFridge(Guid fridgeId, bool trackChanges) =>
			FindByCondition(f => f.Id.Equals(fridgeId), trackChanges).Include(f => f.Products).Include(f => f.FridgeModel).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).SingleOrDefault();

		public async Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges) =>
			await FindByCondition(f => f.Id.Equals(fridgeId), trackChanges).Include(f => f.Products).Include(f => f.FridgeModel).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).SingleOrDefaultAsync();

		public void AddProductToFridge(Guid fridgeId, Product product, int quantity)
		{
			//Maybe trackChanges
			var fridge = FindByCondition(f => f.Id == fridgeId, true).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).FirstOrDefault();

			var fp = fridge.FridgeProducts.Find(fp => fp.FridgeId == fridge.Id && fp.ProductId == product.Id);

			if (fp != null)
			{
				if(fp.Quantity + quantity > 0)
				{
					fp.Quantity += quantity;
					Update(fridge);
					context.SaveChanges();
				}
				else if(fp.Quantity + quantity == 0)
				{
					fridge.Products.Remove(product);
					Update(fridge);
					context.SaveChanges();
				}
				else
				{
					throw new ArgumentException("Quantity can't be less then zero");
				}
			}
			else
			{
				var frigeProduct = new FridgeProduct { Fridge = fridge, FridgeId = fridge.Id, Product = product, ProductId = product.Id, Quantity = quantity };
				fridge.FridgeProducts.Add(frigeProduct);
				Update(fridge);
				context.SaveChanges();
			}
		}

		public async Task AddProductToFridgeAsync(Guid fridgeId, Product product, int quantity)
		{
			var fridge = await FindByCondition(f => f.Id == fridgeId, true).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).FirstOrDefaultAsync();

			var fp = fridge.FridgeProducts.Find(fp => fp.FridgeId == fridge.Id && fp.ProductId == product.Id);

			if (fp != null)
			{
				if (fp.Quantity + quantity > 0)
				{
					fp.Quantity += quantity;
					Update(fridge);
					await context.SaveChangesAsync();
				}
				else if (fp.Quantity + quantity == 0)
				{
					fridge.Products.Remove(product);
					Update(fridge);
					await context.SaveChangesAsync();
				}
				else
				{
					throw new ArgumentException("Quantity can't be less then zero");
				}
			}
			else
			{
				var frigeProduct = new FridgeProduct { Fridge = fridge, FridgeId = fridge.Id, Product = product, ProductId = product.Id, Quantity = quantity };
				fridge.FridgeProducts.Add(frigeProduct);
				Update(fridge);
				await context.SaveChangesAsync();
			}
		}

		public void RemoveProductFromFridge(Guid fridgeId, Guid productId)
		{
			var fridge = FindByCondition(f => f.Id == fridgeId, true).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).FirstOrDefault();
			if (fridge == null)
				throw new ArgumentException($"There is no fridge with this id {fridgeId}");

			var product = fridge.Products.FirstOrDefault(p => p.Id == productId);
			if(product == null)
				throw new ArgumentException($"There is no product in this fridge with this id {productId}");

			fridge.Products.Remove(product);
			context.SaveChanges();
		}

		public async Task RemoveProductFromFridgeAsync(Guid fridgeId, Guid productId)
		{
			var fridge = await FindByCondition(f => f.Id == fridgeId, true).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).FirstOrDefaultAsync();
			if (fridge == null)
				throw new ArgumentException($"There is no fridge with this id {fridgeId}");

			var product = fridge.Products.FirstOrDefault(p => p.Id == productId);
			if (product == null)
				throw new ArgumentException($"There is no product in this fridge with this id {productId}");

			fridge.Products.Remove(product);
			await context.SaveChangesAsync();
		}

		public (Guid firdgeId, Guid productId) GetFridgeProductWithZeroQuantity()
		{
			var parameter = new List<SqlParameter>();
			parameter.Add(
				new SqlParameter
				{
					ParameterName = "@productId",
					DbType = DbType.Guid,
					Direction = ParameterDirection.Output
				});
			parameter.Add(
				new SqlParameter
				{
					ParameterName = "@fridgeId",
					DbType = DbType.Guid,
					Direction = ParameterDirection.Output
				});
			parameter.Add(
				new SqlParameter
				{
					ParameterName = "@status",
					DbType = DbType.Boolean,
					Direction = ParameterDirection.Output
				});

			var result = context.Database.ExecuteSqlRaw(@"exec GetFridgeProductWithZeroQuantity
											@productId OUT, @fridgeId OUT, @status OUT", parameter.ToArray());

			bool status = bool.Parse(parameter[2].Value.ToString());
			if (status)
			{
				Guid prodId = Guid.Parse(parameter[0].Value.ToString());
				Guid fridId = Guid.Parse(parameter[1].Value.ToString());
				return (prodId, fridId);
			}
			else
				return (Guid.Empty, Guid.Empty);
		}

		public async Task<(Guid firdgeId, Guid productId)> GetFridgeProductWithZeroQuantityAsync()
		{
			var parameter = new List<SqlParameter>();
			parameter.Add(
				new SqlParameter
				{
					ParameterName = "@productId",
					DbType = DbType.Guid,
					Direction = ParameterDirection.Output
				});
			parameter.Add(
				new SqlParameter
				{
					ParameterName = "@fridgeId",
					DbType = DbType.Guid,
					Direction = ParameterDirection.Output
				});
			parameter.Add(
				new SqlParameter
				{
					ParameterName = "@status",
					DbType = DbType.Boolean,
					Direction = ParameterDirection.Output
				});

			var result = await context.Database.ExecuteSqlRawAsync(@"exec GetFridgeProductWithZeroQuantity
											@productId OUT, @fridgeId OUT, @status OUT", parameter.ToArray());

			bool status = bool.Parse(parameter[2].Value.ToString());
			if (status)
			{
				Guid prodId = Guid.Parse(parameter[0].Value.ToString());
				Guid fridId = Guid.Parse(parameter[1].Value.ToString());
				return (prodId, fridId);
			}
			else
				return (Guid.Empty, Guid.Empty);
		}

		public void CreateFridge(Fridge fridge) => Create(fridge);

		public void DeleteFridge(Fridge fridge) => Delete(fridge);
	}
}
