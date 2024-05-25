using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.Entities.Abstracts
{
	public class Entity
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; }=DateTime.Now;
		public DateTime UpdatedTime { get; set; }
	}
}
