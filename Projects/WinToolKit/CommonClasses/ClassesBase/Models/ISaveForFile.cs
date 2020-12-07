using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClasses.ClassesBase.Models
{
    public delegate void ChangeMenuItemName(string name,Guid gid);
    public interface ISaveForFile
    {
        void Save();
        void SaveAnother();
    }
}
