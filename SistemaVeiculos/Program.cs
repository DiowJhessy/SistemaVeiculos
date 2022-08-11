using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
    

namespace SistemaVeiculos
{
    class Program
    {
        static List<Usuario> usuario = new List<Usuario>();
        static LocaisVisita local = new LocaisVisita();

        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                Menu();
                op = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (op)
                {
                    case 1: CadastraUsuario(); break;
                    case 2: CadastraVeiculo(); break;
                    case 3: ModificarDados(); break;
                    case 4: MostrarDados(); break;
                    case 5: RegistrarVisita(); break;
                }
            } while (op != 6);
        }
        static void Menu()
        {
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Cadastrar Veículo");
            Console.WriteLine("3 - Modificar dados");
            Console.WriteLine("4 - Mostrar dados");
            Console.WriteLine("5 - Registrar Visita");
            Console.WriteLine("6 - Sair\n");
        }
        static void CadastraUsuario()
        {
            string cpf, nome, cnh;
            Boolean cpfOriginal = true;

            Console.Write("CPF: ");
            cpf = Console.ReadLine();
            foreach (Usuario obj in usuario)
            {
                if (obj.CPF == cpf)
                {
                    Console.WriteLine("CPF já cadastrado!\n");
                    cpfOriginal = false;
                    break;
                }
            }
            if (cpfOriginal)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                Console.Write("CNH: ");
                cnh = Console.ReadLine();
                usuario.Add(new Usuario(cpf, nome, cnh));
                Console.WriteLine($"\nUsuário '{nome}' cadastrado com sucesso!\n");
            }
        }
        static void CadastraVeiculo()
        {
            string placa, marca, modelo, cor;
            Boolean placaOriginal = true, cpfExiste = false;
            List<string> placaLista = new List<string>();

            Console.Write("CPF do condutor: ");
            string cpfCondutor = Console.ReadLine();

            foreach (Usuario obj in usuario)
            {
                if (obj.CPF == cpfCondutor)
                {
                    cpfExiste = true;
                    Console.Write("Placa do veículo: ");
                    placa = Console.ReadLine();

                    obj.PlacaOriginal(placa, placaOriginal);

                    if (placaOriginal)
                    {
                        Console.Write("Marca: ");
                        marca = Console.ReadLine();
                        Console.Write("Modelo: ");
                        modelo = Console.ReadLine();
                        Console.Write("Cor: ");
                        cor = Console.ReadLine();
                        obj.AddVeiculo(placa, marca, modelo, cor);
                        Console.WriteLine($"Veículo de placa '{placa}' cadastrado com sucesso!\n");
                    }
                    break;
                }
            }
            if (!cpfExiste) Console.WriteLine("\nUsuário/CPF nao cadastrado!\n");
        }
        static void ModificarDados()
        {

        }
        static void MostrarDados()
        {
            int cont = 0;
            foreach (Usuario obj2 in usuario)
            {
                cont++;
            }

            if (cont == 0) Console.WriteLine("Nenhum Usuario cadastrado!");

            else
            {
                foreach (Usuario obj in usuario)
                {
                    Console.WriteLine(obj);
                }
            }
        }
        static void RegistrarVisita()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", false);

            Console.Write("CPF do Visitante: ");
            string cpfVisitante = Console.ReadLine();
            foreach (Usuario obj in usuario)
            {
                if (obj.CPF == cpfVisitante)
                {
                    DateTime dataEntrada = DateTime.Now;
                    Console.Write($"Data e hora atual: {dataEntrada} - Usar essa data/hora 'S'(Sim) 'N'(Nao): ");
                    char op = char.Parse(Console.ReadLine());
                    if (op == 'N' || op == 'n')
                    {
                        Console.WriteLine("Digite a data e hora manualmente:");
                        Console.Write("Ano: "); int ano = int.Parse(Console.ReadLine());
                        Console.Write("Mes: "); int mes = int.Parse(Console.ReadLine());
                        Console.Write("Dia: "); int dia = int.Parse(Console.ReadLine());
                        Console.Write("Hora: "); int hora = int.Parse(Console.ReadLine());
                        Console.Write("Minutos: "); int min = int.Parse(Console.ReadLine());
                        dataEntrada = new DateTime(ano, mes, dia, hora, min, 00);
                    }
                    Console.WriteLine("Local de visita: ");//Dropdown aqui
                    Console.WriteLine(local);
                    //foreach (LocaisVisita obj in local)
                    //{
                        
                    //}
                }
                else Console.WriteLine("CPF não cadastrado!");
            }

            //Console.Write("Data da entrada (dd/mm/yyyy): ");
            //string data = Console.ReadLine();
            //Console.Write("Hora da entrada (00:00): ");
            //string hora = Console.ReadLine();
            //string ddMMyyyy = data + hora;
        }
    }
}
