using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspNetWithAngular.Data;

namespace AspNetWithAngular.Controllers
{
    public class RepliesController : ApiController
    {
	    private IMessageBoardRepository _repository;

	    public RepliesController(IMessageBoardRepository repository)
	    {
		    _repository = repository;
	    }

		public IEnumerable<Reply> Get(int topicId)
		{
			return _repository.GetRepliesByTopic(topicId);
		}
    }
}
