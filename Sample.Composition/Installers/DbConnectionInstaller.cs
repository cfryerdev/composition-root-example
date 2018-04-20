using Autofac;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Sample.Composition.Installers
{
    public class DbConnectionInstaller
    {
		private readonly ContainerOptions _options;

		public DbConnectionInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var connection = new SqlConnection(_options.ConnectionString);
			builder
				.RegisterInstance<IDbConnection>(connection)
				.SingleInstance();
		}
	}
}
