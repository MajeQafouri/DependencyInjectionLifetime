using ServiceScope.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceScope.Services
{
    public class ScopeService : IScopeService
    {
        private Guid _id;

        public ScopeService()
        {
            _id = Guid.NewGuid();
        }
        public Guid GetID()
        {
            return _id;
        } 
    }
}
