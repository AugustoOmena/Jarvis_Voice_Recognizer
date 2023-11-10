using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Security.Cryptography;

namespace JARVIS
{
    public class GrammarRules
    {
        public static IList<string> WhatTimeIs = new List<string>()
        {
            "Que horas são",
            "Me diga as horas",
            "Poderia me dizer que horas são",
            "Google que horas são"
        };

        public static IList<string> Greeating = new List<string>()
        {
            "Google",
            "Oi Google",
            "OK Google"
        };
        public static IList<string> podeMeOuvir = new List<string>()
        {
            "Pode me ouvir",
            "Ta me ouvindo"
        };
        public static IList<string> qualSeuNome = new List<string>()
        {
            "qual é o seu nome",
            "Como você se chama",
            "Quem é voce"
        };
        public static IList<string> quemVoce = new List<string>()
        {
            "Quem é voce",
            "conte mais sobre voce",
            "o que voce é"
        };
        public static IList<string> oquefaz = new List<string>()
        {
            "o que voce faz",
            "o que voce consegue fazer",
            "o que voce sabe fazer"
        };
        public static IList<string> Pergunta1 = new List<string>()
        {
            "Como vai",
            "Quem descobriu o brasil",
            "Quem é a assistente google",
            "O que voce gosta de fazer"
        };
    }
}
