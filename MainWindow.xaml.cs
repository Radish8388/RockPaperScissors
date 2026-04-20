using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpeechSynthesizer synth;
        private Random random = new Random();
        private int playerChoice = 0;
        private int computerChoice = 0;
        private bool soundOn = true;
        private int NumberOfWins = 0;
        private int NumberOfLosses = 0;
        private int NumberOfDraws = 0;

        public MainWindow()
        {
            InitializeComponent();
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            // Set the volume (0-100)
            synth.Volume = 100;
            // Set the speed (-10 to 10)
            synth.Rate = -2;
            synth.SelectVoiceByHints(VoiceGender.Female);
            SpeakText("press a button to play");
        }

        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            playerChoice = 0;
            computerChoice = random.Next(3);
            ShowResult(playerChoice, computerChoice);
        }

        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            playerChoice = 1;
            computerChoice = random.Next(3);
            ShowResult(playerChoice, computerChoice);
        }

        private void Scissors_Click(object sender, RoutedEventArgs e)
        {
            playerChoice = 2;
            computerChoice = random.Next(3);
            ShowResult(playerChoice, computerChoice);
        }

        private void ShowResult(int playerChoice, int computerChoice)
        {
            string result = "";
            string whoWon = "";

            switch (playerChoice)
            {
                case 0:
                    PlayerChoice.Source = new BitmapImage(new Uri("/rock3.png", UriKind.Relative));
                    break;
                case 1:
                    PlayerChoice.Source = new BitmapImage(new Uri("/paper3.png", UriKind.Relative));
                    break;
                case 2:
                    PlayerChoice.Source = new BitmapImage(new Uri("/scissors3.png", UriKind.Relative));
                    break;
            }

            switch (computerChoice)
            {
                case 0:
                    ComputerChoice.Source = new BitmapImage(new Uri("/rock3.png", UriKind.Relative));
                    break;
                case 1:
                    ComputerChoice.Source = new BitmapImage(new Uri("/paper3.png", UriKind.Relative));
                    break;
                case 2:
                    ComputerChoice.Source = new BitmapImage(new Uri("/scissors3.png", UriKind.Relative));
                    break;
            }

            if (playerChoice == computerChoice)
            {
                result = "";
                whoWon = "It's a draw";
                Result.Text = result;
                WhoWon.Text = whoWon;
                SpeakText(whoWon);
                NumberOfDraws++;
            }
            else if (playerChoice == 0 && computerChoice == 1)
            {
                result = "Paper covers Rock";
                whoWon = "I win";
                Result.Text = result;
                WhoWon.Text = whoWon;
                SpeakText(result + "..." + whoWon);
                NumberOfLosses++;
            }
            else if (playerChoice == 1 && computerChoice == 0)
            {
                result = "Paper covers Rock";
                whoWon = "You win";
                Result.Text = result;
                WhoWon.Text = whoWon;
                SpeakText(result + "..." + whoWon);
                NumberOfWins++;
            }
            else if (playerChoice == 0 && computerChoice == 2)
            {
                result = "Rock breaks Scissors";
                whoWon = "You win";
                Result.Text = result;
                WhoWon.Text = whoWon;
                SpeakText(result + "..." + whoWon);
                NumberOfWins++;
            }
            else if (playerChoice == 2 && computerChoice == 0)
            {
                result = "Rock breaks Scissors";
                whoWon = "I win";
                Result.Text = result;
                WhoWon.Text = whoWon;
                SpeakText(result + "..." + whoWon);
                NumberOfLosses++;
            }
            else if (playerChoice == 1 && computerChoice == 2)
            {
                result = "Scissors cuts Paper";
                whoWon = "I win";
                Result.Text = result;
                WhoWon.Text = whoWon;
                SpeakText(result + "..." + whoWon);
                NumberOfLosses++;
            }
            else if (playerChoice == 2 && computerChoice == 1)
            {
                result = "Scissors cuts Paper";
                whoWon = "You win";
                Result.Text = result;
                WhoWon.Text = whoWon;
                SpeakText(result + "..." + whoWon);
                NumberOfWins++;
            }
            Record.Text = $"{NumberOfWins}-{NumberOfLosses}-{NumberOfDraws}";
        }

        public void SpeakText(string text)
        {
            synth.SpeakAsyncCancelAll();
            // Speak synchronously (freezes UI) or asynchronously (better for WPF)
            if (soundOn) synth.SpeakAsync(text);
        }

        private void Sound_Click(object sender, RoutedEventArgs e)
        {
            soundOn = !soundOn;
            if (soundOn)
                SoundImage.Source = new BitmapImage(new Uri("/soundOn2.png", UriKind.Relative));
            else
            {
                SoundImage.Source = new BitmapImage(new Uri("/soundOff2.png", UriKind.Relative));
                synth.SpeakAsyncCancelAll();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.WorkArea.Width;
            double screenHeight = SystemParameters.WorkArea.Height;

            // ensure window size doesn't exceed screen size
            if (this.Width > screenWidth) this.Width = screenWidth;
            if (this.Height > screenHeight) this.Height = screenHeight;

            // ensure window is not off the left or top
            if (this.Left < 0) this.Left = 0;
            if (this.Top < 0) this.Top = 0;

            // ensure window is not off the right or bottom
            if (this.Left + this.Width > screenWidth)
                this.Left = screenWidth - this.Width;
            if (this.Top + this.Height > screenHeight)
                this.Top = screenHeight - this.Height;
        }
    }
}
