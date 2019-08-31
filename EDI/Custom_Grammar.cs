﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    class Custom_Grammar
    {
        internal static Grammar myGrammer()
        {
            string[] words = new string[] { "Edi", "Dictation", "How are you?", "How you?", "How are you doing?", "Notepad", "Music Folder","Music" };
            string[] actions = new string[] { "Activate", "Deactivate", "Open", "Close" };
            string[] greetings = new string[] { "Hello","Good Morning","Good Afternoon", "Good Evening", };
            GrammarBuilder gb_WordsAndGreetings = new GrammarBuilder(new Choices(greetings)); gb_WordsAndGreetings.Append(new Choices(words));
            GrammarBuilder gb_WordsAndActions = new GrammarBuilder(new Choices(actions)); gb_WordsAndActions.Append(new Choices(words));
            GrammarBuilder gb_Words = new GrammarBuilder(new Choices(words));
            GrammarBuilder gb_Greetings = new GrammarBuilder(new Choices(greetings));
            GrammarBuilder gb_Actions = new GrammarBuilder(new Choices(actions));
            Grammar g = new Grammar(new Choices(gb_WordsAndGreetings, gb_WordsAndActions, gb_Words, gb_Greetings, gb_Actions));
            return g;
        }
    }
}
