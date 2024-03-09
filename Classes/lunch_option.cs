using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEToolsClassLibrary;
using Common_Classes_Namespace;

namespace BELunchTool.Classes
{
    /**
     * @class lunch_option
     * @brief This class represents a lunch option.
     * It inherits from the ParentClass.
     */
    public class lunch_option : ParentClass
    {
        /**
         * @brief The constructor of the lunch_option class.
         * It initializes the ID string, the name string, and the table name.
         */
        public lunch_option()
        {
            P_MyTable = "lunch_options"; ///< @brief The table name of the lunch option.
            P_MyIdString = "lunch_id"; ///< @brief The ID string of the lunch option.
            P_MyNameString = "lunch_name"; ///< @brief The name string of the lunch option.
        }

        int lunch_type; ///< @brief The type of the lunch.
        int lunch_stock_qty; ///< @brief The stock quantity of the lunch.
        float lunch_cost; ///< @brief The cost of the lunch.
        float lunch_price; ///< @brief The price of the lunch.
        string lunch_supplier_code; ///< @brief The supplier code of the lunch.
        string lunch_be_code; ///< @brief The BE code of the lunch.
        string lunch_desc; ///< @brief The description of the lunch.
        string lunch_name; ///< @brief The name of the lunch.
        int lunch_id; ///< @brief The ID of the lunch.

        /**
         * @brief A property that gets or sets the description of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the name of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the type of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the ID of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the stock quantity of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the cost of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the price of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the supplier code of the lunch.
         */
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

        /**
         * @brief A property that gets or sets the BE code of the lunch.
         */
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
