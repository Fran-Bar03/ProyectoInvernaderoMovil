using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoIntegradorMVVM.ViewModels
{
    public class PantallaPrincipalViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string SaludoUsuario { get; set; } = "¡Hola, Nicol!";
        public string FechaActual { get; set; } = DateTime.Now.ToString("dddd, dd MMMM yyyy");

        private string _textoBusqueda;
        public string TextoBusqueda
        {
            get => _textoBusqueda;
            set
            {
                _textoBusqueda = value;
                OnPropertyChanged(nameof(TextoBusqueda));
            }
        }

        public ObservableCollection<Invernadero> ListaInvernaderos { get; set; }

        public ICommand BuscarCommand { get; }
        public ICommand IrADetalleCommand { get; }
        public ICommand IrAgregarCommand { get; }

        public PantallaPrincipalViewModel()
        {
            ListaInvernaderos = new ObservableCollection<Invernadero>
            {
                new Invernadero { Nombre = "Invernadero 1", Planta = "Tomate", Ubicacion = "The Pandaan, Pasuruan", Imagen = "https://i.ibb.co/v6KRDrCT/tomate.jpg" },
                new Invernadero { Nombre = "Invernadero 2", Planta = "Lechuga", Ubicacion = "Tretes, Pasuruan", Imagen = "https://i.ibb.co/jZ3btYzK/lechuga.jpg" },
                new Invernadero { Nombre = "Invernadero 3", Planta = "Tomate", Ubicacion = "Tretes, Pasuruan", Imagen = "https://i.ibb.co/v6KRDrCT/tomate.jpg" }
            };

            BuscarCommand = new Command(RealizarBusqueda);
            IrADetalleCommand = new Command<Invernadero>(IrADetalle);
            IrAgregarCommand = new Command(IrAgregarInvernadero);
        }

        private void RealizarBusqueda()
        {
            // Aquí puedes filtrar los invernaderos según la búsqueda
            Application.Current.MainPage.DisplayAlert("Buscar", $"Buscando: {TextoBusqueda}", "OK");
        }

        private void IrADetalle(Invernadero invernadero)
        {
            // Lógica para ir a la pantalla de detalles
            Application.Current.MainPage.DisplayAlert("Detalle", $"Detalles de: {invernadero.Nombre}", "OK");
        }

        private void IrAgregarInvernadero()
        {
            // Lógica para ir a la pantalla de agregar invernadero
            Application.Current.MainPage.DisplayAlert("Agregar", "Navegando a Agregar Invernadero", "OK");
        }
    }

    public class Invernadero
    {
        public string Nombre { get; set; }
        public string Planta { get; set; }
        public string Ubicacion { get; set; }
        public string Imagen { get; set; }
    }
}
