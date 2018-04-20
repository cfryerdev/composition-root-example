using Autofac;
using Sample.Composition.Installers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Composition
{
	public class ContainerInstaller
	{
		private readonly ContainerOptions _options;

		public ContainerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public ContainerBuilder Install()
		{
			var builder = new ContainerBuilder();

			// These dependencies need to be in order from bottom of dependency graph to top
			// Example: Managers use a DBConnection, so we must register them before managers
			//          so the container can pre-construct the graph
			new DbConnectionInstaller(_options).Install(builder);
			new ManagerInstaller(_options).Install(builder);

			return builder;
		}
	}
}
