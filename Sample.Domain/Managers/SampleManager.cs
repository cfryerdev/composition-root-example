using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sample.Domain.Managers
{
	public class SampleManager : IManager
	{
		private IDbConnection Connection;

		public SampleManager(IDbConnection connection)
		{
			Connection = connection;
		}

		public string Get()
		{
			var contents = new StringBuilder();
			contents.AppendLine($"Resolved Correctly: { this.ToString() }");
			contents.AppendLine($"Resolved Correctly: { Connection.ToString() }");
			return contents.ToString();
		}
	}
}
