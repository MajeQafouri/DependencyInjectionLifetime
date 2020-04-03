using Microsoft.AspNetCore.Mvc;
using ServiceScope.Models;

namespace ServiceScope.Controllers
{
    /// <summary>
    /// by https://www.linkedin.com/in/majid-qafouri/
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ISingletonService singletonService1;
        private readonly ISingletonService singletonService2;

        private readonly ITransientService transientService1;
        private readonly ITransientService transientService2;

        private readonly IScopeService scopedService1;
        private readonly IScopeService scopedService2;

        public HomeController(ISingletonService singletonService1,
            ISingletonService singletonService2,
            ITransientService transientService1,
            ITransientService transientService2,
            IScopeService scopedService1,
            IScopeService scopedService2)
        {
            this.singletonService1 = singletonService1;
            this.singletonService2 = singletonService2;

            this.transientService1 = transientService1;
            this.transientService2 = transientService2;

            this.scopedService1 = scopedService1;
            this.scopedService2 = scopedService2;
        }
        public IActionResult Index()
        {
            var singleton1 = singletonService1.GetID();
            var singleton2 = singletonService2.GetID();
            var singletonValueIsEqual = singleton1 == singleton2;

            //Injecting service with different lifetimes into another
            
            /* When the request comes for the first time a new instance of the singleton is created. 
             It also creates a new instance of the transient object and injects into the Singleton service.

             When the second request arrives the instance of the singleton is reused. 
             The singleton already contains the instance of the transient service Hence it is not created again. 
             This effectively converts the transient service into the singleton */
            var innerServices = singletonService1.TransientService.GetID() == singletonService2.TransientService.GetID();

            var scoped1 = scopedService1.GetID();
            var scoped2 = scopedService2.GetID();
            var scopedValueIsEqual = scoped1 == scoped2;

            var transient1 = transientService1.GetID();
            var transient2 = transientService2.GetID();
            var transientValueIsEqual = transient1 == transient2;
             

            //set viewdatat values
            SetViewData("singletonService1", singleton1);
            SetViewData("singletonService2", singleton2);
            SetViewData("singleton_Inner_Transiet_Service1", singletonService1.TransientService.GetID());
            SetViewData("singleton_Inner_Transiet_Service2", singletonService2.TransientService.GetID());

            SetViewData("scopedService1", scoped1);
            SetViewData("scopedService2", scoped2);

            SetViewData("TransientService1", transient1);
            SetViewData("TransientService2", transient2);

            return View();
        }

        private void SetViewData(string key, object value)
        {
            ViewData[key] = value;
        }
         
    }
}

