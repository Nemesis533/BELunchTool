using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEToolsClassLibrary;
using Common_Classes_Namespace;

namespace BELunchTool.Classes
{
    internal class lunch_option : ParentClass
     {

        public lunch_option() 
        {
            P_MyTable = "lunch_options";
            P_MyIdString = "lunch_id";
            P_MyNameString = "lunch_desc";
        }

        int lunch_type;
        int lunch_stock_qty;
        float lunch_cost;
        float lunch_price;
        string lunch_supplier_code;
        string lunch_be_code;

        public int P_LunchType { get; set; }
        public int P_LunchStockQty { get; set; }
        public decimal P_LunchCost { get; set; }
        public decimal P_LunchPrice { get; set; }
        public string P_LunchSupplierCode { get; set; }
        public string P_LunchBeCode { get; set; }
        public string P_lunch_desc { get; set; }



    }
}
