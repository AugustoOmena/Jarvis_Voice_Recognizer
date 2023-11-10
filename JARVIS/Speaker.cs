using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

namespace JARVIS
{
    internal class Speaker
    {
        private static SpeechSynthesizer sp = new SpeechSynthesizer();
        public static void Speak(string text)
        {
            //caso ele esteja falando
            if (sp.State == SynthesizerState.Speaking)
            
                sp.SpeakAsyncCancelAll();
                sp.SpeakAsync(text);
            
        }
    }
}
