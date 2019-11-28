using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LTGD_Project.DTO
{
    public class Category
    {
        public int IdCat { set; get; }
        public string NameCat { set; get; }
        public string ImgCat { set; get; }

        public Category(DataRow row)
        {
            this.IdCat = (int)row["idCat"];
            this.NameCat = (string)row["nameCat"];
            this.ImgCat = (string)row["imgCat"];
        }
        public Category() { }
    }
}
