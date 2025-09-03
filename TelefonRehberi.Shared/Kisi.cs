using DokuzSistemBase.Data.Infrastructure;

namespace TelefonRehberi.Shared
{
    public class Kisi : BaseClass
    {
        public string Adi { get; set; } = string.Empty;

        public string Soyadi { get; set; } = string.Empty;

        public string? CepTel { get; set; } = string.Empty;

        public string? IsTel { get; set; } = string.Empty;

        public string Adres1 { get; set; } = string.Empty;

        public string? Adres2 { get; set; }
    }
}
