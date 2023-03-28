using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace ConsoleApplication1
{
    public class Exports
    {
        [Export]
        public string HelloMef
        {
            get { return "Hello, MEF!"; }
        }
    }
}
