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

        public List<Category> LoadTableList()
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
    }
}
