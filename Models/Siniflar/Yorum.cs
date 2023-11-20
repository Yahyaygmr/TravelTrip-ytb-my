using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTrip.Models.Siniflar
{
    public class Yorum
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string YapilanYorum { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

    }
}