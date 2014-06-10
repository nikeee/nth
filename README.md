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

// TODO