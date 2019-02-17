using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OdataCoreApi.Model;

namespace OdataCoreApi.Controllers
{
	[Route("OdataApi/[controller]")]
	[ApiController]
	public class OdataApiController : ODataController
	{
		// GET api/values
		[HttpGet]
		[Route("get")]
		[EnableQuery]
		public IEnumerable<Personne> Get()
		{
			return new List<Personne>
			{
				new Personne()
				{
					Nom="SAYAH",
					Prenom="Imad",
					Age=30
				},
				new Personne()
				{
					Nom="DIF",
					Prenom="Riad",
					Age=34
				},
				new Personne()
				{
					Nom="BECHE",
					Prenom="REDA",
					Age=27
				},
			};
		}

		// GET api/values/5
		[HttpGet()]
		[Route("getById")]
		public Personne Get(int id)
		{
			return
				new Personne()
				{
					Nom = "SAYAH",
					Prenom = "Imad",
					Age = 30
				};
		}

		// POST api/values
		[HttpPost]
		[Route("post")]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut()]
		[Route("put")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete()]
		[Route("delete")]
		public void Delete(int id)
		{
		}
	}
}
