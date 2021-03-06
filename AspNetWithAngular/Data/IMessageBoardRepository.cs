﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWithAngular.Data
{
	public interface IMessageBoardRepository
	{
		IQueryable<Topic> GetTopics();
		IQueryable<Topic> GetTopicsIncludingReplies();
		IQueryable<Reply> GetRepliesByTopic(int topicId);

		bool Save();
		bool AddTopics(Topic newTopic);
		bool AddReply(Reply reply);

	}
}
