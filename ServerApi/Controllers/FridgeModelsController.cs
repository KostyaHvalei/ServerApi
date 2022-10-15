using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ServerApi.Controllers
{
	[Route("api/models")]
	[ApiController]
	public class FridgeModelsController : ControllerBase
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;

		public FridgeModelsController(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetFridgeModels()
		{
			try
			{
				var fridgemodels = _repository.FridgeModel.GetAllFridgeModels(false);
				var fridgemodelsDTO = fridgemodels.Select(fm => new FridgeModelDTO
				{
					Id = fm.Id,
					Name = fm.Name,
					Year = fm.Year
				}).ToList();

				return Ok(fridgemodelsDTO);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in the {nameof(GetFridgeModels)} action {ex}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetFrigeModel(Guid id)
		{
			var fridgemodel = _repository.FridgeModel.GetFridgeModel(id, false);
			if(fridgemodel == null)
			{
				_logger.LogInfo($"Fridge with id {id} doesn't exists");
				return NotFound();
			}
			else
			{
				var fridgemodelDTO = new FridgeModelDTO { Id = fridgemodel.Id, Name = fridgemodel.Name, Year = fridgemodel.Year };
				return Ok(fridgemodelDTO);
			}
		}
	}
}
