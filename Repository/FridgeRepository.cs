﻿using Contracts;
using Entities;
using Entities.DataTransferObjects;
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

		public void AddProductToFridge(Guid fridgeId, Product product, int quantity)
		{
			//Maybe trackChanges
			var fridge = FindByCondition(f => f.Id == fridgeId, false).Include(f => f.FridgeProducts).ThenInclude(fp => fp.Product).FirstOrDefault();

			var fp = fridge.FridgeProducts.Find(fp => fp.FridgeId == fridge.Id && fp.ProductId == product.Id);

			if (fp != null)
			{
				if(fp.Quantity + quantity >= 0)
					fp.Quantity += quantity;
				else
				{
					fridge.Products.Remove(product);
					fridge.FridgeProducts.Remove(fp);
					Update(fridge);
				}
			}
			else
			{
				var frigeProduct = new FridgeProduct { Fridge = fridge, FridgeId = fridge.Id, Product = product, ProductId = product.Id, Quantity = quantity };
				fridge.Products.Add(product);
				fridge.FridgeProducts.Add(frigeProduct);
			}
			
			Update(fridge);
		}

		public void DeleteFridge(Fridge fridge) => Delete(fridge);
	}
}
