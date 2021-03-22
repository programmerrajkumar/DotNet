Reference  : https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-5.0

Dot Net Core provides many inbuilt synchronous logger.

Logging providers:

	1.Console - Console.WriteLine
	2.Debug - System.Diagnostics.Debug.WriteLine
	3.EventSource - cross-platform logger (Microsoft-Extensions-Logging) (use dotnet trace or Perfview tools to get logs from app)
	4.EventLog: Windows only

	CreateDefaultBuilder() - which adds the above mentioned logging providers

Log level:

	1.Trace					-   0
	2.Debug					-   1
	3.Information			-   2(Default)
	4.Warning				-   3
	5.Error					-   4
	6.Critical				-   5
	7.None					-   6

	call Logger.Log{LogLevel}()


Create logs:

	Create Log Using  ILogger interface with generic parameter.generic parameter type is used a Log Category
	ILogger<TCategoryName>
	TCategoryName - fully qualified name of the type

	or 

	User ILoggerFactory interface with explicit Category Name.
	ILoggerFactory.CreateLogger("OrderCreationLogs")

	ILogger<T> = ILoggerFactory.CreateLogger(FullyQualifiedName Of T)


Configure logging:

	Logging configuration is commonly provided by the Logging section of appsettings.{Environment}.json files 
	or through Code

	1.Logging:LogLevel:{Category}                   - Base
	2.Logging:{ProviderName}:LogLevel:{Category}    - Derived

	Settings in 2 override settings in 1
	 Ex : Debug.LogLevel.Default overrides the level in LogLevel.Default

	LogLevel - Information (Default)
    LogLevel - minimum level(logging is enabled for messages at the specified level and higher)

	Warning -> 3 to 6
	None - 6 to 6 (Suppress)


Filtering Rules:
	
	1.Search for config with Provider. If null then take empty provider config
	2.Search fro longest matching Category prefix. If null take rule that don't specify a category.
	3.If multiple rules are selected, take the last one.
	4.If no rules are selected, use MinimumLevel.


Set log level:
	
	Use double underscore '__' sepertor instead of ':'(not supported in all platforms)

	1.command line: sets the env key
		set Logging__LogLevel__Microsoft=Information
		dotnet run
	2.environment variables
	3.any of the configuration providers.



Log event ID : 

     Another level of grouping after Category

	 _logger.LogInformation(1000, "Getting Item");

	 o/p
	 Namespace.ClassName[1000]
     Getting item


Log scopes:
	
	used to attach the same data to each log that's created as part of a same scope
	  Ex : every log created as part of placing a order can have order ID in those log


Log message template:
	
	order of the parameters, not their placeholder names. 
	Palceholder names can be used by logger provider, not for string format

	_logger.LogInformation("Parameters: {pears}, {bananas}, {apples}", apples, pears, bananas);

	o/p :Parameters: 1, 2, 3



Limitation:


Writing logs before completion of the DI container setup in the Startup.ConfigureServices method is not supported:

	1.Logger injection into the Startup constructor is not supported.
	2.Logger injection into the Startup.ConfigureServices method signature is not supported

No asynchronous logger methods
	
	performance cost of asynchronous code

	when logging to SQL(or other time consuming place), log to in-memory queue and  add background task to pull logs from queue to sql


Custom Logger:

	ILogger 
	ILoggerProvider(Factory for ILogger)
	ILoggerBuilder(Factory for ILoggerProvider)