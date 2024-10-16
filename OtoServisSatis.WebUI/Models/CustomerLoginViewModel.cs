using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.WebUI.Models
{
    public class CustomerLoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz! ")]
        public string Email { get; set; }

        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz! "), Display(Name = "Şifre")]
        public string Sifre { get; set; }
    }
}
