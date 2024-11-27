using Acr.UserDialogs;
using Red_Car_Wash.Controlador;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Servicios : ContentPage
    {
        ServiciosControlador ob = new ServiciosControlador();
        InformeControlador ob2 = new InformeControlador();
        List<ServiciosModeloVista> Lista = null;
        List<RegDeVehiculoModeloVista> Lista2 = null;
        List<RegDeTipoLavadoModelo> Lista3 = null;
        UsuarioModelo obUsuario = null;
        long id_rv, id_rtl;
        int Posicion;
        string usuario = "";

        public Servicios(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
            RefrescarListaDePlacas();
            RefrescarListaDeTipoLavado();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarServicio(Fecha.Date, id_rv, id_rtl, float.Parse(PrecioPagado.Text), float.Parse(MontoPendiente.Text), VerificarId());
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarServicio();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Fecha.Date = Lista[Posicion].fecha_servicios.Date;
                ListaDePlacas.SelectedItem = Lista[Posicion].placa_rv;
                TipoDeVehiculo.Text = Lista[Posicion].tipoDeVehiculo_tdv;
                ListaTipoDeLavado.SelectedItem = Lista[Posicion].tipoLavado_rtl;
                Pvp.Text = Lista[Posicion].precioPublico_rtl.ToString();
                PrecioPagado.Text = Lista[Posicion].precioPagado_servicios.ToString();
                MontoPendiente.Text = Lista[Posicion].precioPendiente_servicios.ToString();
            }
        }

        private void BtnSeleccionarPlaca(object sender, EventArgs e)
        {
            int Pos = ListaDePlacas.SelectedIndex;
            if (Pos > -1)
            {
                id_rv = Lista2[Pos].id_rv;
                TipoDeVehiculo.Text = Lista2[Pos].tipoDeVehiculo_tdv;
            }
        }

        private void BtnSeleccionarTipoDeLavado(object sender, EventArgs e)
        {
            int Pos = ListaTipoDeLavado.SelectedIndex;
            if (Pos > -1)
            {
                id_rtl = Lista3[Pos].id_rtl;
                Pvp.Text = Lista3[Pos].precioPublico_rtl.ToString();
            }
        }

        private void BtnListaDePlacas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroDeVehiculo(obUsuario));
        }

        private void BtnListaTipoDeLavado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroDeTipoLavado(obUsuario));
        }

        public async void InsertarServicio(DateTimeOffset fecha, long id_rv, long id_rtl, float precioPagado, float precioPendiente, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(fecha.ToString()) || string.IsNullOrEmpty(precioPagado.ToString()) || string.IsNullOrEmpty(precioPendiente.ToString()) ||
                ListaDePlacas.SelectedIndex == -1 || ListaTipoDeLavado.SelectedIndex == -1)
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios o sin elegir", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    if (precioPendiente == 0)
                    {
                        _ = await ob2.MetodoInsertarInforme(fecha, "Lavado completo", "Servicio pagado", usuario, precioPagado, id_uc);
                    }
                    else
                    {
                        _ = await ob2.MetodoInsertarInforme(fecha, "Lavado completo", "Servicio deuda", usuario, precioPagado, id_uc);
                    }
                    var obUsuario = Lista.Find(x => x.fecha_servicios == fecha && x.precioPagado_servicios == precioPagado && x.precioPendiente_servicios == precioPendiente);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarServicios(fecha, id_rv, id_rtl, precioPagado, precioPendiente, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarServicios(Lista[Posicion].id_servicios, fecha, id_rv, id_rtl, precioPagado, precioPendiente, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarServicio()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarServicios(Lista[Posicion].id_servicios);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un servicio", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var ListaDeServicios = await ob.MetodoSeleccionarServicios(VerificarId());
            Lista = ListaDeServicios;
            ListaServicios.ItemsSource = Lista;
            Fecha.Date = DateTime.Today.Date;
            TipoDeVehiculo.Text = "";
            Pvp.Text = "";
            PrecioPagado.Text = "";
            MontoPendiente.Text = "";
        }

        public async void RefrescarListaDePlacas()
        {
            RegDeVehiculoControlador ob = new RegDeVehiculoControlador();
            var Lista2Placas = await ob.MetodoSeleccionarRegDeVehiculo(VerificarId());
            Lista2 = Lista2Placas;
            List<string> datos = new List<string>();
            foreach (var items in Lista2)
            {
                datos.Add(items.placa_rv);
            }
            ListaDePlacas.ItemsSource = datos;
        }

        public async void RefrescarListaDeTipoLavado()
        {
            RegDeTipoLavadoControlador ob = new RegDeTipoLavadoControlador();
            var Lista3TipoLavado = await ob.MetodoSeleccionarRegDeTipoLavado(VerificarId());
            Lista3 = Lista3TipoLavado;
            List<string> datos = new List<string>();
            foreach (var items in Lista3)
            {
                datos.Add(items.tipoLavado_rtl);
            }
            ListaTipoDeLavado.ItemsSource = datos;
        }

        public long VerificarId()
        {
            long ide;
            if (obUsuario.idEmpleado_uc == 0)
            {
                usuario = "Cliente";
                ide = obUsuario.id_uc;
            }
            else
            {
                usuario = "Empleado";
                ide = obUsuario.idEmpleado_uc;
            }
            return ide;
        }
    }
}