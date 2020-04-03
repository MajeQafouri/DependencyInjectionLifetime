using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServiceScope.Models;

namespace ServiceScope.Services.Factories
{
    /// <summary>
    /// by https://www.linkedin.com/in/falamarzijahromi-mm
    /// </summary>
    public interface IScopeServiceFactory
    {
        IScopeService GetScopeService();
    }

    public class ScopeServiceFactory : IScopeServiceFactory
    {
        public IServiceProvider ServiceProvider { get; }

        public ScopeServiceFactory(IServiceProvider serviceProvider)
            =>
            ServiceProvider = serviceProvider;

        public IScopeService GetScopeService()
        {
            var httpContext = ServiceProvider.GetService<IHttpContextAccessor>().HttpContext;

            return httpContext.RequestServices.GetService<IScopeService>();
        }
    }
}
