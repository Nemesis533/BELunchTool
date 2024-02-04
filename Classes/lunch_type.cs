using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEToolsClassLibrary;
using Common_Classes_Namespace;

namespace BELunchTool.Classes
{
    internal class lunch_type : ParentClass
    {
        public lunch_type()         
        {
            P_MyTable = "lunch_type_table   ";
            P_MyIdString = "lunch_type_id";
            P_MyNameString = "lunch_type_desc";
        }
    }
}
