using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoIntegradorMVVM.ViewModels
{
    public class DetalleInvernaderoViewModel : INotifyPropertyChanged
    {
        private string nombre;
        private string ubicacion;
        private string viento;
        private string humedad;
        private string plantas;
        private bool luzEncendida;
        private bool temperaturaEncendida;
        private bool riegoEncendido;
        private bool ventilacionEncendida;

        public string Nombre
        {
            get => nombre;
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public string Ubicacion
        {
            get => ubicacion;
            set
            {
                if (ubicacion != value)
                {
                    ubicacion = value;
                    OnPropertyChanged(nameof(Ubicacion));
                }
            }
        }

        public string Viento
        {
            get => viento;
            set
            {
                if (viento != value)
                {
                    viento = value;
                    OnPropertyChanged(nameof(Viento));
                }
            }
        }

        public string Humedad
        {
            get => humedad;
            set
            {
                if (humedad != value)
                {
                    humedad = value;
                    OnPropertyChanged(nameof(Humedad));
                }
            }
        }

        public string Plantas
        {
            get => plantas;
            set
            {
                if (plantas != value)
                {
                    plantas = value;
                    OnPropertyChanged(nameof(Plantas));
                }
            }
        }

        public bool LuzEncendida
        {
            get => luzEncendida;
            set
            {
                if (luzEncendida != value)
                {
                    luzEncendida = value;
                    OnPropertyChanged(nameof(LuzEncendida));
                }
            }
        }

        public bool TemperaturaEncendida
        {
            get => temperaturaEncendida;
            set
            {
                if (temperaturaEncendida != value)
                {
                    temperaturaEncendida = value;
                    OnPropertyChanged(nameof(TemperaturaEncendida));
                }
            }
        }

        public bool RiegoEncendido
        {
            get => riegoEncendido;
            set
            {
                if (riegoEncendido != value)
                {
                    riegoEncendido = value;
                    OnPropertyChanged(nameof(RiegoEncendido));
                }
            }
        }

        public bool VentilacionEncendida
        {
            get => ventilacionEncendida;
            set
            {
                if (ventilacionEncendida != value)
                {
                    ventilacionEncendida = value;
                    OnPropertyChanged(nameof(VentilacionEncendida));
                }
            }
        }

        public ICommand ToggleLuzCommand { get; }
        public ICommand ToggleTemperaturaCommand { get; }
        public ICommand ToggleRiegoCommand { get; }
        public ICommand ToggleVentilacionCommand { get; }

        public DetalleInvernaderoViewModel()
        {
            ToggleLuzCommand = new Command(() => LuzEncendida = !LuzEncendida);
            ToggleTemperaturaCommand = new Command(() => TemperaturaEncendida = !TemperaturaEncendida);
            ToggleRiegoCommand = new Command(() => RiegoEncendido = !RiegoEncendido);
            ToggleVentilacionCommand = new Command(() => VentilacionEncendida = !VentilacionEncendida);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
