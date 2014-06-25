NTH library
===========

# Features

## Reduce noise

Extension methods help to reduce code noise.
```C#
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
```C#
foo.IsNullOrWhiteSpace();
foo.IsNullOrDBNull();
someChar.IsWhiteSpace();
```

`MathEx` extending the Math class:
```C#
MathEx.Max(1, 2, 3, 4, 5); // Using rest parameters
MathEx.Max(1, 2, 3); // If there are ony 3 parameters, an optimized version is used
// instead of
Math.Max(Math.Max(1, 2), 3);

// same for Min()
// available for int, long, float and double
```
A `Pow()` method for integers:
```C#
int @base = 2;
int exponent = 4;
int result = MathEx.Pow(@base, exponent);
// same for long
```

## Helper classes


### CommandLine

Using the CommandLine class, it is easier to handle command line arguments. Strings are automatically escaped and stuff.
The CommandLine class has a `FilePath` property and a `Arguments` property. The arguments property is of type `ArgumentList` which can be used separately.

```C#
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

### .ToHexString()
There is a `.ToHexString()` extension method for `IntPtr` and `Int32`.
```C#
var pointer = new IntPtr(0xABCD);
var str = pointer.ToHexString(); // "0x0000ABCD" (if current application is running as a 32-bit process)
// The prefix can be excluded using an overload
// If You want a specific padding (e.g. for a 64 bit pointer), you can do this explicitly using an overload:
str = pointer.ToHexString(false, 8); // "000000000000ABCD"
```

### .ReverseBits()
Reverse the bit order of a byte value:
```C#
byte a = 0x1;
byte b = a.ReverseBits(); // 0b10000000
```

### .ConvertToStruct<T>();
Convert blob data (a byte array) to a typed struct instance.

```C#
[StructLayout(LayoutKind.Explicit)]
struct SomeStruct
{
	[FieldOffset(0)]
	public byte Field1;
	[FieldOffset(1)]
	public int Field2;
	[FieldOffset(5)]
	public float Field3;
}
// sizeof(SomeStruct) == 1 + 4 + 4 == 9 byte

byte[] blobData = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

SomeStruct instance = blobData.ConvertToStruct<SomeStruct>();

byte b = instance.Field1; // == 1
int c = instance.Field2; // == 0x05040302 (Little Endian and stuff)

```



// TODO
