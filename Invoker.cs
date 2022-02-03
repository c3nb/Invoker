using System;
using System.Linq;
using System.Security;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Extensions; //https://github.com/c3nb/Reflection
using System.Runtime.InteropServices;

[SecurityCritical]
[SecuritySafeCritical]
[SuppressUnmanagedCodeSecurity]
public static class Invoker
{
    public static void Invoke(this IntPtr function, params object[] parameters)
        => GetInvoker(function, parameters).Invoke(null, parameters);
    public static T Invoke<T>(this IntPtr function, params object[] parameters)
        => (T)GetInvoker<T>(function, parameters).Invoke(null, parameters);
    public static void Invoke(this IntPtr function, CallingConventions callingConventions, params object[] parameters)
        => GetInvoker(function, callingConventions, parameters).Invoke(null, parameters);
    public static T Invoke<T>(this IntPtr function, CallingConventions callingConventions, params object[] parameters)
        => (T)GetInvoker<T>(function, callingConventions, parameters).Invoke(null, parameters);
    public static void Invoke(this IntPtr function, CallingConvention callingConvention, params object[] parameters)
        => GetInvoker(function, callingConvention, parameters).Invoke(null, parameters);
    public static T Invoke<T>(this IntPtr function, CallingConvention callingConvention, params object[] parameters)
        => (T)GetInvoker<T>(function, callingConvention, parameters).Invoke(null, parameters);
    public static MethodInfo GetInvoker(this IntPtr function, params object[] parameters)
    {
        if (PtrMethod.TryGetValue(function, out var method))
            return method;
        Type[] final = parameters.Select(o => o.GetType()).ToArray();
        TypeBuilder invokerType = InvokerMod.DefineType($"{function}_InvokerT", TypeAttributes.Public | TypeAttributes.Class);
        var attrs = GetSecurityAttributes();
        for (int i = 0; i < 3; i++)
            invokerType.SetCustomAttribute(attrs[i]);
        MethodBuilder dm = invokerType.DefineMethod($"{function}_Invoker", MethodAttributes.Public | MethodAttributes.Static, typeof(void), final);
        var il = dm.GetILGenerator();
        for (int i = 0; i < parameters.Length; i++)
            il.Ldarg((short)i);
        if (IntPtr.Size == 8)
            il.Ldc_I8(function.ToInt64());
        else il.Ldc_I4(function.ToInt32());
        il.Calli(CallingConventions.Any, typeof(void), final, Type.EmptyTypes);
        il.Ret();
        Type created = invokerType.CreateType();
        MethodInfo invoker = created.GetMethod($"{function}_Invoker");
        PtrMethod.Add(function, invoker);
        return invoker;
    }
    public static MethodInfo GetInvoker<T>(this IntPtr function, params object[] parameters)
    {
        if (PtrMethod.TryGetValue(function, out var method))
            return method;
        Type[] final = parameters.Select(o => o.GetType()).ToArray();
        TypeBuilder invokerType = InvokerMod.DefineType($"{function}_InvokerT", TypeAttributes.Public | TypeAttributes.Class);
        var attrs = GetSecurityAttributes();
        for (int i = 0; i < 3; i++)
            invokerType.SetCustomAttribute(attrs[i]);
        MethodBuilder dm = invokerType.DefineMethod($"{function}_Invoker", MethodAttributes.Public | MethodAttributes.Static, typeof(T), final);
        var il = dm.GetILGenerator();
        for (int i = 0; i < parameters.Length; i++)
            il.Ldarg((short)i);
        if (IntPtr.Size == 8)
            il.Ldc_I8(function.ToInt64());
        else il.Ldc_I4(function.ToInt32());
        il.Calli(CallingConventions.Any, typeof(T), final, Type.EmptyTypes);
        il.Ret();
        Type created = invokerType.CreateType();
        MethodInfo invoker = created.GetMethod($"{function}_Invoker");
        PtrMethod.Add(function, invoker);
        return invoker;
    }
    public static MethodInfo GetInvoker(this IntPtr function, CallingConventions callingConventions, params object[] parameters)
    {
        if (PtrMethod.TryGetValue(function, out var method))
            return method;
        Type[] final = parameters.Select(o => o.GetType()).ToArray();
        TypeBuilder invokerType = InvokerMod.DefineType($"{function}_InvokerT", TypeAttributes.Public | TypeAttributes.Class);
        var attrs = GetSecurityAttributes();
        for (int i = 0; i < 3; i++)
            invokerType.SetCustomAttribute(attrs[i]);
        MethodBuilder dm = invokerType.DefineMethod($"{function}_Invoker", MethodAttributes.Public | MethodAttributes.Static, typeof(void), final);
        var il = dm.GetILGenerator();
        for (int i = 0; i < parameters.Length; i++)
            il.Ldarg((short)i);
        if (IntPtr.Size == 8)
            il.Ldc_I8(function.ToInt64());
        else il.Ldc_I4(function.ToInt32());
        il.Calli(callingConventions, typeof(void), final, Type.EmptyTypes);
        il.Ret();
        Type created = invokerType.CreateType();
        MethodInfo invoker = created.GetMethod($"{function}_Invoker");
        PtrMethod.Add(function, invoker);
        return invoker;
    }
    public static MethodInfo GetInvoker<T>(this IntPtr function, CallingConventions callingConventions, params object[] parameters)
    {
        if (PtrMethod.TryGetValue(function, out var method))
            return method;
        Type[] final = parameters.Select(o => o.GetType()).ToArray();
        TypeBuilder invokerType = InvokerMod.DefineType($"{function}_InvokerT", TypeAttributes.Public | TypeAttributes.Class);
        var attrs = GetSecurityAttributes();
        for (int i = 0; i < 3; i++)
            invokerType.SetCustomAttribute(attrs[i]);
        MethodBuilder dm = invokerType.DefineMethod($"{function}_Invoker", MethodAttributes.Public | MethodAttributes.Static, typeof(T), final);
        var il = dm.GetILGenerator();
        for (int i = 0; i < parameters.Length; i++)
            il.Ldarg((short)i);
        if (IntPtr.Size == 8)
            il.Ldc_I8(function.ToInt64());
        else il.Ldc_I4(function.ToInt32());
        il.Calli(callingConventions, typeof(T), final, Type.EmptyTypes);
        il.Ret();
        Type created = invokerType.CreateType();
        MethodInfo invoker = created.GetMethod($"{function}_Invoker");
        PtrMethod.Add(function, invoker);
        return invoker;
    }
    public static MethodInfo GetInvoker(this IntPtr function, CallingConvention callingConvention, params object[] parameters)
    {
        if (PtrMethod.TryGetValue(function, out var method))
            return method;
        Type[] final = parameters.Select(o => o.GetType()).ToArray();
        TypeBuilder invokerType = InvokerMod.DefineType($"{function}_InvokerT", TypeAttributes.Public | TypeAttributes.Class);
        var attrs = GetSecurityAttributes();
        for (int i = 0; i < 3; i++)
            invokerType.SetCustomAttribute(attrs[i]);
        MethodBuilder dm = invokerType.DefineMethod($"{function}_Invoker", MethodAttributes.Public | MethodAttributes.Static, typeof(void), final);
        var il = dm.GetILGenerator();
        for (int i = 0; i < parameters.Length; i++)
            il.Ldarg((short)i);
        if (IntPtr.Size == 8)
            il.Ldc_I8(function.ToInt64());
        else il.Ldc_I4(function.ToInt32());
        il.Calli(callingConvention, typeof(void), final);
        il.Ret();
        Type created = invokerType.CreateType();
        MethodInfo invoker = created.GetMethod($"{function}_Invoker");
        PtrMethod.Add(function, invoker);
        return invoker;
    }
    public static MethodInfo GetInvoker<T>(this IntPtr function, CallingConvention callingConvention, params object[] parameters)
    {
        if (PtrMethod.TryGetValue(function, out var method))
            return method;
        Type[] final = parameters.Select(o => o.GetType()).ToArray();
        TypeBuilder invokerType = InvokerMod.DefineType($"{function}_InvokerT", TypeAttributes.Public | TypeAttributes.Class);
        var attrs = GetSecurityAttributes();
        for (int i = 0; i < 3; i++)
            invokerType.SetCustomAttribute(attrs[i]);
        MethodBuilder dm = invokerType.DefineMethod($"{function}_Invoker", MethodAttributes.Public | MethodAttributes.Static, typeof(T), final);
        var il = dm.GetILGenerator();
        for (int i = 0; i < parameters.Length; i++)
            il.Ldarg((short)i);
        if (IntPtr.Size == 8)
            il.Ldc_I8(function.ToInt64());
        else il.Ldc_I4(function.ToInt32());
        il.Calli(callingConvention, typeof(T), final);
        il.Ret();
        Type created = invokerType.CreateType();
        MethodInfo invoker = created.GetMethod($"{function}_Invoker");
        PtrMethod.Add(function, invoker);
        return invoker;
    }
    public static void SaveInvokerAssembly()
        => InvokerAsm.Save("Invoker.dll");
    private static CustomAttributeBuilder[] GetSecurityAttributes()
        => new CustomAttributeBuilder[]
        {
                new CustomAttributeBuilder(typeof(SecurityCriticalAttribute).GetConstructor(Type.EmptyTypes), new object[]{ }),
                new CustomAttributeBuilder(typeof(SecuritySafeCriticalAttribute).GetConstructor(Type.EmptyTypes), new object[]{ }),
                new CustomAttributeBuilder(typeof(SuppressUnmanagedCodeSecurityAttribute).GetConstructor(Type.EmptyTypes), new object[]{ }),
        };
    private static readonly AssemblyBuilder InvokerAsm = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Invoker"), AssemblyBuilderAccess.RunAndSave, Reflection.GetDefaultAttributes("Invoker"));
    private static readonly ModuleBuilder InvokerMod = InvokerAsm.DefineDynamicModule("Invoker", "Invoker.dll", true);
    public static readonly Dictionary<IntPtr, MethodInfo> PtrMethod = new Dictionary<IntPtr, MethodInfo>();
}
