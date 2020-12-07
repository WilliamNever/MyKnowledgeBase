using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTools.Models
{
    public delegate void DelegateMethod(DataSet dset, string Error);
    public class ThreadRunTemplate
    {
        private ThreadRunParamsModel model;
        public ThreadRunTemplate(ThreadRunParamsModel ParamModel)
        {
            model = ParamModel;
        }
        public void Run()
        {
            string ErrorMessage = "";
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(model.Connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(model.Command, conn);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds);
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            model.form.Invoke(model.delgate, new object[] { ds, ErrorMessage });
        }
    }

    public class ThreadRunParamsModel
    {
        public Form form { get; set; }
        public DelegateMethod delgate { get; set; }
        public string Connection { get; set; }
        public string Command { get; set; }
    }
}
