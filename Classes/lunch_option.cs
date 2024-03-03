using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEToolsClassLibrary;
using Common_Classes_Namespace;

namespace BELunchTool.Classes
{
    public class lunch_option : ParentClass
     {

        public lunch_option() 
        {
            P_MyTable = "lunch_options";
            P_MyIdString = "lunch_id";
            P_MyNameString = "lunch_name";
        }

        int lunch_type;
        int lunch_stock_qty;
        float lunch_cost;
        float lunch_price;
        string lunch_supplier_code;
        string lunch_be_code;
        string lunch_desc;
        string lunch_name;
        int lunch_id;

        public string P_lunch_desc
        {
            get
            {
                return lunch_desc;
            }
            set
            {
                lunch_desc = value;
            }
        }

           public string P_lunch_name
        {
            get
            {
                return lunch_name;
            }
            set
            {
                lunch_name = value;
            }
        }

        public int P_lunch_type
        {
            get
            {
                return lunch_type;
            }
            set
            {
                lunch_type = value;
            }
        }

        public int P_lunch_id
        {
            get
            {
                return lunch_id;
            }
            set
            {
                lunch_id = value;
            }
        }

        public int P_lunch_stock_qty
        {
            get
            {
                return lunch_stock_qty;
            }
            set
            {
                lunch_stock_qty = value;
            }
        }

        public float P_lunch_cost
        {
            get
            {
                return lunch_cost;
            }
            set
            {
                lunch_cost = value;
            }
        }

        public float P_lunch_price
        {
            get
            {
                return lunch_price;
            }
            set
            {
                lunch_price = value;
            }
        }

        public string P_lunch_supplier_code
        {
            get
            {
                return lunch_supplier_code;
            }
            set
            {
                lunch_supplier_code = value;
            }
        }

        public string P_lunch_be_code
        {
            get
            {
                return lunch_be_code;
            }
            set
            {
                lunch_be_code = value;
            }
        }


    }
}
