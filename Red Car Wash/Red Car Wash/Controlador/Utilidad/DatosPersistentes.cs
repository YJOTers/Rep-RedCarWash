using Xamarin.Forms;

namespace Red_Car_Wash.Controlador
{
    public static class DatosPersistentes
    {
        public static void GuardarDatos(string correo, string clave)
        {
            Application.Current.Properties["Correo"] = correo;
            Application.Current.Properties["Clave"] = clave;
        }

        public static string[] ObtenerDatos()
        {
            string[] datos = new string[2];
            if (Application.Current.Properties.Count == 2) 
            {
                datos[0] = Application.Current.Properties["Correo"].ToString();
                datos[1] = Application.Current.Properties["Clave"].ToString();
            }
            return datos;
        }

        public static void EliminarDatos()
        {
            Application.Current.Properties.Clear();
        }
    }
}
