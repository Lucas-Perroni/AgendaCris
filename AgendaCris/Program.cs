using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaCris
{
    class Program
    {
        static async Task Main(string[] args)

        {
            Boolean Consulta = true;
            Console.Clear();
            List<ViaPessoal> ListaAgenda = new List<ViaPessoal>();
            ViaPessoal viaPessoal = new ViaPessoal();
            ViaPessoal viaCEP = new ViaPessoal();F

            //CRIANDO O VIACEP DESSA PAGINA
            //ViaCEP viaCEP = new ViaCEP();

            PerguntasPessoais oConsultaPessoais = new PerguntasPessoais();
            viaPessoal = oConsultaPessoais.ConsultaPessoais();
            ListaAgenda.Add(viaPessoal);
            
            while (Consulta)
            {
                try
                {
                    Console.WriteLine("5º Informe o CEP.......:");  
                    String CEP = Console.ReadLine();

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("-------Agora o que deseja fazer:--------");
                    Console.WriteLine("1º SAIR");
                    Console.WriteLine("2º SALVAR");
                    Console.WriteLine("3º LISTAR");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Escolha um dos quatros numeros:");
                    Console.WriteLine("----------------------------------------");
                    String NumeroEscolhido = Console.ReadLine();

                    //PARTE DE PESQUISA DO CEP
                    ConsultarCEP oConsultaCEP = new ConsultarCEP();
                    viaCEP = oConsultaCEP.Consulta(CEP);

                    ListaAgenda.Add(viaCEP);
                    switch (NumeroEscolhido.ToUpper())
                    {
                        case "1":
                            Consulta = false;
                            break;
                        case "2":
                            string filePath = @"c:\temp\ListaCEP.JSON";
                            var ObjetoDados = JsonConvert.SerializeObject(ListaAgenda);
                            await File.WriteAllTextAsync(filePath, ObjetoDados);
                            Console.WriteLine("Dados Salvos com Sucesso !!!");
                            break;      
                        case "3":
                            Console.WriteLine("cep........:" + viaCEP.cep.ToString());
                            Console.WriteLine("logradouro.:" + viaCEP.logradouro.ToString());
                            Console.WriteLine("complemento:" + viaCEP.complemento.ToString());
                            Console.WriteLine("bairro.....:" + viaCEP.bairro.ToString());
                            Console.WriteLine("localidade.:" + viaCEP.localidade.ToString());
                            Console.WriteLine("uf.........:" + viaCEP.uf.ToString());
                            Console.WriteLine("ibge.......:" + viaCEP.ibge.ToString());
                            Console.WriteLine("gia........:" + viaCEP.gia.ToString());
                            Console.WriteLine("ddd........:" + viaCEP.ddd.ToString());
                            Console.WriteLine("siafi......:" + viaCEP.siafi.ToString());
                            break;
                        default:
                            {
                                //ConsultarCEP RetornoConsultaviaCEP = new ConsultarCEP();
                                //ViaCEP oViacep = new ViaCEP();
                                //oViacep = RetornoConsultaviaCEP.Consulta(CEP);
                                //ListaCEP.Add(oViacep);
                                //Console.WriteLine("--[ Resultado de pesquisa ]----------------------------");
                                //Console.WriteLine("cep........:" + oViacep.cep.ToString());
                                //Console.WriteLine("logradouro.:" + oViacep.logradouro.ToString());
                                //Console.WriteLine("complemento:" + oViacep.complemento.ToString());
                                //Console.WriteLine("bairro.....:" + oViacep.bairro.ToString());
                                //Console.WriteLine("localidade.:" + oViacep.localidade.ToString());
                                //Console.WriteLine("uf.........:" + oViacep.uf.ToString());
                                //Console.WriteLine("ibge.......:" + oViacep.ibge.ToString());
                                //Console.WriteLine("gia........:" + oViacep.gia.ToString());
                                //Console.WriteLine("ddd........:" + oViacep.ddd.ToString());
                                //Console.WriteLine("siafi......:" + oViacep.siafi.ToString());
                                //Console.WriteLine("-------------------------------------------------------");
                                //Console.WriteLine(" Pressione <ENTER> para continuar ou Exit para sair");
                                //Console.WriteLine("-------------------------------------------------------");
                                //String Sair = Console.ReadLine();
                                //if (Sair.ToUpper() == "EXIT")
                                //{
                                //   Consulta  = false;
                                //}
                            }
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("--- Atenção ocorreu um erro ---------------------------");
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine(ex.Message.ToString());
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("--[pressione <Enter> para continuar ]------------------");
                    Console.WriteLine("-------------------------------------------------------");

                    Console.ReadLine();
                }
            }
        }
    }
}
