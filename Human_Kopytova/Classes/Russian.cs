using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Human_Kopytova.Classes
{
    public class Russian : Human
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
        public Russian(string Name, string Img) : base(Name, Img)
        {
            this.Phrases = AllPhrases();
        }

        public static List<Phrase> AllPhrases()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return new List<Phrase>
            {
                new Phrase("Привет", System.IO.Path.Combine(baseDir, "Voices", "C:\\Users\\MateBook\\Downloads\\Human_Kopytova\\Human_Kopytova\\Voices\\Voice1.mp3")),
                new Phrase("Как дела?",System.IO.Path.Combine(baseDir, "Voices", "C:\\Users\\MateBook\\Downloads\\Human_Kopytova\\Human_Kopytova\\Voices\\Voice2.mp3")),
                new Phrase("Меня зовут Светлана", System.IO.Path.Combine(baseDir, "Voices", "C:\\Users\\MateBook\\Downloads\\Human_Kopytova\\Human_Kopytova\\Voices\\Voice3.mp3"))
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
