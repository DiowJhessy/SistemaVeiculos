using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVeiculos
{
    class Usuario
    {
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public List<Visita> Visita { get; set; } = new List<Visita>();
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string CNH { get; set; }

        public Usuario(string cpf, string nome, string cnh)
        {
            CPF = cpf;
            Nome = nome;
            CNH = cnh;
        }

        public void AddVeiculo(string placa, string marca, string modelo, string cor)
        {
            Veiculos.Add(new Veiculo(placa, marca, modelo, cor));
        }

        public void RemoveVeiculo(string placa)
        {
            foreach(Veiculo obj in Veiculos)
            {
                if (obj.Placa == placa) Veiculos.Remove(obj);
            }
        }

        public Boolean PlacaOriginal(string placa, Boolean original)//Ainda nao sei como fazer a verificação da lista funcionar sem ter iniciado a mesma.
        {
            foreach (Veiculo obj in Veiculos)
            {
                if (obj.Placa == placa)
                {
                    original = false; break;
                }
            }
            return original;
        }

        public override string ToString()
        {
            int cont = 0;
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendLine($"CPF: {CPF}\n" +
                $"Nome: {Nome}\n" +
                $"CNH: {CNH}\n" +
                $"\nVeiculo(s):");
            foreach(Veiculo obj in Veiculos)
            {
                cont++;
                mostrar.AppendLine
                    ($"Placa: {obj.Placa}\n" +
                    $"Marca: {obj.Marca}\n" +
                    $"Modelo: {obj.Modelo}\n" +
                    $"Cor: {obj.Cor}");
            }
            if (cont == 0) mostrar.AppendLine("Nenhum veiculo cadastrado");
            return mostrar.ToString();
        }
    }
}
