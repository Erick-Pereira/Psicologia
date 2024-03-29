﻿using Newtonsoft.Json;
using Shared.Extensions;
using System.Net;

namespace BusinessLogicalLayer.API
{
    //ESSA CLASSE NÃO ESTA SENDO USADA NO PRODUTO FINAL
    public class CepAPI
    {
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /// <summary>
        /// Recebe um CEP e busca, atravez de uma API, o endereço referente ao CEP
        /// </summary>
        /// <param name="cep"></param>
        /// <returns>Retorna um CepAPI contendo o Endereco preenchido</returns>
        public static CepAPI Busca(string cep)
        {
            if (!string.IsNullOrWhiteSpace(cep))
            {
                var cepObj = new CepAPI();
                var url = "https://apps.widenet.com.br/busca-cep/api/cep.json?code=" + cep.StringCleaner();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                string json = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
                JsonCepObject cepJson = JsonConvert.DeserializeObject<JsonCepObject>(json);
                cepObj.CEP = cepJson.code;
                cepObj.Cidade = cepJson.city;
                cepObj.Endereco = cepJson.address;
                cepObj.Bairro = cepJson.district;
                cepObj.Estado = cepJson.state;
                return cepObj;
            }
            return new CepAPI();
        }
    }

    internal class JsonCepObject
    {
        public string code { get; set; }

        public string state { get; set; }

        public string city { get; set; }

        public string district { get; set; }
        public string address { get; set; }
    }
}