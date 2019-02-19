using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataCoreApi.Model
{
	public class Personne
	{
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public int Age { get; set; }
	}
}
