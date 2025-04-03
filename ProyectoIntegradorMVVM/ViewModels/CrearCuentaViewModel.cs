using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoIntegradorMVVM.ViewModels
{
    public class CrearCuentaViewModel : INotifyPropertyChanged
    {
        private string nombreCompleto;
        private string email;
        private string contrasena;
        private string confirmarContrasena;

        public string NombreCompleto
        {
            get => nombreCompleto;
            set
            {
                if (nombreCompleto != value)
                {
                    nombreCompleto = value;
                    OnPropertyChanged(nameof(NombreCompleto));
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Contrasena
        {
            get => contrasena;
            set
            {
                if (contrasena != value)
                {
                    contrasena = value;
                    OnPropertyChanged(nameof(Contrasena));
                }
            }
        }

        public string ConfirmarContrasena
        {
            get => confirmarContrasena;
            set
            {
                if (confirmarContrasena != value)
                {
                    confirmarContrasena = value;
                    OnPropertyChanged(nameof(ConfirmarContrasena));
                }
            }
        }

        public ICommand RegistrarCommand { get; }
        public ICommand IniciarSesionCommand { get; }

        public CrearCuentaViewModel()
        {
            RegistrarCommand = new Command(RegistrarCuenta);
            IniciarSesionCommand = new Command(IniciarSesion);
        }

        private void RegistrarCuenta()
        {
            if (string.IsNullOrWhiteSpace(NombreCompleto) || string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Contrasena) || string.IsNullOrWhiteSpace(ConfirmarContrasena))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            if (Contrasena != ConfirmarContrasena)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
                return;
            }

            Application.Current.MainPage.DisplayAlert("Éxito", "Cuenta creada correctamente", "OK");
        }

        private void IniciarSesion()
        {
            // Navegación a la pantalla de inicio de sesión
            Application.Current.MainPage.DisplayAlert("Info", "Redirigiendo a inicio de sesión", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
