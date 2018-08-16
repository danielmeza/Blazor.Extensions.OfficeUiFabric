using System;
using System.Reflection;

namespace Mono.WebAssembly
{

    public sealed class ClrFuncReflectionWrap
    {
        Object instance;
        MethodInfo invokeMethod;

        public static ClrFuncReflectionWrap Create(Assembly assembly, String typeName, String methodName)
        {
            Console.WriteLine("CS::ClrFuncReflectionWrap::Create");
            Type startupType = assembly.GetType(typeName);

            if (startupType == null)
            {
                throw new TypeLoadException("Could not load type '" + typeName + "'");
            }

            ClrFuncReflectionWrap wrap = new ClrFuncReflectionWrap();
            wrap.instance = System.Activator.CreateInstance(startupType);
            wrap.invokeMethod = startupType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
            if (wrap.invokeMethod == null)
            {
                throw new System.InvalidOperationException(
                    "Unable to access the CLR method to wrap through reflection. Make sure it is a public instance method.");
            }

            return wrap;
        }

        public Object Call(Object payload)
        {
            Console.WriteLine("CS::ClrFuncReflectionWrap::Call");
            return (Object)this.invokeMethod.Invoke(this.instance, new object[] { payload });
        }
    };
}