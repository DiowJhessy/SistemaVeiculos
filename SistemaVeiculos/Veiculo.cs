using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVeiculos
{
    class Veiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }

        public Veiculo(string placa, string marca, string modelo, string cor)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }
    }
}
