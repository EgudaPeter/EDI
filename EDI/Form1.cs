using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace EDI
{
    public partial class EDI : Form
    {
        public EDI()
        {
            InitializeComponent();
        }

        private void EDI_Load(object sender, EventArgs e)
        {
            Settings.engine = new SpeechRecognitionEngine();
            Settings.engine.SetInputToDefaultAudioDevice();
            Settings.grammer = Custom_Grammar.myGrammer();
            Settings.engine.LoadGrammar(Settings.grammer);
            Settings.engine.RecognizeAsync(RecognizeMode.Multiple);
            Settings.engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speech_Recognised_Class.engine_SpeechRecognized);
        }
    }
}
