using System.Web;

namespace StadiumManagement.Models
{
    public class UsuarioView
    {
        public Usuario Usuario { get; set; }

        public HttpPostedFileBase Foto { get; set; }
    }
}