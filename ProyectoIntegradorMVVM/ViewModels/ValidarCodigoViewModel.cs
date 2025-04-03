using ProyectoIntegradorMVVM.Clases;
using ProyectoIntegradorMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoIntegradorMVVM.ViewModels {
  public class ValidarCodigoViewModel : BaseViewModel
  {
    private readonly HttpClient _httpclient;
    private const string ApiUrl = "https://3j8hk6ww-5148.usw3.devtunnels.ms/api/Usuario/ValidarCodigo";

    private string _codigo;
    private string _mensajeError;
    private string _mensajeExito;
    private readonly INavigation _navigation;
    private string _token;

    

    public string Codigoo 
    {
      get { return _codigo; }
      set {
        if (_codigo != value) {
          _codigo = value;
          OnPropertyChanged (nameof (_codigo));
        }
      }
    }

    public string MensajeExito {
      get => _mensajeExito;
      set => SetProperty (ref _mensajeExito, value);
    }

    public string MensajeError {
      get => _mensajeError;
      set => SetProperty (ref _mensajeError, value);
    }


    public ICommand ValidarCodigoCommand { get; }


    public ValidarCodigoViewModel (INavigation navigation)   
    {
      _navigation = navigation;
      _httpclient = new HttpClient ();
      ValidarCodigoCommand = new Command (async () => await ValidarCodigo ());
      CargarToken ();
    }

    public async void CargarToken () 
    {
      _token = await RecoveryService.ObtenerRecoveryToken();
    }


    private async Task ValidarCodigo ()
    {
      if (string.IsNullOrEmpty (_token)) {
        MensajeError = "No se encontró un token de recuperación. Intente nuevamente.";
        return;
      }


      var CodigoDto = new ValidarCodigoDTO {
        Codigo = Codigoo
      };


      var json = JsonSerializer.Serialize (dto);
      var contenido = new StringContent (json, Encoding.UTF8, "application/json");

      try {
        var response = await _httpclient.PostAsync ($"{ApiUrl}?token={_token}", contenido);

        if (response.IsSuccessStatusCode) {
          var resultado = await response.Content.ReadAsStringAsync ();
          var objetoRespuesta = JsonSerializer.Deserialize<JsonElement> (resultado);

          string nuevoToken = objetoRespuesta.GetProperty ("Token").GetString ();
          await RecoveryService.GuardarRecoveryToken (nuevoToken);

          MensajeExito = "Código válido. Redirigiendo...";
          await _navigation.PushAsync (new NuevaContrasena ());
        } else {
          MensajeError = "Código inválido. Intenta de nuevo.";
        }
      } catch (Exception ex) {
        MensajeError = $"Error al validar el código: {ex.Message}";
      }

    }
  }
}
