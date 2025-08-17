using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Getion_de_Pasientes_de_Consultorio_Medico.Utilidades
{
    public class LimpiarCampos
    {
        public void limpiarCampos(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox txt)
                    txt.Clear();
                else if (c is ComboBox cb)
                    cb.SelectedIndex = -1;
                else if (c is DateTimePicker dtp)
                    dtp.Value = DateTime.Today;
                else if (c.HasChildren)
                    limpiarCampos(c); 
            }
        }
    }
}
