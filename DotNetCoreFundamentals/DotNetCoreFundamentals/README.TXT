Main() method is entry point of the App
	It builds host and runs it.

Host:

Host is a capsule or place where program runs.
	1.Generic Host
	2.Web Host

Generic Host:
A host is an object that encapsulates an app's resources, such as:
	1.Dependency injection (DI)
	2.Logging
	3.Configuration
	4.IHostedService implementations

CreateDefaultBuilder() method does following things:
	1.Sets the content root to the path returned by GetCurrentDirectory.
	2.Loads host configuration from:
		1.Environment variables prefixed with DOTNET_.
		2.Command-line arguments.
	3.Loads app configuration
	4.Configures logging providers
	5.Enables scope validation and dependency validation when the environment is Development.

Framework-provided services
	1.IHostApplicationLifetime
	2.IHostLifetime(https://andrewlock.net/introducing-ihostlifetime-and-untangling-the-generic-host-startup-interactions/)
	3.IHostEnvironment / IWebHostEnvironment
		ApplicationName
			Key: applicationName
			Default: The name of the assembly that contains the app's entry point.
			Environment variable: <PREFIX_>APPLICATIONNAME
		EnvironmentName
			Key: environment
			Default: Production
			Environment variable: <PREFIX_>ENVIRONMENT
		ContentRootPath
			Key: contentRoot
			Default: The folder where the app assembly resides.
			Environment variable: <PREFIX_>CONTENTROOT

Host configuration
 Config related to host can be added through IHostBuilder.ConfigureHostConfiguration.
 Host configuration is available from HostBuilderContext.Configuration inside ConfigureAppConfiguration.
 After ConfigureAppConfiguration, HostBuilderContext.Configuration is replaced with the app config.


Web Host:
 ConfigureWebHostDefaults
	1.Loads host configuration from environment variables prefixed with ASPNETCORE_
	2.Sets Kestrel server as the web server
	3.Adds Host Filtering middleware.("AllowedHosts": "example.com;localhost")
	4.Adds Forwarded Headers middleware if ASPNETCORE_FORWARDEDHEADERS_ENABLED equals true.
	5.Enables IIS integration

Startup Class has following methods.
	1.Configures services
	2.Configures app's request pipeline.
 
  Rules & Limitations:
	1.Only following services can be injected to ctor of Startup class
		1.IWebHostEnvironment
		2.IHostEnvironment
		3.IConfiguration

	2.Multiple Startup. Startup{EnvNAme} class in picked @ runtime based on env name.
		Startup or StartupDevelopment or StartupStaging

	3.ConfigureServices Method.
		1.Optional
		2.called before the Configure method
		3.Addind service to DI container

	4.Configure Method
		1.To add middleware for app request

	5.Configure services without Startup
		1.Use methods of Hostbuilder
			if ConfigureServices or Configure is called multiple times. Last one will be taken
		2.User IStartupFilter to wrap the Configure method of Startup class. (Like iterating Linked List From IstartupFilter1 to Configure method) 


ASPNETCORE_ENVIRONMENT:
	used to set app's environment. 
	.Net Provided values 
		1.Development
		2.Production(default)
		3.Staging
	Any custom value is also applicable.
		Eg. Staging_1
	Places to mention env value:
	 1.launchSettings.json (value mentioned here will overrided value  from CLI)
	 2.while running app from CLI
	 3.Global env variable in OS level
	 4.web.config
				
  Environment name is used in following places:
	1.Startup class name. 
		Startup{EnvironmentName}
    1.Configure and ConfigureServices Methods
		Configure{EnvironmentName} and Configure{EnvironmentName}Services
	2.Appsettings.<EnvironmentName>.json
