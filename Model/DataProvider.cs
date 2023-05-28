using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }
            set { instance = value; }
        }
        public QLDLRapPhimEntities Database { get; set; }
        private DataProvider()
        {
            Database = new QLDLRapPhimEntities();
        }
    }
}
