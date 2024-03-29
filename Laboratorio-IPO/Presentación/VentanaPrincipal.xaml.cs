﻿using Laboratorio_IPO.Dominio;
using Laboratorio_IPO.Presentación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laboratorio_IPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public string nombreUsuario = "Andrés";
        DateTime lastConexion = DateTime.Now;
        public Page[] paginas;
        public VentanaPrincipal()
        {
            InitializeComponent();
            paginas = new Page[] { new PaginaRutas(this), new VentanaInfoExcursionistas(this), new VentanaInfoGuias(this)};
            txtUsuario.Text = nombreUsuario + "\n" + "U.Conexión: " + lastConexion;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCerrarMenu.Visibility = Visibility.Visible;
            btnMenu.Visibility = Visibility.Collapsed;
        }

        private void btnCerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCerrarMenu.Visibility = Visibility.Collapsed;
            btnMenu.Visibility= Visibility.Visible; 
        }

        private void btnRutas_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paginas[0];
        }

        private void Ventana_Principal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cerrando Sesión", "Cierre de Sesión");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void btnAcerca_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aplicación creada por Andrés González Varela y David Carrobles Illán", "Información sobre la aplicación");
        }

        private void btnExcursionistas_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paginas[1];
        }

        private void btnGuias_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content= paginas[2];  
        }
		public void seleccionRutaEspecifica(String ruta, int realizada)
		{
            PaginaRutas aux=(PaginaRutas)paginas[0];
            aux.seleccionRutaEspecifica(ruta, realizada);
		}
		public void seleccionExcursionistaEspecifico(String seleccionado)
		{
			MainFrame.Content = paginas[1];
			VentanaInfoExcursionistas aux = (VentanaInfoExcursionistas)paginas[1];
			aux.seleccionExcursionistaEspecifico(seleccionado);
		}
		public void seleccionGuiaEspecifico(String seleccionado)
		{
			MainFrame.Content = paginas[2];
			VentanaInfoGuias aux = (VentanaInfoGuias)paginas[2];
			aux.seleccionGuiaEspecifico(seleccionado);
		}
	}
}
