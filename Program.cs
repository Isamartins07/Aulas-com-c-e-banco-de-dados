using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCadastro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  incluir();

            // alterar();

            // deletar();
            string opcao;
            
            //Criando um manu com switch case


            do
            {
                Console.WriteLine("Escolha uma operação:");
                Console.WriteLine("1 - Cadastrar Clientes");
                Console.WriteLine("2 - Alterar Cadastro de um Cliente");
                Console.WriteLine("3 - Apagar Cadastro de um Cliente");
                Console.WriteLine("4 - Exibição dos Cadastros");


                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        incluir();
                        break;

                    case 2:
                        alterar();
                        break;

                    case 3:
                        deletar();
                        break;

                    case 4:
                        exibir();
                        break;


                    default:
                        Console.WriteLine("Operação inválida.");
                        break;
                }
                Console.WriteLine("Deseja Continuar? (S/N)");
                opcao = Console.ReadLine().ToUpper();
            }
            while (opcao == "S");

            }

            

        private static void exibir()
        {
            using (var contexto = new CadastroClientesEntities())
            {
                // Exemplo de consulta simples para selecionar todos os usuários da agenda
                var Cadastros = contexto.Cadastros.ToList();

                foreach (var cadastros in Cadastros)
                {
                    Console.WriteLine($"ID: {cadastros.CadastrosID}, Nome: {cadastros.NomeCliente}," +
                        $" Endereco: {cadastros.Endereco}, Cidade: {cadastros.Cidade}, Telefone: {cadastros.TelefoneContato}");
                }
            }
            Console.ReadKey();
        }


        private static void deletar()
        {
            using (var contexto = new CadastroClientesEntities())
            {
                Console.WriteLine("Digite o ID Cliente que deseja apagar: ");
                var busca = contexto.Cadastros.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Você está prestes a apagar o cadastro do cliente {busca.NomeCliente}");
                Console.WriteLine("Tem certeza que deseja apagar, digite S para confirmar ou qualquer tecla para anular");
                var apaga = Console.ReadLine().ToUpper();
                if ( apaga == "S")
                {
                    contexto.Cadastros.Remove(busca);
                    contexto.SaveChanges();
                    Console.WriteLine("Cadastro do cliente apagado com sucesso!");
                }
                else 
                {
                    Console.WriteLine("Operação anulada");
                
                }    

            }
        }




        private static void alterar()
        {
           using (var contexto = new CadastroClientesEntities())
            {
                Console.WriteLine("Digite o ID Cliente que deseja alterar: ");
                var busca = contexto.Cadastros.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine(busca.NomeCliente);
                Console.WriteLine(busca.Endereco);
                Console.WriteLine(busca.Cidade);
                Console.WriteLine(busca.TelefoneContato);
                Console.WriteLine("Entre com a correção do Nome: ");
                busca.NomeCliente = Console.ReadLine();
                Console.WriteLine("Entre com a correção do Endereço: ");
                busca.Endereco = Console.ReadLine();
                Console.WriteLine("Entre com a correção da Cidade: ");
                busca.Cidade = Console.ReadLine();
                Console.WriteLine("Entre com a correção do Telefone: ");
                busca.TelefoneContato = Console.ReadLine();

                contexto.SaveChanges();
                Console.WriteLine("Cadastro alterado com sucesso! ");
            }
        }






        private static void incluir ()
         {

            string Nome, Endereco, Cidade, Telefone, Cadastro;


            Console.WriteLine("Digite seu nome: ");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite seu endereço: ");
            Endereco = Console.ReadLine();
            Console.WriteLine("Digite sua cidade: ");
            Cidade = Console.ReadLine();
            Console.WriteLine("Digite seu telefone: ");
            Telefone = Console.ReadLine();
            Console.WriteLine("Cadastro realizado!");
            Cadastro = Console.ReadLine();


            using (var contexto = new CadastroClientesEntities())
            {
                contexto.Cadastros.Add(new Cadastros()
                {
                    NomeCliente = Nome,
                    Endereco = Endereco,
                    Cidade = Cidade,
                    TelefoneContato = Telefone
                });
                contexto.SaveChanges();

            }

            Console.ReadKey();

        }

       
      






    }
}
