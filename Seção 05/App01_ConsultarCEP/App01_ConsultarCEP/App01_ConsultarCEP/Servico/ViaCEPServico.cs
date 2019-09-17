using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURl = "http://viacep.com.br/ws/{0}/json";
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoUrl = String.Format(EnderecoURl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            if (end == null) return null;

            return end;
        }
    }
}