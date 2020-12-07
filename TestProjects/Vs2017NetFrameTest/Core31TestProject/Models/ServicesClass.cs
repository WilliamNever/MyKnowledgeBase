using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public interface BsInterface { }
    public interface Svr<T> : BsInterface
    {
        T GetMemory();
    }
    public abstract class InfoService<T> : Svr<T>
    {
        public string TypeName = typeof(T).FullName;
        public Guid ClassID = Guid.NewGuid();
        public virtual T GetMemory()
        {
            throw new NotImplementedException();
        }
    }
    public class ServicesClass : InfoService<string>
    {
        public override string GetMemory()
        {
            return base.GetMemory();
        }
    }

    public class SvrClass : InfoService<int>
    {
        public override int GetMemory()
        {
            return base.GetMemory();
        }
    }
}
