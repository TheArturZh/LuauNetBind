# LuauNetBind

**Fork of https://github.com/afterschoolstudio/Luau.NET**

These are low-level library bindings without marshalling.
I'm planning to wrap it into a library with an idiomatic API later.

## Building
You'll need .NET 8 SDK, Zig, ClangSharpPInvokeGenerator (dotnet tool) and Clang 17 or newer (required by ClangSharpPInvokeGenerator 17.0.0+)

1. Run `git submodule update --init`
2. Run `zig build` in build/ to build dynamic Luau library.
3. Run `ClangSharpPInvokeGenerator '@gen.rsp'` in gen/ to generate bindings.  
   Latest version (17.0.1) of ClangSharpPInvokeGenerator doesn't generate correct C#, so you'll need to manually delete `}` at the end of Luau.NET.Test/bindings/Luau.cs file.
4. To test, run `dotnet run` in Luau.Net.Test/

## Test program
Demonstrates:
* Ability to load in and compile a script
* Function binding between Luau/C#

The test script will "fail" due to errors in the script, but that's the point.  
Expected output:
```
creating a state
state created
compiling
loading bytecode with size 424
hello world from luau
true
LUA_ERRRUN
[string "test"]:5: attempt to compare number < string
[string "test"]:5 function ispositive
[string "test"]:10

exited
```