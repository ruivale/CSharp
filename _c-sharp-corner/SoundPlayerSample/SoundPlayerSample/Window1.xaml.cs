using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace SoundPlayerSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

private void BrowseButton_Click(object sender, RoutedEventArgs e)
{
    OpenFileDialog dlg = new OpenFileDialog();
    dlg.InitialDirectory = "c:\\";
    dlg.Filter = "Sound files (*.wav)|*.wav|All Files (*.*)|*.*";
    dlg.FilterIndex = 2;
    dlg.RestoreDirectory = true;

    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        string selectedFileName = dlg.FileName;
        FileTextBox.Text = selectedFileName;
        MediaPlayer mp = new MediaPlayer();
        mp.Open(new Uri(selectedFileName, UriKind.Relative ));
        mp.Play();
    }
}
    }
}
