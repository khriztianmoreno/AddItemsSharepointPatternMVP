using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.SharePoint.Modelo
{
    public class RepositorioContacto
    {
        
        internal static void Guardar(Contacto _contacto)
        {
            String webUrl = "http://sharepointser";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (var site = new SPSite(webUrl))
                {
                    using (var web = site.OpenWeb())
                    {
                        SPListItemCollection list = web.Lists["Contactos"].Items;

                        SPListItem item = list.Add();
                        item["Title"] = _contacto.Nombre;
                        item["Identificacion"] = _contacto.Identificacion;

                        var allowUnsafeUpdates = web.AllowUnsafeUpdates;
                        web.AllowUnsafeUpdates = true;

                        item.Update();

                        web.AllowUnsafeUpdates = allowUnsafeUpdates;
                    }
                }
            });           
            
        }
        
    }
}
