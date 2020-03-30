using ServiceScope.Models;
using System;

namespace ServiceScope.Services
{
    public class SingletonService : ISingletonService
    {
        private Guid _id;
        public ITransientService TransientService{get;set;}

        public SingletonService(ITransientService transientService)
        {
            _id = Guid.NewGuid();
            TransientService = transientService;
        }
        public Guid GetID()
        {
            return _id;
        }
    }
}
