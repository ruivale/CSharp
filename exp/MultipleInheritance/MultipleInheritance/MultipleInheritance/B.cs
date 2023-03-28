using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleInheritance
{
    class B : A 
    {
        void toString()
        {
            MessageBox.Show("B");
        }
    }
}
