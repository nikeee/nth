NTH library
===========
## Contents
1. [Documentation](#documentation)
2. [Compatibility](#compatibility)
3. [NuGet](#nuget)
4. [Features](#features)
    1. [Reduce Noise](#reduce-noise)
    2. [CommandLine Class](#commandline)
    3. [.ToHexString()](#tohexstring)
    4. [.ReverseBits()](#reversebits)
    5. [.ConvertToStruct&lt;T&gt;()](#converttostructt)
    6. [ByteSize Class](#bytesize)
    7. [Levenshtein Distance](#levenshtein-distance)
    8. [ConsoleEx](#consoleex)
    9. [BitUtil](#bitutil)
    10. [NewLine Operations](#newline-operations)
    11. [Unix Time Extensions](#unix-time-extensions)
    12. [Hashing Shortcuts](#hashing-shortcuts)

## Documentation
The NTH library is documented [here](https://nikeee.github.io/nth). Also you can find several code annotations in the [source code](https://github.com/nikeee/nth/tree/master/src) using C#'s XML documentation style.

## Compatibility
Currently, the NTH library can be used with .NET `4.0` (+ Client Profile), `4.5`, `4.5.1` and `4.5.2`. The binaries are compiled against .NET 4.0 AnyCPU. There are currently no plans to port this library to a .NET version < 4.

## NuGet
Install this library using NuGet:
```
PM> Install-Package NTH
```
The NuGet package is getting updated as soon as a new distribution build is available. The raw package contents (DLL files and XML documentation) are available [here](https://github.com/nikeee/nth/tree/master/dist/lib) for download, if needed.

## Features
Let's come to the good stuff, shall we?

### Reduce Noise

Extension methods help to reduce code noise.
```C#
string baz = " this is\n some text containing white space    	\t ";
var baz2 = baz.StripWhiteSpace(); // baz2 == "thisissometextcontainingwhitespace"
```

Also available:
```C#
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

`Clamp` for bytes, shorts, ints, longs, floats, doubles and decimals.
```C#
int a = 1;
int b = 2;
int c = 3;

int d = MathEx.Clamp(a, b, c); // d == 2
```

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

### .ConvertToStruct&lt;T&gt;()
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

### ByteSize

```C#
var fileByteCount = new FileInfo(Assembly.GetEntryAssembly().Location).Length; // e.g. 5120

var fs = new ByteSize(fileByteCount);
Console.WriteLine(fs.ToString()); // 5 KiB

fs++; // increment fs by one byte

Console.WriteLine("Exact bytes: " + fs.ByteCount);

fs += new ByteSize(1, ByteSizeUnit.MibiByte); // + 1MiB

var twoGigabyte = new ByteSize(2, ByteSizeUnit.GigaByte); // 2GB (not GiB)
bool areEqual = fs == twoGigabyte; // do these instances represent the same byte size?
```

### Levenshtein Distance

```C#
string tier = "tier";
string tor = "tor";
var distance = tier.LevenshteinDistanceTo(tor);
Console.WriteLine(distance); // 2

// dictionary:
var dictionary = new[] {
	"bier",
	"bitte",
	"bitter",
	"besen"
};
var input = "biete";
var bestMatch = dictionary.OrderByLevenshteinDistanceTo(input).FirstOrDefault();
Console.WriteLine("Did you mean " + bestMatch + "?"); // Did you mean bitte?
```

### ConsoleEx
Further console functionality:
```C#
SecureString password = ConsoleEx.ReadLineMasked(); // The user can type in a hidden phrase. Nothing will appear in the stdout.
password = ConsoleEx.ReadLineMasked(true); // Displays a mask character for each char entered (default: '*')
password = ConsoleEx.ReadLineMasked(true, '?'); // Uses '?' as mask
```

### BitUtil
Adding some C-Macro-style functionality.
```C#

int foo = 0x12345678;
short bar = BitUtil.LowWord(foo); // bar == 0x5678
bar = BitUtil.HighWord(foo); // bar == 0x1234

// Also available for Short/Byte:
// BitUtil.LowByte/HighByte
```

### NewLine Operations
```C#
string foo = "\r\n\n\n";
string normalizedNewLines = foo.NormalizeNewLines("\n");
// foo == "\n\n\n"

string bar = "a";
bool isNl = bar.IsNewLine(); // false
bar = "\n";
isNl = bar.IsNewLine(); // true
```

### Unix Time Extensions
```C#
// "At 23:31:30 UTC on 13 February 2009, the decimal representation of Unix time reached 1,234,567,890 seconds"
var demDate = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
long unixTime = demDate.ToUnixTime(); // 1234567890

//..and the other way round

demDate = DateTimeEx.FromUnixToUtcDateTime(unixTime); // Also available: FromUnixToLocalTime
```

### Hashing Shortcuts
```C#
string sha1Hash = FileEx.ComputeHashSha1(fileName).ToHexString();
```

### TODO
// TODO: More to come soon!
