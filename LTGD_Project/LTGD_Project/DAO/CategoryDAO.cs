using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;
using System.Data;

namespace LTGD_Project.DAO
{
    class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return CategoryDAO.instance;
            }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }

        public List<Category> SelectAllCat()
        {
            List<Category> cats = new List<Category>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM category");
            foreach (DataRow item in data.Rows)
            {
                Category cat = new Category(item);
                cats.Add(cat);
            }
            return cats;
        }

        public bool AddCat(string name, string img)
        {
            string strCmd = "INSERT INTO category VALUES (null, @nameCat , @imgCat );";
            return DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { name, img }) > 0;
        }

        public bool EditCat(string name, string img, int idCat)
        {
            string strCmd = "UPDATE category SET nameCat= @nameCat , imgCat= @imgCat WHERE idCat= @idCat ";
            return DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { name, img, idCat }) > 0;
        }

        public bool DelCat(int idCat)
        {
            string strCmd = "DELETE FROM category WHERE idCat = @idCat ";
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { idCat }) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
