using Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DatabaseLogicLayer
{
    public class DLL
    {
        SqlConnection con;
        SqlCommand cmd;
        int donen_deger;

        public DLL()
        {
            //con = new SqlConnection            ("Server=.;Database=TelefonRehberi;USER=sa;PWD=1234");
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["localBaglanti"].ConnectionString);
        }

        public void BaglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            else
                con.Close();
        }

        public int KayitEkle(Rehber R)
        {
            try
            {
                cmd = new SqlCommand("insert into Rehber (ID,Isim,Soyisim,TelefonNumarasiI,TelefonNumarasiII,TelefonNumarasiIII,EmailAdres,WebAdres,Adres,Aciklama) values (@ID, @Isim, @Soyisim, @TelefonNumarasiI, @TelefonNumarasiII, @TelefonNumarasiIII, @EmailAdres, @WebAdres, @Adres, @Aciklama)", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.SoyIsim;
                cmd.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebAdres", SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }

        public int KayitDuzenle(Rehber R)
        {
            try
            {
                cmd = new SqlCommand("update Rehber set Isim=@Isim,Soyisim=@Soyisim,TelefonNumarasiI= @TelefonNumarasiI,TelefonNumarasiII= @TelefonNumarasiII,TelefonNumarasiIII= @TelefonNumarasiIII,EmailAdres=@EmailAdres,WebAdres=@WebAdres,Adres=@Adres,Aciklama=@Aciklama where ID=@ID", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.SoyIsim;
                cmd.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebAdres", SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }


        public int kayitSil(Guid ID)
        {

            try
            {
                cmd = new SqlCommand("DELETE Rehber WHERE ID=@ID ", con);

                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }

        public int SistemKontrol(Kullanici K)
        {
            try
            {
                cmd = new SqlCommand("select count(*) from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", con);
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = K.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = K.Sifre;
                BaglantiAyarla();
                donen_deger = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;
        }

        public DataTable KayitListeleView() //datagrid için
        {
            DataTable dt1 = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("Select * From Rehber",con);
                adp.Fill(dt1);
                return dt1;
            }
            catch (Exception)
            {
                return dt1;
            }

        }

        public SqlDataReader kayitListe()  //Listbox için
        {
            cmd = new SqlCommand("Select * from Rehber", con);
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }



    }
}
