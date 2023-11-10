using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JARVIS
{
    internal class Vocab
    {
        public static void WhatTimeIs()
        {
            Speaker.Speak(DateTime.Now.ToShortTimeString());
        }

        public static void Greeting()
        {
            Speaker.Speak("oi");
        }
        public static void podeMeOuvir()
        {
            Speaker.Speak("Sim, posso te ouvir");
        }
        public static void comoSeChama()
        {
            Speaker.Speak("Sou seu assistente virtual");
        }
        public static void QuemVoce()
        {
            Speaker.Speak("Sou um assistente virtual");
        }
        public static void oqueFaz()
        {
            Speaker.Speak("Sou capaz de acionar alguns atalhos, te dizer o estado dos motores, e responder algumas perguntas");
        }
        public static void Resposta1()
        {
            Speaker.Speak("sei la");
        }
    }
}
