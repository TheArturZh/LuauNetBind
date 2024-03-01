using System.Runtime.CompilerServices;

namespace Luau;

/// <summary>
/// This exists because function-like macro definition records are not supported by ClangSharpPInvokeGenerator yet.
/// </summary>
///
public static class Macros
{
    // TODO: Reimplement lua_pushliterals as a proper C++ function
    // TODO: Also move lua_pushfstring here once I figure out how to P/Invoke a function with a variadic signature (pain)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public static unsafe sbyte* lua_tostring(lua_State* L, int i)
    {
        return Luau.lua_tolstring(L, i, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe double lua_tonumber(lua_State* L, int i)
    {
        return Luau.lua_tonumberx(L, i, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_tointeger(lua_State* L, int i)
    {
        return Luau.lua_tointegerx(L, i, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("unsigned int")]
    public static unsafe uint lua_tounsigned(lua_State* L, int i)
    {
        return Luau.lua_tounsignedx(L, i, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void lua_pop(lua_State* L, int n)
    {
        Luau.lua_settop(L, -n-1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void lua_newtable(lua_State* L)
    {
        Luau.lua_createtable(L, 0, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void* lua_newuserdata(lua_State* L, [NativeTypeName("size_t")] nuint s)
    {
        return Luau.lua_newuserdatatagged(L, s, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_strlen(lua_State* L, int i)
    {
        return Luau.lua_objlen(L, i);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_isfunction(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == (int)lua_Type.LUA_TFUNCTION) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_istable(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == (int)lua_Type.LUA_TTABLE) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_islightuserdata(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == (int)lua_Type.LUA_TLIGHTUSERDATA) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_isnil(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == (int)lua_Type.LUA_TNIL) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_isboolean(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == (int)lua_Type.LUA_TBOOLEAN) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_isvector(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == (int)lua_Type.LUA_TVECTOR) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_isthread(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == (int)lua_Type.LUA_TTHREAD) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_isnone(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) == Luau.LUA_TNONE) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_isnoneornil(lua_State* L, int n)
    {
        return (Luau.lua_type(L, n) <= (int)lua_Type.LUA_TNIL) ? 1 : 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void lua_pushcfunction(lua_State* L, [NativeTypeName("lua_CFunction")] delegate* unmanaged[Cdecl]<lua_State*, int> fn, [NativeTypeName("const char *")] in sbyte* debugname)
    {
        Luau.lua_pushcclosurek(L, fn, debugname, 0, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void lua_pushcclosure(lua_State* L, [NativeTypeName("lua_CFunction")] delegate* unmanaged[Cdecl]<lua_State*, int> fn, [NativeTypeName("const char *")] in sbyte* debugname, int nup)
    {
        Luau.lua_pushcclosurek(L, fn, debugname, nup, null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void lua_setglobal(lua_State* L, [NativeTypeName("const char *")] in sbyte* s)
    {
        Luau.lua_setfield(L, Luau.LUA_GLOBALSINDEX, s);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int lua_getglobal(lua_State* L, [NativeTypeName("const char *")] in sbyte* s)
    {
        return Luau.lua_getfield(L, Luau.LUA_GLOBALSINDEX, s);
    }
}