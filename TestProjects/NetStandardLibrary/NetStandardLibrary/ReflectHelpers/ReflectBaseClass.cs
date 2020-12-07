using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace NetStandardLibrary.ReflectHelpers
{
    public class ReflectBaseClass<T>
    {
        // Fields
        protected Type t;
        protected T tClass;
        protected BindingFlags mPropertyFlags = BindingFlags.Instance | BindingFlags.Public  | BindingFlags.NonPublic;
        protected BindingFlags mFieldFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public;
        protected BindingFlags mStaticFieldFlags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        // Methods
        public ReflectBaseClass(T AClass)
        {
            tClass = AClass;
            t = typeof(T);
        }

        public FT GetInstanceFieldValue<FT>(string FName)
        {
            return (FT)t.GetField(FName, mFieldFlags).GetValue(tClass);
        }
        public FT GetStaticFieldValue<FT>(string FName)
        {
            var fieldInfo = t.GetField(FName, mStaticFieldFlags);
            return (FT)fieldInfo.GetValue(tClass);
        }
        public Ft GetPropertyValue<Ft>(string FName, params object[] index)
        {
            return (Ft)this.t.GetProperty(FName, mPropertyFlags).GetValue(tClass, index);
        }
        public Ft RunPrivateFunction<Ft>(string FName, params object[] o)
        {
            MethodInfo method = this.t.GetMethod(FName, mFieldFlags);
            if (method.ReturnType == typeof(void))
            {
                method.Invoke(this.tClass, o);
                return default(Ft);
            }
            return (Ft)method.Invoke(tClass, o);
        }

        public void ClearControlEvent(string EventKey, string EventName)
        {
            var evList = GetPropertyValue<EventHandlerList>("Events", null) as EventHandlerList;

            var evFuncList = GetStaticFieldValue<object>(EventKey);
            Delegate d = evList[evFuncList];
            EventInfo eventInfo = t.GetEvent(EventName);

            foreach (Delegate dx in d.GetInvocationList())
            {
                eventInfo.RemoveEventHandler(tClass, dx);
            }
        }
    }
}
