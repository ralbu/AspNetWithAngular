using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace AspNetWithAngular.Data
{
	public class MessageBoardMigrationsConfiguration : DbMigrationsConfiguration<MessageBoardContext>
	{
		public MessageBoardMigrationsConfiguration()
		{
			this.AutomaticMigrationDataLossAllowed = true;
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(MessageBoardContext context)
		{
			base.Seed(context);

#if	DEBUG
			if (context.Topics.Count() == 0)
			{
				var topic = new Topic
					{
						Title = "Title",
						Created = DateTime.Now,
						Body = "Some body",
						Replies = new List<Reply>
							{
								new Reply
									{
										Body = "first reply",
										Created = DateTime.Now
									},
								new Reply
									{
										Body = "second reply",
										Created = DateTime.Now
									}
							}
					};

				context.Topics.Add(topic);
			}
#endif

		}
	}
}
