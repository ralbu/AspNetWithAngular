using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWithAngular.Data
{
	public class MessageBoardRepository : IMessageBoardRepository
	{
		private MessageBoardContext _ctx;

		public MessageBoardRepository(MessageBoardContext ctx)
		{
			_ctx = ctx;
		}
		public IQueryable<Topic> GetTopics()
		{
			return _ctx.Topics;
		}

		public IQueryable<Reply> GetRepliesByTopic(int topicId)
		{
			return _ctx.Replies.Where(r => r.TopicId == topicId);
		}

		public bool Save()
		{
			try
			{
				return _ctx.SaveChanges() > 0;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool AddTopics(Topic newTopic)
		{
			try
			{
				_ctx.Topics.Add(newTopic);

				return true;
			}
			catch (Exception e)
			{
				
			}
		}
	}
}