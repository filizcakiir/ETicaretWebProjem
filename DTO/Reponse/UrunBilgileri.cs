using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Reponse
{
    public class UrunBilgileri
    {
        public int No { get; set; }
        public string Baslik { get; set; }
        public string ResimYol { get; set; }
        public int Fiyat { get; set; }
        public int SaticiNo { get; set; }
        public int KategoriNo { get; set; }
        public string SaticiAd { get; set; }
        public string Aciklama { get; set; }
        public int Stok { get; set; }

    }
}
