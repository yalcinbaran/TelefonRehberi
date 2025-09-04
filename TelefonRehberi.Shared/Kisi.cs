using DokuzSistemBase.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace TelefonRehberi.Shared
{
    public class Kisi : BaseClass
    {
        [Required(ErrorMessage = "Ad alanı zorunludur."), MaxLength(50, ErrorMessage = "Ad alanı 50 karakterden uzun olamaz.")]
        public string Adi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyadı alanı zorunludur."), MaxLength(50, ErrorMessage = "Soyadı alanı 50 karakterden uzun olamaz.")]
        public string Soyadi { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Geçersiz telefon numarası"),MaxLength(11,ErrorMessage ="Telefon numarası 11 haneden uzun olamaz."),MinLength(11,ErrorMessage = "Telefon numarası 11 haneden kısa olamaz.")]
        public string? CepTel { get; set; } = string.Empty;
        [Phone(ErrorMessage = "Geçersiz telefon numarası"), MaxLength(11, ErrorMessage = "Telefon numarası 11 haneden uzun olamaz."), MinLength(11, ErrorMessage = "Telefon numarası 11 haneden kısa olamaz.")]
        public string? IsTel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres 1 alanı zorunludur."), MaxLength(200, ErrorMessage = "Adres 1 alanı 100 karakterden uzun olamaz.")]
        public string Adres1 { get; set; } = string.Empty;

        [MaxLength(200, ErrorMessage = "Adres 2 alanı 100 karakterden uzun olamaz.")]
        public string? Adres2 { get; set; }
    }
}
