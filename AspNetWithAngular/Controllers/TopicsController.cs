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

		public IEnumerable<Topic> Get(bool includeReplies = false)
		{
			IQueryable<Topic> results;
			if (includeReplies)
			{
				results = _repository.GetTopicsIncludingReplies();
			}
			else
			{
				results = _repository.GetTopics();
			}
			var topics = results
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