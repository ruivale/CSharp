using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnMilestoneTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The first statement is always required, the others are only required if your application is using features supported by those areas.
            // TODO: Initialize SDK environment and login
            VideoOS.Platform.SDK.Environment.Initialize();
            ////VideoOS.Platform.SDK.UI.Environment.Initialize();
            ////VideoOS.Platform.SDK.Export.Environment.Initialize();
            ////VideoOS.Platform.SDK.Media.Environment.Initialize();
            ////VideoOS.Platform.SDK.Log.Environment.Initialize();

        }
    }
}
