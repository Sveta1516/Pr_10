using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Kopytova.Classes
{
    public class Deutsch : Human
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

        public Deutsch(string Name, string Img) : base(Name, Img)
        {
            this.Phrases = AllPhrases();
        }

        public static List<Phrase> AllPhrases()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return new List<Phrase>
            {
                new Phrase("Hallo",                  System.IO.Path.Combine(baseDir, "Voices", "Hallo.mp3")),
                new Phrase("Wie geht es dir?",       System.IO.Path.Combine(baseDir, "Voices", "WieGehts.mp3")),
                new Phrase("Ich heiße Svetlana",     System.IO.Path.Combine(baseDir, "Voices", "IchHeisse.mp3"))
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
