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
    public partial class RegistroDeEmpleado : ContentPage
    {
        RegDeEmpleadoControlador ob = new RegDeEmpleadoControlador();
        List<RegEmpleadoModelo> Lista = null;
        UsuarioModelo obUsuario = null;
        int Posicion;

        public RegistroDeEmpleado(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarEmpleado(Fecha.Date, Nombres.Text, Apellidos.Text, Cedula.Text, float.Parse(SueldoAcordado.Text), VerificarId());
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
                Fecha.Date = Lista[Posicion].fecha_re.Date;
                Cedula.Text = Lista[Posicion].cedula_re;
                Nombres.Text = Lista[Posicion].nombres_re;
                Apellidos.Text = Lista[Posicion].apellidos_re;
                SueldoAcordado.Text = Lista[Posicion].sueldoAcordado_re.ToString();
            }
        }

        public async void InsertarEmpleado(DateTimeOffset fecha, string nombres, string apellidos, string cedula, float sueldo, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(fecha.ToString()) || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombres) ||
                string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(sueldo.ToString()))
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.cedula_re == cedula);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarRegEmpleado(fecha, nombres, apellidos, cedula, sueldo, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarRegEmpleado(Lista[Posicion].id_re, fecha, nombres, apellidos, cedula, sueldo, id_uc);
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
                string mensaje = await ob.MetodoEliminarRegEmpleado(Lista[Posicion].id_re);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un empleado", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var ListaEmpleado = await ob.MetodoSeleccionarRegEmpleado(VerificarId());
            Lista = ListaEmpleado;
            ListaEmpleados.ItemsSource = Lista;
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