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
    public partial class TipoDePago : ContentPage
    {
        TipoDePagoControlador ob = new TipoDePagoControlador();
        List<TipoDePagoModelo> Lista = null;
        UsuarioModelo obUsuario = null;
        int Posicion;

        public TipoDePago(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarEmpleado(Tipo.Text, VerificarId());
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Tipo.Text = Lista[Posicion].tipoDePago_tdp;
            }
        }

        public async void InsertarEmpleado(string tipo, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(tipo))
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.tipoDePago_tdp == tipo);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarTipoDePago(tipo, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarTipoDePago(Lista[Posicion].id_tdp, tipo, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarEmpleado()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarTipoDePago(Lista[Posicion].id_tdp);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un tipo de pago", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var ListaTipoPago = await ob.MetodoSeleccionarTipoDePago(VerificarId());
            Lista = ListaTipoPago;
            ListaTipoDePago.ItemsSource = Lista;
        }

        public long VerificarId()
        {
            long ide;
            if (obUsuario.idEmpleado_uc == 0)
            {
                ide = obUsuario.id_uc;
            }
            else
            {
                ide = obUsuario.idEmpleado_uc;
            }
            return ide;
        }
    }
}