using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Entities.DataTransferObjects;

namespace ServerApi.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;

		public ProductsController(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetProducts()
		{
			try
			{
				var products = _repository.Product.GetAllProducts(false);
				var productsDTO = products.Select(p => new ProductDTO
				{
					Id = p.Id,
					Name = p.Name,
					DefaultQuantity = p.DefaultQuantity
				}).ToList();

				return Ok(productsDTO);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in the {nameof(GetProducts)} action {ex}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetProduct(Guid id)
		{
			var product = _repository.Product.GetProduct(id, false);
			if (product == null)
			{
				_logger.LogInfo($"Product with id {id} doesn't exists");
				return NotFound();
			}
			else
			{
				var productDTO = new ProductDTO { Id = product.Id, Name = product.Name, DefaultQuantity = product.DefaultQuantity };
				return Ok(productDTO);
			}
		}
	}


}
