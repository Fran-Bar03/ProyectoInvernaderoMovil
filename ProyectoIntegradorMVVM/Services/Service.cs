using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorMVVM.Services
{
    public class Service
    {
        public async Task<bool> EnviarRecuperacionContrasena(string email)
        {
            // Simulación de envío de correo (reemplázalo con tu lógica real)
            await Task.Delay(2000);
            return true; // Suponiendo que el correo se envió correctamente
        }
    }
}
