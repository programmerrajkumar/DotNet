


Dependency injection guidelines
	if class has many injected dependencies,then it voilates SRP

	Disposal of services
		1.container is responsible for cleanup of types it creates
		2.container is not responsible for cleanup of types which is not created by container.So developer has to handle it
			Eg.services.AddSingleton(new ExampleService());
		3. Transient services would be holded by container throughout it's lifetime. So create it either with USING statement or under scoped service
		4.Avoid Captive dependency-where a longer-lived service holds a shorter-lived service captive
			Eg.Singleton holding reference to scoped or transient object
		5.Scoped service becomes singleton if service is resolved outside of scope. 