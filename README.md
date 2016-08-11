# backend-test-dotnet-app
*.NET* solution to question one

####Technologies
+ Microsoft OWIN Security
+ ASP.NET Web Api 2
+ Entity Framework 6
+ SQL Server Express LocalDB 
+ Microsoft Test (MSTest) 

####Design

The overarching principal used in designing this solution is based on the well-known paradigm: **Keep it simple, not simpler**

It should not be built simpler*(read: stupid :-) )* such that best practices are not followed, incoherent coupling is ensued, and general planning has not taken place.

Rather, a design should be laid forth within which the near-future certainties are kept in mind and best practices(SOLID, DRY, etc) are implemented regardless of the size or complexity of the app.

####Architecture
That being said, our app design was made to be a two-layered system. The top-most being our api and the data-access layer underneath. 

While nothing complex was implemented such as dependency injection to swipe out data sources or access layer implementations or factory methods to facilitate more complex *todo* types, code within each layer/module was kept separated to deal with only its concern. Therefore, performing the previously mentioned design changes would be minimal and trivial.

The recommended approach working across layers is to work in 'slices'(either up-bottom or bottom-up) rather than by layer in order to experience any difficulties or barriers(especially regarding cross-cutting concerns such as caching, logging, authentication) beforehand and provide a solution before completing a full layer. Since time constraints did not permit, I was unable to do actual implementations of caching/logging and resorted to using demonstrated comments throughout the code. 

I believe keeping cross-cutting concerns regulated to separate modules is essential and an even better alternative to making direct calls in code is to use attributes such as those found in aspect-oriented programming.
