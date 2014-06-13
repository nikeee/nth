NTH library
===========

# Features

## Reduce noise

Extension methods help to reduce code noise.
```
string foo = "bar";
if(foo.IsNullOrEmpty())
// ...
// instead of
if(string.IsNullOrEmpty(foo))
// ...

string baz = " this is\n some text containing white space    	\t ";
var baz2 = baz.StripWhiteSpace(); // baz2 == "thisissometextcontainingwhitespace"
```

Also available:
```
foo.IsNullOrWhiteSpace();
foo.IsNullOrDBNull();
someChar.IsWhiteSpace();
```

`MathEx` extending the Math class:
```
MathEx.Max(1, 2, 3, 4, 5); // Using rest parameters
MathEx.Max(1, 2, 3); // If there are ony 3 parameters, an optimized version is used
// instead of
Math.Max(Math.Max(1, 2), 3);

// same for Min()
// available for int, long, float and double
```
A `Pow()` method for integers:
```
int @base = 2;
int exponent = 4;
int result = MathEx.Pow(@base, exponent);
// same for long
```

## Helper classes


### CommandLine

Using the CommandLine class, it is easier to handle command line arguments. Strings are automatically escaped and stuff.
The CommandLine class has a `FilePath` property and a `Arguments` property. The arguments property is of type `ArgumentList` which can be used separately.

```
static void Main(string[] argv)
{
	var newCommandLine = new CommandLine(@"C:\Demo.exe");
	newCommandLine.Arguments.Add("-n");
	newCommandLine.Arguments.Add("Some argument"); // will be automatically set in quotes

	// Start demo.exe with following command line:
	// C:\Demo.exe -n "some argument"
	ProcessEx.Start(newCommandLine);
	
	string commandLineString = newCommandLine.ToString();
	Console.WriteLine("Spawned process using command line:");
	Console.WriteLine(commandLineString);
	
	var parsedCommandLine = CommandLine.Parse(commandLineString); // Parsing functionality available


	Console.WriteLine("Current arguments:");
	var currentExecutable = CommandLine.Current.FilePath; // CommandLine.Current returns the command line of the current process
	foreach(var arg in CommandLine.Current.Arguments)
		Console.WriteLine(arg);
}
```

// TODO