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
    static class speech_Recognised_Class
    {
 
        internal static void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            EDI eee = new EDI();
            Settings.edi = new SpeechSynthesizer();
            Settings.edi.Volume = 100;
            Settings.edi.Rate = 1;
            Settings.instructions = e.Result.Text;
             try
             {
                 switch (e.Result.Text)
                 {
                     //Greetings
                     case "Edi":
                     case "Hello Edi":
                     case "Hello":
                     case "Good Morning Edi":
                     case "Good Morning":
                     case "Good Evening Edi":
                     case "Good Evening":
                     case "Good Afternoon Edi":
                     case "Good Afternoon":
                         if (DateTime.Now.ToString("hh:mm:ss:tt").Contains("AM"))
                         {
                             Settings.edi.Speak("Good morning.");
                         }
                         else if (DateTime.Now.Hour>=12 && DateTime.Now.Hour<16)
                         {
                             Settings.edi.Speak("Good afternoon.");
                         }
                         else if (DateTime.Now.Hour > 16)
                         {
                             Settings.edi.Speak("Good evening.");
                         }
                         break;

                     case "How are you?":
                     case "How you?":
                     case "How are you doing?":
                         Settings.edi.Speak("I'm okay, thank you.");
                         break;

                     //Commands
                     case "Activate Notepad":
                     case "Open Notepad":
                             Settings.edi.Speak("Activating Notepad");
                             Process.Start("notepad.exe");
                             Settings.edi.Speak("Notepad activated");
                         
                         break;
                     case "Close Notepad":
                     case "Deactivate Notepad":
                             Settings.edi.Speak("Closeing Notepad.");
                             terminateWindow("notepad");
                         Settings.edi.Speak("Notepad Closed.");
                         break;

                     case "Open Music Folder":
                     case "Close Music Folder":
                          Process musicFolder = new Process();
                         if (e.Result.Text.Equals("Open Music Folder"))
                         {
                             string filePath = @"C:\Users\Peter\Desktop\Music";
                             Settings.edi.Speak("Opening Music folder.");
                             musicFolder.StartInfo.FileName= filePath;
                             musicFolder.Start();
                             Settings.edi.Speak(" Music folder opened.");
                         }
                         else if (e.Result.Text.Equals("Close Music Folder"))
                         {
                             Settings.edi.Speak("Closing Music Folder.");
                             Process [] processesActive = Process.GetProcessesByName("explorer.exe");
                             foreach (Process p in Process.GetProcessesByName("explorer"))
                             {
                                 p.Kill();
                             }
                             Settings.edi.Speak("Music Folder closed.");
                         }
                         break;

                     case "Open Music":
                         Process.Start("WWAHost.exe");
                         break;
                     //case "Close Music Folder":
                     //    Settings.edi.Speak("Closing Music Folder.");
                     //    musicFolder.CloseMainWindow();
                     //    musicFolder.Close();
                     //    Settings.edi.Speak("Music Folder closed.");
                     //    break;
                 }
             }
             catch(Exception ex)
             {
                 Settings.edi.Speak("Something is wrong. I do not understand");
             }
        }

        private static void terminateWindow(string processName)
        {
            foreach (Process p in Process.GetProcessesByName(processName))
            {
                p.CloseMainWindow();
                p.Close();
            }
        }

        private static Process window (string path)
        {
           return Process.Start(path);
        }
    }
}
