using System;

namespace Red_Car_Wash.Modelo
{
    public class ServiciosModeloVista 
    {
        public long id_servicios { get; set; }
        public DateTimeOffset fecha_servicios { get; set; }
        public string placa_rv { get; set; }
        public string tipoDeVehiculo_tdv { get; set; }
        public string tipoLavado_rtl { get; set; }
        public float precioPublico_rtl { get; set; }
        public float precioPagado_servicios { get; set; }
        public float precioPendiente_servicios { get; set; }
        public long id_uc_servicios { get; set; }
    }

    public class ServiciosModelo
    {
        public long id_servicios { get; set; }
        public DateTimeOffset fecha_servicios { get; set; }
        public long id_rv_servicios { get; set; }
        public long id_rtl_servicios { get; set; }
        public float precioPagado_servicios { get; set; }
        public float precioPendiente_servicios { get; set; }
        public long id_uc_servicios { get; set; }
    }
}
