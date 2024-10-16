using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entity
{
    public class Arac : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz! ")]
        public int MarkaId { get; set; }
        [Display(Name = "Kasa Tipi")]
        public int KasaTipisId { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz! ")]
        public string Renk { get; set; }
        [Display(Name = "Fiyatı")]
        public decimal Fiyati { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz! ")]
        public string Modeli { get; set; }
       
        [Display(Name = "Model Yılı")]
        public int ModelYili { get; set; }
        [Display(Name ="Satışta mı?")]
        public bool SatistaMi { get; set; }
        [Display(Name = "AnaSayfada Olsun mu?")]
        public bool AnaSayfadaMi { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz! ")]
        public string Notlar { get; set; }
        [StringLength(100)]
        public string? Resim1 { get; set; }
        [StringLength(100)]
        public string? Resim2 { get; set; }
        [StringLength(100)]
        public string? Resim3 { get; set; }

        public virtual Marka? Marka { get; set; }
        public virtual KasaTipis? KasaTipis { get; set; }
        //nullable olabilir

        //string yapınca not null olur default olarak . eğer belirli bir sınır vermzesek sınırsız alan açar
    }
}
