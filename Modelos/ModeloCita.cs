using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Modelos
{
    public class ModeloCita
    {
        public int id { get; set; } 
        public int idPaciente { get; set; }
        public int idMedico { get; set; }   
        public string Motivo {  get; set; }
        public string EstadoCita {  get; set; }
        public DateTime FechaHora { get; set; }
    }
}
