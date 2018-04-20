using Autofac;
using Sample.Domain;
using Sample.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sample.Composition.Installers
{
    public class ManagerInstaller
    {
		private readonly ContainerOptions _options;

		public ManagerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var ServiceAssembly = typeof(Init).GetTypeInfo().Assembly;

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IManager).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
