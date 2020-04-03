using ServiceScope.Models;
using ServiceScope.Services.Factories;

namespace ServiceScope.Services
{
    /// <summary>
    /// by https://www.linkedin.com/in/falamarzijahromi-mm
    /// </summary>
    public class ExaminationSingletonService : IExaminationSingletonService
    {
        private readonly IScopeServiceFactory scopeServiceFactory;
        private readonly ITransientServiceFactory transientServiceFactory;

        public ExaminationSingletonService(
            IScopeServiceFactory scopeServiceFactory, ITransientServiceFactory transientServiceFactory)
        {
            this.scopeServiceFactory = scopeServiceFactory;
            this.transientServiceFactory = transientServiceFactory;
        }

        public IScopeService GetScopeService()
            =>
            scopeServiceFactory.GetScopeService();



        public ITransientService GetTransientService()
            =>
            transientServiceFactory.GetTransientService();
    }

    public interface IExaminationSingletonService
    {
        IScopeService GetScopeService();
        ITransientService GetTransientService();
    }
}
