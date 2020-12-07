using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace ReflectClass
{
    public class ReflectBaseClass<T>
    {
        // Fields
        protected Type t;
        protected T tClass;
        protected BindingFlags mPropertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
        protected BindingFlags mFieldFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        protected BindingFlags mStaticFieldFlags = BindingFlags.Static | BindingFlags.NonPublic;

        // Methods
        public ReflectBaseClass(T AClass)
        {
            this.tClass = AClass;
            this.t = typeof(T);
        }

        public FT GetInstanceField<FT>(string FName)
        {
            return (FT)this.t.GetField(FName, mFieldFlags).GetValue(this.tClass);
        }
        public FT GetStaticField<FT>(string FName)
        {
            var fieldInfo = this.t.GetField(FName, mStaticFieldFlags);
            return (FT)fieldInfo.GetValue(this.tClass);
        }

        public Ft RunPrivateFunction<Ft>(string FName, params object[] o)
        {
            MethodInfo method = this.t.GetMethod(FName, mFieldFlags);
            if (method.ReturnType == typeof(void))
            {
                method.Invoke(this.tClass, o);
                return default(Ft);
            }
            return (Ft)method.Invoke(this.tClass, o);
        }
        public Ft GetProperty<Ft>(string FName, params object[] index)
        {
            return (Ft)this.t.GetProperty(FName, mPropertyFlags).GetValue(this.tClass, index);
        }

        public void ClearControlEvent(string EventName,string EventDelegateName)
        {
            var evList = GetProperty<EventHandlerList>("Events", null) as EventHandlerList;
            var evFuncList = GetStaticField<object>(EventName);
            Delegate d = evList[evFuncList];
            EventInfo eventInfo = t.GetEvent(EventDelegateName);

            foreach (Delegate dx in d.GetInvocationList())
            {
                eventInfo.RemoveEventHandler(tClass, dx);
            }
        }
    }
}
