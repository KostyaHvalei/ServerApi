using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
	public class ProductToAddInFridgeDTO
	{
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
