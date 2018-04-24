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
        [Required(ErrorMessage ="Kullanıcı Adı Giriniz!")]
        [Display(Name ="Kullanıcı Adı")]
        [StringLength(50,ErrorMessage ="Kullanıcı Adı En Fazla 50 Karakter Olmalı!")]
        public string username { get; set; }
        [Required(ErrorMessage = "Şifrenizi Giriniz!")]
        [Display(Name = "Şifre")]
        [StringLength(50, ErrorMessage = "Şifre en fazla 50 Karakter Olmalı!")]
        public string pass { get; set; }

    }
}