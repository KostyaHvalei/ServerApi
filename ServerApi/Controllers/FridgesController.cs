using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Entities.DataTransferObjects;
using System.Collections.Generic;
using Entities.Models;

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

		[HttpGet("{id}", Name = "GetFridgeById")]
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

		[HttpPost]
		public IActionResult CreateFridge([FromBody] FridgeToCreationDTO fridge)
		{
			if (fridge == null)
			{
				_logger.LogError("FridgeModelToCreationDTO object sent from client is null");
				return BadRequest("FridgeModelToCreationDTO object in null");
			}

			var fridgeModel = _repository.FridgeModel.FindByCondition(model => model.Id == fridge.FridgeModelId, false).FirstOrDefault();

			if (fridgeModel == null)
			{
				_logger.LogError($"There is no fridge model with {fridge.FridgeModelId}");
				return BadRequest($"There is no fridge model with {fridge.FridgeModelId}");
			}

			Fridge fridge_to_create = new Fridge { Name = fridge.Name, OwnerName = fridge.OwnerName, FridgeModelId = fridge.FridgeModelId };
			_repository.Fridge.Create(fridge_to_create);
			_repository.Save();

			var fridgeDTO = new FridgeDTO { Id = fridge_to_create.Id, Name = fridge_to_create.Name, OwnerName = fridge_to_create.OwnerName, ModelName = fridgeModel.Name };

			return CreatedAtRoute("GetFridgeById", new { id = fridge_to_create.Id }, fridgeDTO);
		}
	}
}
