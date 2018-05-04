using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultaeCEP.Servico.Modelo;
using App1_ConsultaeCEP.Servico;


namespace App1_ConsultaeCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
		}
        private void BuscarCEP(Object sender, EventArgs args)
        {


            // tood validações

            string cep = CEP.Text.Trim();

            if (isValidCEP(cep)) {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEndereçoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o cep informado:" + cep, "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
                
                }

            
        }
            private bool isValidCEP(string cep)
            {
            bool valido = true;
                if(cep.Length !=8)
            {
                DisplayAlert("Erro", "Cep invaldo! o cep deve conter 8 caracteres", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "Cep invaldo! o cep deve ser composto por numeros", "OK");
                valido = false;
            }
            return valido;
            }


        }
    }

