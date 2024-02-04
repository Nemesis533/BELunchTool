using Common_Classes_Namespace;
using ConnectivityAndSQl_Namespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BELunchTool.Properties
{
    public partial class lunch_warehouse : Form
    {
        public lunch_warehouse()
        {
            InitializeComponent();
            this.user_name.DropDown += new System.EventHandler(this.user_name_DropDown);
        }
        public  User_Object current_user = new User_Object();
        Connection_Handler Connection_Handler = new Connection_Handler();

        private void lunch_warehouse_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void user_name_DropDown(object sender, EventArgs e)
        {
            // This code will be executed when the ComboBox is dropped down
            DataTable dt = new DataTable();
            dt = SQL_Queries.GetValues(Connection_Handler, current_user.P_MyTable, current_user.P_MyNameString, DistinctOrGeneral.General, "", "", AndOR.ANDEnum, true);
            user_name.Items.Clear();
            foreach (DataRow dr in dt.Rows) 
            {
                user_name.Items.Add(dr[1].ToString());  
            }
        }
    }
}
