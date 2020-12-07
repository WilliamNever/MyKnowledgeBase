using ConsoleCoreTest.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vs2017NetFrameTest.Models;

namespace Vs2017NetFrameTest.Services
{
    public class SecondService : IScnd
    {
        private string ClassName;
        private IDFServ DFS;
        private readonly DBCTXTContext Dbc;
        private readonly DBCTXTContextX Dbcx;

        public SecondService(IDFServ dfs, IinJectDFunc IdfuncService, DBCTXTContext dbc, DBCTXTContextX dbcx)
        {
            DFS = dfs;
            Dbc = dbc;
            Dbcx = dbcx;
        }
        string IScnd.Get()
        {
            return $"{DFS.GetIJ().GetAPPName()}-{DFS.GetIDF().GetAPPName()}";
        }

        void IScnd.Set(string str,string str2)
        {
            DFS.GetIDF().SetAPPName(str);
            DFS.GetIJ().SetAPPName(str2);
        }
    }

    public interface IScnd
    {
        string Get();
        void Set(string str, string str2);
    }
}
