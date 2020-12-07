﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsAppTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RegisterConstValue();
            Application.Run(new MainFrm());
        }

        /// <summary>
        /// To set DataDirectory value that is referred by app.config file
        /// <connectionStrings>
        ///     <add name = "DBCTxt" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|DBCTxt.mdf;Integrated Security=True;Connect Timeout=30" providerName="System.Data.SqlClient" />
        /// </connectionStrings>
        /// </summary>
        private static void RegisterConstValue()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            int index = path.IndexOf(@"\bin\", StringComparison.InvariantCultureIgnoreCase);
            if (index > -1)
            {
                path = path.Substring(0, index);
            }
            if (!path.EndsWith("\\App_Data\\") || !path.EndsWith("\\App_Data"))
            {
                path = path + "\\App_Data\\";
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }
    }
}
