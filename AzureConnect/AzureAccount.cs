using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureConnect
{
	public class AzureAccount
	{
		public string tenantID { get; set; }
		public string id { get; set; }
		public string name { get; set; }
		public string state { get; set; }
		public AzureUser user { get; set; }
	}

	public class AzureUser
	{
		public string name { get; set; }
		public string type { get; set; }
	}

}
