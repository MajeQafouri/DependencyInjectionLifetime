# DependencyInjectionLifetime
Understanding the lifetime of the services created using the Dependency injection is very essential, before starting to using them. Creating services without understanding the difference between Transient, Singleton &amp; Scoped lifetime can result in application behaving erratically. 


# Transient
The Transient services are always created new, each time the service is requested.

# Scoped
The Services with scoped lifetime are created only once per each request (scope). I.e. a new instance is created per request, and the instance is reused within that request.

# Singleton
Single Instance of the service is created when it was requested for the first time. After that for every subsequent request, it will use the same instance. The new request does not create the new instance of the service but reuses the instance already created


# Which one to use
Transient services are safest to create, as you always get the new instance. But, since they are created every time they will use more memory & Resources and can have the negative impact on performance if you too many of them.

Use Transient lifetime for the lightweight service with little or no state.

Scoped services service is the better option when you want to maintain state within a request.

Singletons are created only once and not destroyed until the end of the Application. Any memory leaks in these services will build up over time. Hence watch out for the memory leaks. Singletons are also memory efficient as they are created once reused everywhere.

Use Singletons where you need to maintain application wide state. Application configuration or parameters, Logging Service, caching of data is some of the examples where you can use singletons.
