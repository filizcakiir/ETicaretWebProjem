using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriKatmani.Contexts;

namespace Islem
{
    public class UrunListe
    {
        public static List<DTO.Reponse.UrunBilgileri> AnaSayfaUrunListele()
        {
            EticaretWudContext Model = new EticaretWudContext();
            List<DTO.Reponse.UrunBilgileri>  Liste = Model.Urun.Select(s=> new DTO.Reponse.UrunBilgileri { 
                        No=s.No,
                        Baslik= s.Baslik,
                        Fiyat= s.Fiyat.Value,
                        ResimYol=s.ResimYol,

                        SaticiAd = s.KullaniciNoNavigation.Ad
                    
                    }).ToList();
            return Liste;
        }

        public static DTO.Reponse.UrunBilgileri UrunDetayGetir(int No)
        {
            EticaretWudContext Model = new EticaretWudContext();
            DTO.Reponse.UrunBilgileri Nesne = new DTO.Reponse.UrunBilgileri();

            Nesne = Model.Urun.Where(q => q.No == No)
                .Select(s => new DTO.Reponse.UrunBilgileri
                {
                    No=s.No,
                    Baslik = s.Baslik,
                    Fiyat=s.Fiyat.Value,
                    ResimYol = s.ResimYol,
                    SaticiAd = s.KullaniciNoNavigation.Ad,
                    Aciklama= s.Aciklama,
                    Stok = s.Stok.Value,
                    SaticiNo = s.KullaniciNo.Value,
                    KategoriNo = s.KategoriNo.Value
                }).FirstOrDefault();
            return Nesne;
        }


        public static List<DTO.Reponse.UrunBilgileri> SaticiyaAitUrunListele(int SaticiNo)
        {
            EticaretWudContext Model = new EticaretWudContext();
            List<DTO.Reponse.UrunBilgileri> Liste = Model.Urun
                .Where(q=> q.KullaniciNo == SaticiNo)
                .Select(s => new DTO.Reponse.UrunBilgileri
            {
                No = s.No,
                Baslik = s.Baslik,
                Fiyat = s.Fiyat.Value,
                ResimYol = s.ResimYol,
                SaticiAd = s.KullaniciNoNavigation.Ad

            }).ToList();
            return Liste;
        }

        public static List<DTO.Reponse.UrunBilgileri> KategoriyeAitUrunListele(int KategoriNo)
        {
            EticaretWudContext Model = new EticaretWudContext();
            List<DTO.Reponse.UrunBilgileri> Liste = Model.Urun
                .Where(q => q.KategoriNo == KategoriNo)
                .Select(s => new DTO.Reponse.UrunBilgileri
                {
                    No = s.No,
                    Baslik = s.Baslik,
                    Fiyat = s.Fiyat.Value,
                    ResimYol = s.ResimYol,
                    SaticiAd = s.KullaniciNoNavigation.Ad

                }).ToList();
            return Liste;
        }

    }
}
