using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
	public class FridgeProductsDTO
	{
		public string FridgeName { get; set; }
		IEnumerable<FridgeProductDTO> Products { get; set; }
	}
}
