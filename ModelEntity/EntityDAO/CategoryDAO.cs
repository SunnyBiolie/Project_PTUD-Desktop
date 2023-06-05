using Project_PTUD_Desktop.Model.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }
            private set => instance = value;
        }
        private CategoryDAO() { }


        public List<string> GetListTenTheLoaisFromListTheLoais(ICollection<TheLoai> listCategory)
        {
            List<string> list = new List<string>();
            foreach (TheLoai theLoai in listCategory)
            {
                list.Add(theLoai.TenTheLoai);
            }

            return list;
        }
    }
}
