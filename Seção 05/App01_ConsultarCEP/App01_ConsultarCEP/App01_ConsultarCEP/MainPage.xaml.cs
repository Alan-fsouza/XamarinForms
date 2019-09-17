using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Lógica do programa.
            string cep = CEP.Text.Trim();
            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = String.Format("Endereço: {2} de {3} {0},{1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado " + cep, "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRITICO", ex.Message, "OK");
                }
            }
        }

        private bool IsValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO!", "CEP inválido! O CEP deve conter 8 caracteres", "OK");
                valido = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO!", "CEP inválido! O CEP deve ser composto apenas com numeros.", "OK");

                valido = false;
            }

            return valido;
        }
    }
}
