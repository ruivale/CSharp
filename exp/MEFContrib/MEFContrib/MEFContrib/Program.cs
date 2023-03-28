using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace ConsoleApplication1
{
    class Program
    {
        public Program()
        {
            var assemblyCatalog = new AssemblyCatalog(typeof(Program).Assembly);
            var container = new CompositionContainer(assemblyCatalog);
            container.SatisfyImportsOnce(this);
        }

        [Import]
        public string Text { get; set; }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.Text);
            Console.ReadLine();
        }
    }
}
