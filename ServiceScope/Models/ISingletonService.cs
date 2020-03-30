using System;

namespace ServiceScope.Models
{ 
 
    public interface ISingletonService
    {
        ITransientService TransientService { get; set; }
        Guid GetID();
    }
}

