using ConsoleCoreTest.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vs2017NetFrameTest.Models
{
    public interface IinJectDFunc
    {
        string GetAPPName();
        void SetAPPName(string name);
        Guid GID { get; }
    }
    public class InjectionDFunc : IinJectDFunc
    {
        private Guid guid;
        private string APPName = "Private Li APP.";
        private readonly DBCTXTContext Dbc;
        private readonly DBCTXTContextX Dbcx;

        public InjectionDFunc(DBCTXTContext dbc, DBCTXTContextX dbcx)
        {
            guid = Guid.NewGuid();
            Dbc = dbc;
            Dbcx = dbcx;
        }
        Guid IinJectDFunc.GID { get => guid; }

        //public string GetAPPName()
        //{
        //    return "Li APP.";
        //}
        string IinJectDFunc.GetAPPName()
        {
            return APPName;
        }

        void IinJectDFunc.SetAPPName(string name)
        {
            APPName = name;
        }
    }
}
