using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDAO
{
    public class PlanDAO
    {
        private static PlanDAO instance;
        public static PlanDAO Instance
        {
            get
            {
                if (instance == null) instance = new PlanDAO();
                return instance;
            }
            private set => instance = value;
        }
        private PlanDAO() { }

        
        
    }
}
