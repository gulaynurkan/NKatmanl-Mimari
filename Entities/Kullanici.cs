using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanici
    {
        public Guid KullaniciID { get; set; } //uniqueidentifier alan
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
