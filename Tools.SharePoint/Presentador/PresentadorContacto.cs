using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.SharePoint.Modelo;

namespace Tools.SharePoint.Presentador
{
    public class PresentadorContacto
    {
        private readonly IVistaContactos _vista;
        private Contacto _contacto;

        public PresentadorContacto(IVistaContactos vista)
        {
            _vista = vista;
            _contacto = new Contacto();
        }

        public void GuardarContacto()
        {
            // Llamada a la capa de servicios / negocio ..
            _contacto.Identificacion = _vista.Identificacion;
            _contacto.Nombre = _vista.Nombre;

            RepositorioContacto.Guardar(_contacto);

            //ActualizarVista(emp);
        }

        public void InicializarVista()
        {
            _vista.Identificacion = string.Empty;
            _vista.Nombre = string.Empty;

        }

        public void ActualizarVista(Contacto contacto)
        {
            _vista.Identificacion = contacto.Identificacion;
            _vista.Nombre = contacto.Nombre;

        }
    }
}
