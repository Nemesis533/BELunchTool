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
     * @class lunch_type
     * @brief This class represents a lunch type.
     * It inherits from the ParentClass.
     */
    internal class lunch_type : ParentClass
    {
        /**
         * @brief The constructor of the lunch_type class.
         * It initializes the ID string, the description string, and the table name.
         */
        public lunch_type()
        {
            P_MyTable = "lunch_type_table"; ///< @brief The table name of the lunch type.
            P_MyIdString = "lunch_type_id"; ///< @brief The ID string of the lunch type.
            P_MyNameString = "lunch_type_desc"; ///< @brief The description string of the lunch type.
        }

        int lunch_type_id; ///< @brief The ID of the lunch type.
        string lunch_type_desc; ///< @brief The description of the lunch type.

        /**
         * @brief A property that gets or sets the ID of the lunch type.
         */
        public int P_lunch_type_id
        {
            get
            {
                return lunch_type_id;
            }
            set
            {
                lunch_type_id = value;
            }
        }

        /**
         * @brief A property that gets or sets the description of the lunch type.
         */
        public string P_lunch_type_desc
        {
            get
            {
                return lunch_type_desc;
            }
            set
            {
                lunch_type_desc = value;
            }
        }
    }
}
