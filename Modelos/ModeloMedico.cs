using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Modelos
{
    public class ModeloMedico
    {
        public int id {  get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Email {  get; set; }
    }
}
