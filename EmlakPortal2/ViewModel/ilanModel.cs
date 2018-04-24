using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakPortal2.ViewModel
{
    public class ilanModel
    {
        public int ilanId { get; set; }
        [Required(ErrorMessage ="İlan Adı Giriniz!")]
        [Display(Name ="İlan Adı")]
        [StringLength(255,ErrorMessage ="Adı Soyadı En Fazla 255 Karakter Olmalı!")]
        public string ilanAdi { get; set; }
        [Required(ErrorMessage = "Şehir Giriniz")]
        [Display(Name = "Şehir")]
        [StringLength(50, ErrorMessage = "!")]
        public string ilanYer { get; set; }
        [Required(ErrorMessage = "M2 Giriniz")]
        [Display(Name = "M2")]
        public int m2 { get; set; }
        [Required(ErrorMessage = "Fiyat Giriniz")]
        [Display(Name = "Fiyat")]
        public int fiyat { get; set; }
        [Display(Name = "Fotoğraf")]
        [Required(ErrorMessage = "Fotoğraf Seçiniz!")]
        public HttpPostedFileBase foto { get; set; }
    }
}