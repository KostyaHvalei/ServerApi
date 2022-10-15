using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
	public class FridgeToCreationDTO
	{
		public string Name { get; set; }
		public string OwnerName { get; set; }
		public Guid FridgeModelId { get; set; }
	}
}
