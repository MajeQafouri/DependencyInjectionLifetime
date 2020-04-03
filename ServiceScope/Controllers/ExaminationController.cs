using System;
using Microsoft.AspNetCore.Mvc;
using ServiceScope.Models;
using ServiceScope.Services;

namespace ServiceScope.Controllers
{
    /// <summary>
    /// by https://www.linkedin.com/in/falamarzijahromi-mm
    /// </summary>
    [ApiController]
    [Route("[Controller]")]
    public class ExaminationController : Controller
    {
        private readonly IExaminationSingletonService singleton;
        private readonly IScopeService scopeService;
        private readonly ITransientService transient;

        public ExaminationController(
            IExaminationSingletonService singleton,
            IScopeService scopeService, ITransientService transient)
        {
            this.singleton = singleton;
            this.scopeService = scopeService;
            this.transient = transient;
        }

        public string GetLifestyleExamination()
        {
            var gottenScopeService = singleton.GetScopeService();
            var gottenTransientServcie = singleton.GetTransientService();

            return "Lifestyle Examination Result" + Environment.NewLine +
                   $"   gottenScopeService must be equal to the scopedService:" +
                   $"gottenScopeService.Equals(scopeService) = {gottenScopeService.Equals(scopeService)}" +
                   Environment.NewLine +
                   $"   gottenTransientServcie must not equal to the transientService" +
                   $"gottenTransientServcie.Equals(transient) = {gottenTransientServcie.Equals(transient)}";
        }
    }
}