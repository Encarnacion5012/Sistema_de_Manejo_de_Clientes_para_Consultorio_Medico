using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Modelos
{
    public class ModeloPacientes
    {
        public int Id {  get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Direccion { get; set; }
        public string Telefono {  get; set; }
    }
}
