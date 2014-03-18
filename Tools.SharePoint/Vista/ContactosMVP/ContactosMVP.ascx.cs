using Microsoft.SharePoint.Utilities;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Tools.SharePoint.Presentador;

namespace Tools.SharePoint.Vista.ContactosMVP
{
    [ToolboxItemAttribute(false)]
    public partial class ContactosMVP : WebPart, IVistaContactos
    {
        private readonly PresentadorContacto presentador;

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ContactosMVP()
        {
            presentador = new PresentadorContacto(this);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                presentador.InicializarVista();
            }
            
        }

        #region IVistaContactos
        public string Nombre
        {
            get { return !string.IsNullOrEmpty(txtNombre.Text) ? txtNombre.Text : string.Empty; }
            set { txtNombre.Text = value.ToString(); }
        }

        public string Identificacion
        {
            get { return !string.IsNullOrEmpty(txtIdentificacion.Text) ? txtIdentificacion.Text : string.Empty; }
            set { txtIdentificacion.Text = value.ToString(); }
        }
        #endregion

        protected void txtGuardar_Click(object sender, EventArgs e)
        {
            presentador.GuardarContacto();
            
        }
    
    }
}
