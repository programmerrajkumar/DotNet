Middleware is component used to handle request and response. 
Similar to Httpmodule and HttpHandler in ASP.NET
Multiple middleware can be chained(like linked list) and atlast the request is processed and served to client.

Each middleware can either pass the responsibilty to other middleware in the chain or terminate the chain and give response to client.
Can perform work before and after the next component in the chain.
Middleware can be configure using reusable classes or in-line anonymous methods like	
	1.Use
	2.Map
	3.Run(Termination middleware)
Types:
	1.Conventional Middleware
		Middleware is constructed at app startup, not per-request. So pass scoped variable to Invoke method which has DI support
	2.Factory Activated Middleware
		Activation per client request (injection of scoped services)
		Strong typing of middleware