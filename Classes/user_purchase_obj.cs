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
     * @class user_purchase_obj
     * @brief This class represents a user purchase object.
     * It inherits from the ParentClass.
     */
    public class user_purchase_obj : ParentClass
    {
        /**
         * @brief The constructor of the user_purchase_obj class.
         * It initializes the ID string and the table name.
         */
        public user_purchase_obj()
        {
            P_MyIdString = "user_purchase_id"; ///< @brief The ID string of the user purchase object.
            P_MyTable = "user_purchases"; ///< @brief The table name of the user purchase object.
        }

        int user_purchase_id; ///< @brief The ID of the user purchase.
        int user_id; ///< @brief The ID of the user.
        int lunch_id; ///< @brief The ID of the lunch.
        DateTime date; ///< @brief The date of the purchase.
        int status; ///< @brief The status of the purchase.
        int status_changed_by; ///< @brief int containign a reference to who changed the status.
        DateTime changed_date; ///< @brief date when the status was changed

        /**
         * @brief A property that gets or sets the status of the purchase.
         */
        public int P_status_changed_by
        {
            get
            {
                return status_changed_by;
            }
            set
            {
                status_changed_by = value;
            }
        }

        /**
         * @brief A property that gets or sets the status of the purchase.
         */
        public DateTime P_changed_date
        {
            get
            {
                return changed_date;
            }
            set
            {
                changed_date = value;
            }
        }


        /**
         * @brief A property that gets or sets the status of the purchase.
         */
        public int P_status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        /**
         * @brief A property that gets or sets the ID of the user purchase.
         */
        public int P_user_purchase_id
        {
            get
            {
                return user_purchase_id;
            }
            set
            {
                user_purchase_id = value;
            }
        }

        /**
         * @brief A property that gets or sets the ID of the user.
         */
        public int P_user_id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
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
         * @brief A property that gets or sets the date of the purchase.
         */
        public DateTime P_date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
    }
}
