using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEToolsClassLibrary;
using Common_Classes_Namespace;

namespace BELunchTool.Classes
{
    internal class user_purchase_obj : ParentClass
    {
        public user_purchase_obj()
        {
            P_MyIdString = "user_purchase_id";
            P_MyTable = "user_purchases";

        }
        int user_purchase_id;
        int user_id;
        int lunch_id;
        DateTime date;
        int status;

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
