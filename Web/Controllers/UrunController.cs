using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult DetayGetir(string Id)
        {
            if (Id != null && Id != "")
            {
                int No = Convert.ToInt32(Id);

                DTO.Reponse.UrunBilgileri UrunNesne = Islem.UrunListe.UrunDetayGetir(No);

                List<DTO.Reponse.UrunBilgileri> SaticiAitUrunler = Islem.UrunListe.SaticiyaAitUrunListele(UrunNesne.SaticiNo);
                List<DTO.Reponse.UrunBilgileri> KategoriAitUrunler = Islem.UrunListe.KategoriyeAitUrunListele(UrunNesne.KategoriNo);


                SaticiAitUrunler = SaticiAitUrunler.Where(q => q.No != UrunNesne.No).ToList();
                KategoriAitUrunler = KategoriAitUrunler.Where(q => q.No != UrunNesne.No).ToList();
                
                
                var Cevap = (UrunNesne,SaticiAitUrunler,KategoriAitUrunler);
                return View("UrunDetay", Cevap);
            }
            return View("UrunDetay");
        }
    }
}
