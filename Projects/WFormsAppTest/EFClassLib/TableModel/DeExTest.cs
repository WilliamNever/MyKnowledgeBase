using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFClassLib.TableModel
{
    public class DeExTest
    {
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string Name { get; set; }
    }

    public class DeExTestEx : DeExTest
    {
        [System.ComponentModel.DataAnnotations.StringLength(30)]
        public override string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                base.Name = value;
            }
        }
    }
}
