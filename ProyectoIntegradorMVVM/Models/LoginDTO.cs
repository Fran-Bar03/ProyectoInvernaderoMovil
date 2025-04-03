using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorMVVM.Models {
  public class LoginDTO 
  {
    public string Email { get; set; }

    public string Contrasena { get; set; }
  }
}
