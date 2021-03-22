
IConfigurationBuilder -  used to add different providers
IConfigurationRoot - Used to access configuration values across diff config builder

The configuration can be mapped to instances of objects, and later provided as IOptions<TOptions> through dependency injection.

Type of Configuration Provider :
	1.File(JSON,XML,INI)
	2.Environment variable 
	3.Command-line
	4.Key-per-file
	5.Memory configuration

 1.File Config Provider
	Sources : JSON,XML,INI
		Way to access heirarchial config Key: "section:section0:key:key0"

 2.Environment Variable:
 	This will be loaded after File provider & Secret manager. 

	Source: System,launchSettings.json
		launchSettings.json override those set in the system environment.
		Way to access heirarchial config Key: "section__section0__key__key0"

	can be set from .NET CLI(before running app using "dotnet run" cmd)

	
	Prefix:
		Can have prefix in config key. which will not be considered while reading in code
		 Eg:
			set CustomPrefix__SecretKey="Secret key with CustomPrefix_ environment"
			set CustomPrefix__TransientFaultHandlingOptions__Enabled=true
			set CustomPrefix__TransientFaultHandlingOptions__AutoRetryDelay=00:00:21

	Connection string prefixes:
		1.CUSTOMCONNSTR_
		2.MYSQLCONNSTR_
		3.SQLAZURECONNSTR_
		4.SQLCONNSTR_ (SQL Server)
	If any env variable is found with any of the above prefix then it will be interpreted as connectionstring.
	added under "ConnectionStrings" section of configurationroot object

 3.Command-line configuration provider
	Passing value to Main(str[]) method while running apps
	Eg.
		dotnet run SecretKey="Secret key from command line"
		dotnet run /SecretKey "Secret key set from forward slash"
		dotnet run --SecretKey "Secret key set from double hyphen"

 4.Key-per-file configuration provider
	Source:File
		Way to access heirarchial config Key: "section__section0__key__key0"
	uses a directory's files as configuration key-value pairs.
	Key=Filename
	Value=FileContent
 
 5.Memory configuration provider
	Source:in-memory collection


Any config can me loaded in to object by following Options pattern.
	Options class should be public non-abstract class
	1.IOptions<> - singleton,doesn't support reading  config after application starts
	2.IOptionsSnapshot<> - scoped,Reloadable configuration
	3.IOptionsMonitor<> - Singleton,Reloadable configuration(read updated config data) ,Change notifications
