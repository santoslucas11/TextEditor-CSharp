using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine("");
            Console.WriteLine("1- Abrir Arquivo");
            Console.WriteLine("2- Novo Arquivo");
            Console.WriteLine("");
            Console.WriteLine("0- Sair");

            short option = short.Parse(Console.ReadLine());

            switch(option){
                
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir(){
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo ?");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path)){
                string texto = file.ReadToEnd();
                Console.WriteLine(texto);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }

        static void Editar(){
            Console.Clear();

            Console.WriteLine("Digite seu texto abaixo (Tecle ESC para sair)");
            Console.WriteLine("-----------------------");

            string texto = "";

            do{
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Write(texto);
        }
    
        static void Salvar(string texto){
            Console.Clear();
            Console.WriteLine("Onde voce deseja salvar seu arquivo ?");

            var path = Console.ReadLine();

            using(var file = new StreamWriter(path)){
                file.Write(texto);
            }
        }
    }
}
