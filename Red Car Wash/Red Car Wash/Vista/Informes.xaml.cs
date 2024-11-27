using Microcharts;
using Red_Car_Wash.Controlador;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Collections.Generic;
using Red_Car_Wash.Modelo;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informes : ContentPage
    {
        InformeControlador ob = new InformeControlador();
        List<InformeModelo> Lista = null;
        UsuarioModelo obUsuario = null; string titulo;
        
        public Informes(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            this.obUsuario = obUsuario;
            ListaMes.IsEnabled = false;
            CargarDatos();
        }

        private void BtnSeleccionarAnio(object sender, EventArgs e)
        {
            ListaMes.IsEnabled = true;
        }

        private void BtnSeleccionarMes(object sender, EventArgs e)
        {
            ObtenerInforme();
        }

        private void BtnVer(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new InformeMes(Lista, titulo));
        }

        public void ObtenerInforme() 
        {
            float[] valores = new float[4]; float total;
            Lista.ForEach(x =>
            {
                if (x.fecha_inf.Year == int.Parse(ListaAnio.SelectedItem.ToString()) &&
                    x.fecha_inf.Month == (ListaMes.SelectedIndex + 1))
                {
                    titulo = $"{ListaMes.SelectedItem} del {ListaAnio.SelectedItem}";
                    switch (x.tipo_inf)
                    {
                        case "Servicio pagado":
                            valores[0] += x.total_inf;
                            break;
                        case "Servicio deuda":
                            valores[1] += x.total_inf;
                            break;
                        case "Anticipo":
                            valores[2] += x.total_inf;
                            break;
                        case "Completo":
                            valores[3] += x.total_inf;
                            break;
                    }
                }
            });
            total = valores[0] + valores[1] + valores[2] + valores[3];
            valores[0] = (float)Math.Round(valores[0] * 100 / total, 2);
            valores[1] = (float)Math.Round(valores[1] * 100 / total, 2);
            valores[2] = (float)Math.Round(valores[2] * 100 / total, 2);
            valores[3] = (float)Math.Round(valores[3] * 100 / total, 2);
            var entrada = new[]
            {
                new ChartEntry(valores[0])
                {
                    Color = SkiaSharp.SKColor.Parse("#FF9A2F"),
                    Label = "Servicio pagado",
                    ValueLabel = $"{valores[0]}%"
                },
                new ChartEntry(valores[1])
                {
                    Color = SkiaSharp.SKColor.Parse("#FACD2F"),
                    Label = "Servicio deuda",
                    ValueLabel = $"{valores[1]}%"
                },
                new ChartEntry(valores[2])
                {
                    Color = SkiaSharp.SKColor.Parse("#F7FF2F"),
                    Label = "Anticipo",
                    ValueLabel = $"{valores[2]}%"
                },
                new ChartEntry(valores[3])
                {
                    Color = SkiaSharp.SKColor.Parse("#C8FE2E"),
                    Label = "Completo",
                    ValueLabel = $"{valores[3]}%"
                }
            };
            GraficoEstadistico.Chart = new DonutChart() { Entries = entrada };
        }

        public async void CargarDatos()
        {
            Lista = await ob.MetodoSeleccionarInforme(VerificarId());
            //Llenar comboboxs de años y meses disponibles
            List<int> anios = new List<int>();
            Lista.ForEach(x =>
            {
                if (!anios.Contains(x.fecha_inf.Year))
                {
                    anios.Add(x.fecha_inf.Year);
                }
            });
            ListaAnio.ItemsSource = anios;
            List<string> meses = new List<string>()
            { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
              "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
            ListaMes.ItemsSource = meses;
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