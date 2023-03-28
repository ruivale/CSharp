using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nwc.XmlRpc
{
    public class AddingInfo
    {
        int i1;
        int i2;

        public AddingInfo(int i1, int i2)
        {
            this.i1 = i1;
            this.i2 = i2;
        }

        public int FirstValue
        {
            get { return this.i1; }
        }
        public int SecondValue
        {
            get { return this.i2; }
        }

        public String ToString()
        {
            return "AddingInfo(" + this.FirstValue + "," + this.SecondValue + ")";
        }
    }
}
