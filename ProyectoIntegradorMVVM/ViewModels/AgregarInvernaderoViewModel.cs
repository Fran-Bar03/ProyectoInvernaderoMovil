using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoIntegradorMVVM.ViewModels
{
    public class AgregarInvernaderoViewModel : INotifyPropertyChanged
    {
        private string nombreInvernadero;
        private string nombrePlanta;
        private string tipoPlanta;
        private string imagen;

        public string NombreInvernadero
        {
            get => nombreInvernadero;
            set
            {
                if (nombreInvernadero != value)
                {
                    nombreInvernadero = value;
                    OnPropertyChanged(nameof(NombreInvernadero));
                }
            }
        }

        public string NombrePlanta
        {
            get => nombrePlanta;
            set
            {
                if (nombrePlanta != value)
                {
                    nombrePlanta = value;
                    OnPropertyChanged(nameof(NombrePlanta));
                }
            }
        }

        public string TipoPlanta
        {
            get => tipoPlanta;
            set
            {
                if (tipoPlanta != value)
                {
                    tipoPlanta = value;
                    OnPropertyChanged(nameof(TipoPlanta));
                }
            }
        }

        public string Imagen
        {
            get => imagen;
            set
            {
                if (imagen != value)
                {
                    imagen = value;
                    OnPropertyChanged(nameof(Imagen));
                }
            }
        }

        public ICommand AgregarCommand { get; }

        public AgregarInvernaderoViewModel()
        {
            AgregarCommand = new Command(AgregarInvernadero);
        }

        private void AgregarInvernadero()
        {
            // Aquí iría la lógica para agregar el invernadero, como guardarlo en la base de datos
            Application.Current.MainPage.DisplayAlert("Éxito", "Invernadero agregado correctamente", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}