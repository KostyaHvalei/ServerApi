﻿using Entities.Models;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IFridgeRepository
	{
		IQueryable<Fridge> FindAll(bool trackChanges);
		IQueryable<Fridge> FindByCondition(Expression<Func<Fridge, bool>> expression, bool trackChanges);
		void Create(Fridge entity);
		void Update(Fridge entity);
		void Delete(Fridge entity);

		IEnumerable<Fridge> GetAllFridges(bool trackChanges);
		public Fridge GetFridge(Guid Id, bool trackChanges);
		public void CreateFridge(Fridge entity);
		public void AddProductToFridge(Guid fridgeId, Product product, int quantity);
		public void DeleteFridge(Fridge fridge);

		public (Guid firdgeId, Guid productId) GetFridgeProductWithZeroQuantity();
	}
}
