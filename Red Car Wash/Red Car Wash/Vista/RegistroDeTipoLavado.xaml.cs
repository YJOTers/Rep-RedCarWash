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
    public partial class RegistroDeTipoLavado : ContentPage
    {
        RegDeTipoLavadoControlador ob = new RegDeTipoLavadoControlador();
        List<RegDeTipoLavadoModelo> Lista = null;
        UsuarioModelo obUsuario = null;
        int Posicion;

        public RegistroDeTipoLavado(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarTipoDeLavado(TipoLavado.Text, float.Parse(PrecioPublico.Text), VerificarId());
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarTipoDeLavado();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                TipoLavado.Text = Lista[Posicion].tipoLavado_rtl;
                PrecioPublico.Text = Lista[Posicion].precioPublico_rtl.ToString();
            }
        }

        public async void InsertarTipoDeLavado(string tipo, float precio, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(precio.ToString()))
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.tipoLavado_rtl == tipo && x.precioPublico_rtl == precio);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarRegDeTipoLavado(tipo, precio, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarRegDeTipoLavado(Lista[Posicion].id_rtl, tipo, precio, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarTipoDeLavado()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarRegDeTipoLavado(Lista[Posicion].id_rtl);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un tipo de lavado", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var TiposDeLavado = await ob.MetodoSeleccionarRegDeTipoLavado(VerificarId());
            Lista = TiposDeLavado;
            ListaDeTipoLavado.ItemsSource = Lista;
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