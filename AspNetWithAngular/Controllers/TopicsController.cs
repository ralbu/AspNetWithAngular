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

		public HttpResponseMessage Post([FromBody] Topic newTopic)
		{

			if (newTopic.Created == default(DateTime))
			{
				newTopic.Created = DateTime.UtcNow;
			}

			if (_repository.AddTopics(newTopic) &&
			    _repository.Save())
			{
				return Request.CreateResponse(HttpStatusCode.Created, newTopic);

			}

			return Request.CreateResponse(HttpStatusCode.BadRequest);
		}

	}
}