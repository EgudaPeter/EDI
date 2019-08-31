using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace EDI
{
     class Settings
    {
        internal static SpeechRecognitionEngine engine;
        internal static SpeechSynthesizer edi;
        internal static Grammar grammer;
        internal static string instructions;
        internal static Process music;
    }
}
