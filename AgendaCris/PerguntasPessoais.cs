using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaCris
{
    public class PerguntasPessoais
    {
        public ViaPessoal ConsultaPessoais()
        {

            ViaPessoal oViaPessoal = new ViaPessoal();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------------WELCOME--------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("-Me informe algumas informações importantes:-");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1º Nome................:");
            string Nome = Console.ReadLine();
            Console.WriteLine("2º Sobrenome...........:");
            string Sobrenome = Console.ReadLine();
            Console.WriteLine("3º Data Nascimento.....:");
            string DataNascimento = Console.ReadLine();
        Rotulo_Sexo:
            Console.WriteLine("4º Sexo................:");
            String Sexo = Console.ReadLine();
            if (Sexo.ToUpper() == "F" || Sexo.ToUpper() == "M")
            {
                Console.WriteLine("====> Sexo Ok:" + Sexo);

                oViaPessoal.Nome = Nome;
                oViaPessoal.Sobrenome = Sobrenome;
                oViaPessoal.DataNascimento = DateTime.Parse(DataNascimento);
                oViaPessoal.Sexo = Sexo;
            }
            else
            {
                Console.WriteLine("=====================================");
                Console.WriteLine(" **** Informe Sexo Corretamente ****");
                Console.WriteLine(" (F) para Femenino ");
                Console.WriteLine(" (M) para Masculino ");
                Console.WriteLine("=====================================");
                goto Rotulo_Sexo;
            }

            return oViaPessoal;
        }
    }
}

