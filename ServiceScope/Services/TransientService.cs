using ServiceScope.Models;
using System;

namespace ServiceScope.Services
{
    public class TransientService : ITransientService
    {
        private Guid _id;
        public TransientService()
        {
            _id = Guid.NewGuid();
        }
        public Guid GetID()
        {
            return _id;
        }
    }
}
