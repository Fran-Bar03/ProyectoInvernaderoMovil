using ProyectoIntegradorMVVM.Clases;
using ProyectoIntegradorMVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using ProyectoIntegradorMVVM.Views;

namespace ProyectoIntegradorMVVM.ViewModels {
  public class CrearCuentaViewModel : BaseViewModel {
  private readonly HttpClient _httpclient;
  private const string ApiurlRegistro = "https://z7zsd20t-5148.usw3.devtunnels.ms/api/Usuario/RegistrarUsuario";
  private const string ApiUrlLogin = "https://z7zsd20t-5148.usw3.devtunnels.ms/api/Usuario/Login";

  private string _nombreCompleto;
  private string _email;
  private string _contrasena;
  private string _confirmarContrasena;
  private INavigation _navigation;


    public string NombreCompleto 
    {
      get { return _nombreCompleto; }
      set 
      {
        if (_nombreCompleto != value) 
        {
          _nombreCompleto = value;
          OnPropertyChanged (nameof (_nombreCompleto));
        }
      }
    }

    public string Email 
    {
      get { return _email; }
      set 
      {
        if (_email != value) 
        {
          _email = value;
          OnPropertyChanged (nameof (_email));
        }
      }
    }

    public string Contrasena {
      get { return _contrasena; }
      set {
        if (_contrasena != value) {
          _contrasena = value;
          OnPropertyChanged (nameof (_contrasena));
        }
      }
    }

    public string ConfirmarContrasena {
      get { return _confirmarContrasena; }
      set {
        if (_confirmarContrasena != value) {
          _confirmarContrasena = value;
          OnPropertyChanged (nameof (_confirmarContrasena));
        }
      }
    }



    public ICommand CrearCuentaCommand { get; }
    public ICommand IrLoginCommand { get; }



    public CrearCuentaViewModel (INavigation navigation) 
    {
      _httpclient = new HttpClient ();
      _navigation = navigation;
      CrearCuentaCommand = new Command (async () => await CrearCuenta ());
      IrLoginCommand = new Command (async () => await IrLogin ());
    }


    public async Task CrearCuenta () 
    {
      if (string.IsNullOrWhiteSpace (NombreCompleto) || string.IsNullOrWhiteSpace (Email)
          || string.IsNullOrWhiteSpace (Contrasena) || string.IsNullOrWhiteSpace (ConfirmarContrasena)) {
        await App.Current.MainPage.DisplayAlert ("Advertencia", "Completa todos los campos", "OK");
        return;
      }

      if (Contrasena != ConfirmarContrasena)
      {
        await App.Current.MainPage.DisplayAlert ("Error", "Las contraseñas no coinciden", "OK");
        return;
      }

      var Usuario = new CrearCuentaDTO {
        NombreCompleto = _nombreCompleto,
        Email = _email,
        Contrasena = _contrasena,
      };
            
      var Json = JsonSerializer.Serialize (Usuario);
      var Contenido = new StringContent (Json, Encoding.UTF8, "application/json");
      var Respuesta = await _httpclient.PostAsync (ApiurlRegistro,Contenido);

      if (Respuesta.IsSuccessStatusCode) {
        await App.Current.MainPage.DisplayAlert ("Exito", "Usuario registrado correctamente", "Ok");
        await Loguearse ();
      }
      else 
      {
        var error = await Respuesta.Content.ReadAsStringAsync ();
        await App.Current.MainPage.DisplayAlert ("Error", $"No se pudo registrar el usuario: {error}", "OK");
      }
    }


    private async Task Loguearse() 
    {
      var Login = new LoginDTO {
        Email = this._email,
        Contrasena = this._contrasena
      };

      var Json = JsonSerializer.Serialize (Login);
      var Contenido = new StringContent(Json, Encoding.UTF8, "application/json");
      var Response = await _httpclient.PostAsync(ApiUrlLogin,Contenido);

      if (Response.IsSuccessStatusCode) 
      {
        var ResponseContent = await Response.Content.ReadAsStringAsync ();
        string Token = ResponseContent.Trim ();

                // Verificar si se recibió un token válido
                if (!string.IsNullOrEmpty(Token))
                {
                    await AuthService.GuardarToken(Token);  // Guardamos el token
                    Application.Current.MainPage = new NavigationPage(new PantallaPrincipal());  // Redirigimos a la pantalla principal
                }
      }
      else 
      {
        var error = await Response.Content.ReadAsStringAsync ();
        await App.Current.MainPage.DisplayAlert ("Login Fallido", $"Error al iniciar sesión: {error}", "OK");

      }
    }
        
    private async Task IrLogin() 
    {
      await _navigation.PushAsync (new InicioSesion ());
    }
  }
}


