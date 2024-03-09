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
     * @class lunch_to_lunch_type_match
     * @brief This class represents a match between a lunch and a lunch type.
     * It inherits from the ParentClass.
     */
    internal class lunch_to_lunch_type_match : ParentClass
    {
        /**
         * @brief The constructor of the lunch_to_lunch_type_match class.
         * It initializes the ID string and the table name.
         */
        public lunch_to_lunch_type_match()
        {
            P_MyTable = "lunch_to_lunch_type_match"; ///< @brief The table name of the lunch to lunch type match.
            P_MyIdString = "lunch_match_id"; ///< @brief The ID string of the lunch to lunch type match.
        }

        int lunch_match_id; ///< @brief The ID of the lunch to lunch type match.
        int lunch_id; ///< @brief The ID of the lunch.
        int lunch_type_id; ///< @brief The ID of the lunch type.

        /**
         * @brief A property that gets or sets the ID of the lunch to lunch type match.
         */
        public int P_lunch_match_id
        {
            get
            {
                return lunch_match_id;
            }
            set
            {
                lunch_match_id = value;
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
    }
}
