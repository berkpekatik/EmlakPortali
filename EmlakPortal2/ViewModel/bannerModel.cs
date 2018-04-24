using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakPortal2.ViewModel
{
    public class bannerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık Giriniz!")]
        [Display(Name = "Başlık")]
        [StringLength(50, ErrorMessage = "Başlık En fazla 50 Karakter olmalı")]
        public string baslik { get; set; }
        [Required(ErrorMessage = "Açıklama Giriniz!")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Açıklama En fazla 50 Karakter olmalı")]
        public string aciklama { get; set; }
        [Display(Name = "Fotoğraf")]
        [Required(ErrorMessage = "Fotoğraf Seçiniz!")]
        public HttpPostedFileBase foto { get; set; }
    }
}