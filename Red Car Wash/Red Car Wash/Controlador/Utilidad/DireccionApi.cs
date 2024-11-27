
using Xamarin.Forms;

namespace Red_Car_Wash.Controlador
{
    public class DireccionApi
    {
        public static string URL 
        {
            get 
            {
                const string defaultUrl = "https://app-da24803c-b24d-4c2f-9550-1686a5f43827.cleverapps.io/api/";
                /*
                if (Device.RuntimePlatform == Device.Android)
                {
                    defaultUrl = "http://10.0.2.2:3000/api/";
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    defaultUrl = "http://192.168.1.143:3000/api/";
                }*/

                return defaultUrl;
            }
        }
    }
}
