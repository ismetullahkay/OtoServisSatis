using OtoServisSatis.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class KasaTipis : IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Kasa Tipi"),Required(ErrorMessage ="{0} Boş Bırakılamaz !")]
        public string KasaTipi{ get; set; }

       
    }
}
