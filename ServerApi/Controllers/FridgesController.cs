using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Entities.DataTransferObjects;
using System.Collections.Generic;

namespace ServerApi.Controllers
{
	[Route("api/fridges")]
	[ApiController]
	public class FridgesController : ControllerBase
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;

		public FridgesController(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetFridges()
		{
			try
			{
				var fridges = _repository.Fridge.GetAllFridges(false);

				var fridgesDTO = fridges.Select(f => new FridgeDTO
				{
					Id = f.Id,
					Name = f.Name,
					OwnerName = f.OwnerName,
					ModelName = f.FridgeModel.Name
				}).ToList();

				return Ok(fridgesDTO);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in the {nameof(GetFridges)} action {ex}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetFrige(Guid id)
		{
			var fridge = _repository.Fridge.GetFridge(id, false);
			if (fridge == null)
			{
				_logger.LogInfo($"Fridge with id {id} doesn't exists");
				return NotFound();
			}
			else
			{
				var fridgeDTO = new FridgeProductsDTO
				{
					FridgeId = fridge.Id,
					FridgeName = fridge.Name,
					ModelName = fridge.FridgeModel.Name,
					OwnerName = fridge.OwnerName,
					Products = fridge.FridgeProducts.Select(fp => new FridgeProductDTO { ProductId = fp.Id, ProductName = fp.Product.Name, Quantity = fp.Quantity })
				};
				return Ok(fridgeDTO);
			}
		}
	}
}
