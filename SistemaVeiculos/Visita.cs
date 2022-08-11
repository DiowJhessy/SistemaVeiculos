using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVeiculos
{
    class Visita
    {
        public DateTime DataHora { get; set; }
        public List<Usuario> Visitas { get; set; } = new List<Usuario>();

        public Visita(DateTime dataHora, List<Usuario> visitas)
        {
            DataHora = dataHora;
            Visitas = visitas;
        }
    }
}
