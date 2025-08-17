using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Modelos
{
    public class ModeloDiagnostico
    {
        public int id { get; set; }
        public int idPaciente { get; set; }
        public int idMedico { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public DateTime FechaCita { get; set; }

    }
}
