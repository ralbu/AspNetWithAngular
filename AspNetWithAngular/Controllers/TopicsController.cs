using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspNetWithAngular.Data;

namespace AspNetWithAngular.Controllers
{
    public class TopicsController : ApiController
    {
		private IMessageBoardRepository _repository;

	    public TopicsController(IMessageBoardRepository repository)
	    {
		    _repository = repository;
	    }

		public IEnumerable<Topic> Get()
		{
			var topics = _repository.GetTopics()
							 .OrderByDescending(t => t.Created)
							 .Take(25)
							 .ToList();
			return topics;
		}
    }
}
