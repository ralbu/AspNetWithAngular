﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWithAngular.Data
{
	public class Topic
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime Created { get; set; }
		public int Id { get; set; }
		public bool Flagged { get; set; }

		public ICollection<Reply> Replies { get; set; }
	}
}