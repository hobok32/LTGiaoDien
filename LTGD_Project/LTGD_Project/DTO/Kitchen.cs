using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTGD_Project.DTO
{
    public class Kitchen
    {
        public int IdTable { set; get; }
        public string NameTable { set; get; }
        public string StatusTable { set; get; }
        public string Notes { set; get; }
        public List<KitchenBill> Bills { set; get; }
    }
    public class KitchenBill
    {
        public string NameProduct { set; get; }
        public string Size { set; get; }
        public int SoLuong { set; get; }
        public string Status { set; get; }
        public List<KitchenTopping> Topping { set; get; }
    }
    public class KitchenTopping
    {
        public string SoLuong { set; get; }
        public string ToppingName { set; get; }
    }
}
