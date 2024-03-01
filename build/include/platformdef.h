// API defines for ClangSharpPInvokeGenerator
#if defined(_WIN32)
#define LUACODE_API extern "C" __declspec(dllexport)
#define LUA_API extern "C" __declspec(dllexport)
#else
#define LUACODE_API extern "C"
#define LUA_API extern "C"
#endif