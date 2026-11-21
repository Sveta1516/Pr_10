using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Human_Kopytova.Classes
{
    public class English : Human
    {
        private List<Phrase> Phrases { get; set; }
        private int stepAudio;

        private int StepAudio
        {
            get { return stepAudio; }
            set
            {
                stepAudio = value;
                if (stepAudio > Phrases.Count - 1)
                    stepAudio = 0;
            }
        }

        public English(string Name, string Img) : base(Name, Img)
        {
            this.Phrases = AllPhrases();
        }

        public static List<Phrase> AllPhrases()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return new List<Phrase>
            {
                new Phrase("Hello",                  System.IO.Path.Combine(baseDir, "Voices", "Hello.mp3")),
                new Phrase("How are you?",           System.IO.Path.Combine(baseDir, "Voices", "HowAreYou.mp3")),
                new Phrase("My name is Svetlana",    System.IO.Path.Combine(baseDir, "Voices", "MyName.mp3"))
            };
        }

        public override void Speak(Label phraseLabel)
        {
            phraseLabel.Content = Phrases[StepAudio]._Phrase;
            MainWindow.MediaPlayer.Open(new Uri(Phrases[StepAudio].Src));
            MainWindow.MediaPlayer.Play();
            StepAudio++;
        }
    }
}

