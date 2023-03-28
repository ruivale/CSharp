using System;
using System.Collections.Generic;
using System.IO;
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
using System.Speech.Synthesis;
using System.Threading;

namespace Text_to_Speech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //speech synthesizer
        private SpeechSynthesizer synthesizer;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            synthesizer = new SpeechSynthesizer();

            #region synthesizer eventes
            synthesizer.StateChanged += new EventHandler<StateChangedEventArgs>(synthesizer_StateChanged);
            synthesizer.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(synthesizer_SpeakStarted);
            synthesizer.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(synthesizer_SpeakProgress);
            synthesizer.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(synthesizer_SpeakCompleted); 
            #endregion

            LoadInstalledVoices();
        }

        //bind installed voices to the combo based on current culture
        private void LoadInstalledVoices()
        {
            comboVoice.DataContext = (from e in synthesizer.GetInstalledVoices(System.Globalization.CultureInfo.CurrentUICulture)
                                      select e.VoiceInfo.Name);
        }

        private void ButtonSpeak_Click(object sender, RoutedEventArgs e)
        {
            if (comboVoice.SelectedItem != null)
                synthesizer.SelectVoice(comboVoice.SelectedItem.ToString());
            synthesizer.Volume = Convert.ToInt32(sliderVolume.Value);
            synthesizer.Rate = Convert.ToInt32(sliderRate.Value);
            switch (synthesizer.State)
            {
                    //if synthesizer is ready
                case SynthesizerState.Ready:
                    synthesizer.SpeakAsync(ConvertRichTextBoxContentsToString());
                    ButtonSpeak.Content = "Pause";
                    break;
                    //if synthesizer is paused
                case SynthesizerState.Paused:
                    synthesizer.Resume();
                    ButtonSpeak.Content = "Pause";
                    break;
                    //if synthesizer is speaking
                case SynthesizerState.Speaking:
                    synthesizer.Pause();
                    ButtonSpeak.Content = "Resume";
                    break;
            }
        }

        private void OpenTextFileButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadTextDocument(openFileDialog.FileName);
                FileNameTextBox.Text = openFileDialog.FileName;
            }
        }


        private void LoadTextDocument(string fileName)
        {
            TextRange range;
            if (System.IO.File.Exists(fileName))
            {
                range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                using (FileStream fStream = new FileStream(fileName, System.IO.FileMode.OpenOrCreate))
                {
                    range.Load(fStream, System.Windows.DataFormats.Text);
                }
            }
        }

        string ConvertRichTextBoxContentsToString()
        {
            TextRange textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
            return textRange.Text;
        }

        #region Synthesizer events
        private void synthesizer_StateChanged(object sender, StateChangedEventArgs e)
        {
            //show the synthesizer's current state 
            labelState.Content = e.State.ToString();
        }
        private void synthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {

        }

        void synthesizer_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            //show the synthesizer's current progress 
            labelProgress.Content = e.Text;
        }

        private void synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            //reset when complete 
            ButtonSpeak.Content = "Speak";
            labelProgress.Content = "";
        } 
        #endregion

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (synthesizer != null)
            {
                synthesizer.Volume = Convert.ToInt32(sliderVolume.Value);
            }
        }

        private void sliderRate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (synthesizer != null)
                synthesizer.Rate = Convert.ToInt32(sliderRate.Value);
        }
    }
}
