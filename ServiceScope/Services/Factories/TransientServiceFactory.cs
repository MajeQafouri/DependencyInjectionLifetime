using Microsoft.Extensions.DependencyInjection;
using ServiceScope.Models;
using System;

namespace ServiceScope.Services.Factories
{
    /// <summary>
    /// by https://www.linkedin.com/in/falamarzijahromi-mm
    /// </summary>
    public class TransientServiceFactory : ITransientServiceFactory
    {
        public IServiceProvider ServiceProvider { get; }

        public TransientServiceFactory(IServiceProvider serviceProvider)
            =>
            ServiceProvider = serviceProvider;
        

        public ITransientService GetTransientService() 
            =>
            ServiceProvider.GetService<ITransientService>();
    }

    public interface ITransientServiceFactory
    {
        ITransientService GetTransientService();
    }
}
