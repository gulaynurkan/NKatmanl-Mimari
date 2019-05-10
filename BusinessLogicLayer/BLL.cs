using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLL
    {
        DatabaseLogicLayer.DLL dll;

        public BLL()
        {
            dll = new DatabaseLogicLayer.DLL();
        }

        public int KayitEkle(string isim,string soyisim,string telefonNumaraI,string telefonNumaraII,string telefonNumaraIII,string EmailAdres,string Webadres,string Adres,string Aciklama)
        {
            if(!string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && !string.IsNullOrEmpty(telefonNumaraI))
            {
              return dll.KayitEkle(new Entities.Rehber()
                {
                    ID = Guid.NewGuid(),
                    Isim = isim,
                    SoyIsim = soyisim,
                    TelefonNumarasiI = telefonNumaraI,
                    TelefonNumarasiII = telefonNumaraII,
                    TelefonNumarasiIII = telefonNumaraIII,
                    EmailAdres = EmailAdres,
                    WebAdres = Webadres,
                    Adres = Adres,
                    Aciklama = Aciklama
                });               
            }
            else
            {
                return -1; //hata oluştuğunda
            }

        }


        public int KayitDuzenle(Guid ID,string isim, string soyisim, string telefonNumaraI, string telefonNumaraII, string telefonNumaraIII, string EmailAdres, string Webadres, string Adres, string Aciklama)
        {
            if (ID!=Guid.Empty)
            {
                return dll.KayitDuzenle(new Entities.Rehber()
                {
                    ID = ID,
                    Isim = isim,
                    SoyIsim = soyisim,
                    TelefonNumarasiI = telefonNumaraI,
                    TelefonNumarasiII = telefonNumaraII,
                    TelefonNumarasiIII = telefonNumaraIII,
                    EmailAdres = EmailAdres,
                    WebAdres = Webadres,
                    Adres = Adres,
                    Aciklama = Aciklama
                });
            }
            else
            {
                return -1; //hata oluştuğunda
            }

        }

        public int KayitSil(Guid ID)
        {
            if (ID != Guid.Empty)
            {
                return dll.kayitSil(ID);
            }
            else return -1;
        }

        public int SistemKontrol(string kullaniciadi,string sifre)
        {
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
              return dll.SistemKontrol(new Entities.Kullanici()
                {
                    KullaniciAdi = kullaniciadi,
                    Sifre = sifre
                });
            }
            else return -1;
        }

        public DataTable KayitListeleView()
        {
            DataTable dt2 = dll.KayitListeleView();
            return dt2;
        }


        public List<Rehber> KayitListele()
        {

            List<Rehber> RehberListesi = new List<Rehber>();
            try
            {
                SqlDataReader reader = dll.kayitListe();
                while (reader.Read())
                {
                    RehberListesi.Add(new Rehber()
                    {

                   ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                   Isim = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                   SoyIsim = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        TelefonNumarasiI = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        TelefonNumarasiII = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        TelefonNumarasiIII = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        EmailAdres = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        WebAdres = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Adres = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Aciklama = reader.IsDBNull(9) ? string.Empty : reader.GetString(9)
                    });
                }
                reader.Close();
            }
            catch
            {
            }
            finally
            {
                dll.BaglantiAyarla();
            }
            return RehberListesi;
        }


    }
}
