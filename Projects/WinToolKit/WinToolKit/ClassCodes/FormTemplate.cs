using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinToolKit.ClassCodes
{
    public class FormTemplate
    {
        public Form VForm { get; private set; }
        public Guid GKey { get; private set; }
        public int Num { get; private set; }
        public FormTemplate(Form form, Guid gkey, int num)
        {
            VForm = form;
            GKey = gkey;
            Num = num;
        }
        public T GetForm<T>() where T : Form
        {
            return VForm as T;
        }
    }
}
