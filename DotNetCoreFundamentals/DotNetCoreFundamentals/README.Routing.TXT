Routing is responsible for matching incoming HTTP requests and dispatching those requests to the app's executable endpoints.
Endpoints are the app's units of executable request-handling code.

Middlewares used:
	1.UseRouting 
		adds route matching to the middleware pipeline
	2.UseEndpoints
		adds endpoint execution(delegate) to the middleware pipeline
		Selected by matching the URL and HTTP method.
		Executed, by running the delegate.
For More details:https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-5.0