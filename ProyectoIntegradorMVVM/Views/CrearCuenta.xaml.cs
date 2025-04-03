using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

namespace ProyectoIntegradorMVVM.Views;

public partial class CrearCuenta : ContentPage
{
    private bool isPasswordVisible = false;

    public CrearCuenta()
    {
        InitializeComponent();
        BtnRegistrarse.IsEnabled = false; // Deshabilitar bot�n al inicio
    }

    private void OnNombreChanged(object sender, TextChangedEventArgs e)
    {
        string nombre = EntryNombre.Text;

        if (!Regex.IsMatch(nombre, @"^[a-zA-Z�-�\s]+$"))
        {
            ErrorMessage.Text = "El nombre no debe contener n�meros.";
            ErrorMessage.IsVisible = true;
            BtnRegistrarse.IsEnabled = false;
            return;
        }

        EntryNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre.ToLower());
        ErrorMessage.IsVisible = false;
        ValidateForm();
    }

    private void OnEmailChanged(object sender, TextChangedEventArgs e)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        if (!Regex.IsMatch(EntryEmail.Text, emailPattern))
        {
            ErrorMessage.Text = "Ingrese un correo v�lido.";
            ErrorMessage.IsVisible = true;
            BtnRegistrarse.IsEnabled = false;
        }
        else
        {
            ErrorMessage.IsVisible = false;
            ValidateForm();
        }
    }

    private void OnPasswordChanged(object sender, TextChangedEventArgs e)
    {
        string password = EntryPassword.Text;

        if (!Regex.IsMatch(password, @"^(?=.*\d).{6,}$"))
        {
            ErrorMessage.Text = "La contrase�a debe tener al menos 6 caracteres y un n�mero.";
            ErrorMessage.IsVisible = true;
            BtnRegistrarse.IsEnabled = false;
        }
        else
        {
            ErrorMessage.IsVisible = false;
            ValidatePasswordsMatch();
        }
    }

    private void OnConfirmPasswordChanged(object sender, TextChangedEventArgs e)
    {
        ValidatePasswordsMatch();
    }

    private void ValidatePasswordsMatch()
    {
        if (EntryPassword.Text != EntryConfirmPassword.Text)
        {
            ErrorMessage.Text = "Las contrase�as no coinciden.";
            ErrorMessage.IsVisible = true;
            BtnRegistrarse.IsEnabled = false;
        }
        else
        {
            ErrorMessage.IsVisible = false;
            ValidateForm();
        }
    }

    private void ValidateForm()
    {
        bool isFormValid =
            !string.IsNullOrWhiteSpace(EntryNombre.Text) &&
            Regex.IsMatch(EntryNombre.Text, @"^[a-zA-Z�-�\s]+$") &&
            !string.IsNullOrWhiteSpace(EntryEmail.Text) &&
            Regex.IsMatch(EntryEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") &&
            !string.IsNullOrWhiteSpace(EntryPassword.Text) &&
            Regex.IsMatch(EntryPassword.Text, @"^(?=.*\d).{6,}$") &&
            EntryPassword.Text == EntryConfirmPassword.Text;

        BtnRegistrarse.IsEnabled = isFormValid;
    }

    private void TogglePasswordVisibility(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        EntryPassword.IsPassword = !isPasswordVisible;
        BtnTogglePassword.Source = isPasswordVisible ? "eye_off_icon.png" : "eye_icon.png";
    }

    private async void Ir_PantallaPrincipal(object sender, EventArgs e)
    {
        if (!BtnRegistrarse.IsEnabled)
        {
            ErrorMessage.Text = "Por favor, complete todos los campos correctamente.";
            ErrorMessage.IsVisible = true;
            return;
        }

        await Navigation.PushAsync(new PantallaPrincipal());
    }

    private async void Loginn(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }
}
