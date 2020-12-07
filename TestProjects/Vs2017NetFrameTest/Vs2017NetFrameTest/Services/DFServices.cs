using ConsoleCoreTest.DBModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vs2017NetFrameTest.Models;

namespace Vs2017NetFrameTest.Services
{
    public class DFServices : IDFServ
    {
        public IinJectDFunc ij;
        public IinJectDFunc idf;
        private readonly DBCTXTContext Dbc;
        private readonly DBCTXTContextX Dbcx;

        public DFServices(IinJectDFunc ijctionDF, IinJectDFunc IdfuncService, DBCTXTContext dbc, DBCTXTContextX dbcx)
        {
            ij = ijctionDF;
            idf = IdfuncService;
            Dbc = dbc;
            Dbcx = dbcx;
        }

        IinJectDFunc IDFServ.GetIDF()
        {
            idf.SetAPPName("IDF APP Name");
            return idf;
        }

        IinJectDFunc IDFServ.GetIJ()
        {
            ij.SetAPPName("IJ APP Name");
            return ij;
        }
    }

    public interface IDFServ
    {
        IinJectDFunc GetIJ();
        IinJectDFunc GetIDF();
    }
}
