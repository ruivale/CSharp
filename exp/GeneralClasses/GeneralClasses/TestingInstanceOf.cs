using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneralClasses
{

        public class EFAGeneralApplication
        {
            public int ID { get; set; }
            public string Description { get; set; }
            public int MonitorIndex { get; set; }
            public string User { get; set; }
            public string Pass { get; set; }

            public override string ToString()
            {
                return this.Description;
            }
        }
        /// <summary>
        /// EFA Application class used by browser application, namely Internet Explorer ones.
        /// </summary>
        public class IEApplication : EFAGeneralApplication
        {
            public string URL { get; set; }
            //public InternetExplorer IE { get; set; }
        }

        /// <summary>
        /// EFA Application class used by general applications such as Java ones (started from invoking a .bat file).
        /// </summary>
        public class EFAApplication : EFAGeneralApplication
        {
            public string Path { get; set; }
            public string[] Args { get; set; }
            //public Process process { get; set; }
        }

    class TestingInstanceOf
    {
        private static IDictionary<int, EFAGeneralApplication> efApplications = new Dictionary<int, EFAGeneralApplication>();

        static void _Main(string[] args)
        {
            EFAGeneralApplication aieapp = new IEApplication();
            aieapp.ID = 1;
            EFAGeneralApplication aefapp = new EFAApplication();
            aefapp.ID = 2;


            efApplications.Add(aieapp.ID, aieapp);
            efApplications.Add(aefapp.ID, aefapp);
            List<EFAGeneralApplication> values = efApplications.Values.ToList();

            foreach (EFAGeneralApplication app in values)
            {
                if (app is IEApplication)
                {
                    MessageBox.Show("app("+app.ID+") is an IEApplication ...");
                }
                else
                {
                    MessageBox.Show("app(" + app.ID + ") is NOT an IEApplication ...");
                }

                if (app is EFAApplication)
                {
                    MessageBox.Show("app(" + app.ID + ") is an EFAApplication ...");
                }
                else
                {
                    MessageBox.Show("app(" + app.ID + ") is NOT an EFAApplication ...");
                }
            }
        }
    }
}
