
namespace Red_Car_Wash.Modelo
{
    public class RegDeVehiculoModeloVista
    {
        public long id_rv { get; set; }
        public string placa_rv { get; set; }
        public string cliente_rv { get; set; }
        public string tipoDeVehiculo_tdv { get; set; }
        public string nombreColor_color { get; set; }
        public string nombreMarca_marca { get; set; }
        public long id_uc_rv { get; set; }
    }

    public class RegDeVehiculoModelo
    {
        public long id_rv { get; set; }
        public string placa_rv { get; set; }
        public string cliente_rv { get; set; }
        public long id_tdv_rv { get; set; }
        public long id_color_rv { get; set; }
        public long id_marca_rv { get; set; }
        public long id_uc_rv { get; set; }
    }
}
