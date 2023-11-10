using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;

namespace JARVIS
{
    
    public partial class Form1 : Form
    {
       
        private SpeechRecognitionEngine ReconhecimentoVoz;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadSpeech()
        {
            try
            {
                ReconhecimentoVoz = new SpeechRecognitionEngine();
                ReconhecimentoVoz.SetInputToDefaultAudioDevice(); // microfone
                Choices PalavrasReconhecidasPelaIA = new Choices();
                PalavrasReconhecidasPelaIA.Add(GrammarRules.WhatTimeIs.ToArray());
                PalavrasReconhecidasPelaIA.Add(GrammarRules.Greeating.ToArray());
                PalavrasReconhecidasPelaIA.Add(GrammarRules.podeMeOuvir.ToArray());
                PalavrasReconhecidasPelaIA.Add(GrammarRules.qualSeuNome.ToArray());
                PalavrasReconhecidasPelaIA.Add(GrammarRules.quemVoce.ToArray());
                PalavrasReconhecidasPelaIA.Add(GrammarRules.oquefaz.ToArray());
                PalavrasReconhecidasPelaIA.Add("Computador");

                GrammarBuilder VareaveisDasPalavrasReconhecidas = new GrammarBuilder();
                VareaveisDasPalavrasReconhecidas.Append(PalavrasReconhecidasPelaIA);
                Grammar g_commandOfSystem = new Grammar(VareaveisDasPalavrasReconhecidas);
                g_commandOfSystem.Name = "derivadosHora";
                ReconhecimentoVoz.LoadGrammar(g_commandOfSystem);
                ReconhecimentoVoz.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(audioReconhecido);// Reconhecimento
                ReconhecimentoVoz.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel);//Movimenta o ProgressBar de Voz
                ReconhecimentoVoz.RecognizeAsync(RecognizeMode.Multiple); // iniciar o Reconhecimento
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu no LoadSpeech(): " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
            Speaker.Speak("Carregamento Completo");
        }

        private void audioReconhecido(object s, SpeechRecognizedEventArgs e)
        {
            
            string speech = e.Result.Text;
            tBFalou.Text = speech;
            float conf = e.Result.Confidence;
            if (conf > 0.35f)
            {
                switch (e.Result.Grammar.Name)
                {
                    case "derivadosHora":
                        if (GrammarRules.WhatTimeIs.Any(X => X == speech))
                        {
                            Vocab.WhatTimeIs();
                            break;
                        }
                        else if(GrammarRules.Greeating.Any(X => X == speech))
                        {
                            Vocab.Greeting();
                            break;
                        } else if (GrammarRules.podeMeOuvir.Any(X => X == speech))
                        {
                            Vocab.podeMeOuvir();
                            break;
                        } else if (GrammarRules.qualSeuNome.Any(X => X == speech))
                        {
                            Vocab.comoSeChama();
                            break;
                        } else if (GrammarRules.quemVoce.Any(X => X == speech))
                        {
                            Vocab.QuemVoce();
                            break;
                        } else if (GrammarRules.oquefaz.Any(X => X == speech))
                        {
                            Vocab.oqueFaz();
                            break;
                        } else if (GrammarRules.Pergunta1.Any(X => X == speech)) 
                        {
                            Vocab.Resposta1();
                            break;
                        }
                        break;
                }
            }
        }

        private void audioLevel(object s, AudioLevelUpdatedEventArgs e)
        {
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = e.AudioLevel;
        }
    }
}
