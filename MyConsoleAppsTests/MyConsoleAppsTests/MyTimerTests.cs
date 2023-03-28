using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyConsoleAppsTests
{
    class MyTimerTests
    {
        // Create a timer with a 5 second interval.
        private System.Timers.Timer m_TimeTimer = null;


        /// <summary>
        /// The constructor ...
        /// </summary>
        public MyTimerTests()
        {
            MessageBox.Show(
                null,
                "MyTimerTests()",
                "INFO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            

            m_TimeTimer = new System.Timers.Timer(5000);
            m_TimeTimer.Elapsed += new System.Timers.ElapsedEventHandler(m_TimeTimer_Elapsed);
            m_TimeTimer.Start();
        }


        /// <summary>
        /// The timer action listener fired event method call ... ;-)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_TimeTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show(
                null, 
                "m_TimeTimer_Elapsed", 
                "INFO", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);

            m_TimeTimer.Stop();
        }

        private void GetMachineConfigurationSections()
        {
            try
            {
                /* Create a new cofiguration instance and specify it to target the,the machine configuration settings as follow */
                Configuration oConfiguration = ConfigurationManager.OpenMachineConfiguration();
                // This variable help us to know the section number
                int SectionsNumber = 0;
                MessageBox.Show("The machine configuration sections");
                /* Get all sections in the machine configuration file. It can be found,in the directory : C:\Microsoft.NET\Framework\version\config */
                foreach (ConfigurationSection section in oConfiguration.Sections)
                {
                    MessageBox.Show(string.Format("The section name is : {0}", section.SectionInformation.Name));
                    //Increment the sections' number to get the count 
                    SectionsNumber++;
                }

                //Display the sections count 
                MessageBox.Show("The number of sections");
                MessageBox.Show(SectionsNumber.ToString());

                //Display the machine configuration file path
                MessageBox.Show("The machine configuration section path");
                MessageBox.Show(oConfiguration.FilePath);
            }
            catch (ConfigurationErrorsException caught) { MessageBox.Show(caught.Message); }
        }


        static void Main_()
        {
            new MyTimerTests();
        }

    }

}
