using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakPortal2.ViewModel
{
    public class kayitModel
    {
        public int kayId { get; set; }
        [Required(ErrorMessage ="Adı Soyadı Giriniz!")]
        [Display(Name ="Adı Soyadı")]
        [StringLength(50,ErrorMessage ="Adı Soyadı En Fazla 50 Karakter Olmalı!")]
        public string adsoyad { get; set; }
        [Required(ErrorMessage = "E-Posta Giriniz!")]
        [Display(Name = "E-Posta")]
        [StringLength(50, ErrorMessage = "E-Posta En Fazla 50 Karakter Olmalı!")]
        public string mail { get; set; }
        [Required(ErrorMessage = "Yaş Giriniz!")]
        [Display(Name = "Yaş")]
        public int yas { get; set; }
    }
}