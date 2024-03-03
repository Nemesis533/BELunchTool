using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEToolsClassLibrary;
using Common_Classes_Namespace;

namespace BELunchTool.Classes
{
    internal class lunch_to_lunch_type_match : ParentClass
    {

        public lunch_to_lunch_type_match()
        {
            P_MyTable = "lunch_to_lunch_type_match";
            P_MyIdString = "lunch_match_id";
        }
        int lunch_match_id;
        int lunch_id;
        int lunch_type_id;

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
