using BELunchTool.Classes;
using BELunchTool.Properties;
using BEToolsClassLibrary;
using CommonWinForms.CommonForms;
using ConnectivityAndSQl_Namespace;
using System.Data;

namespace BELunchTool
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();

        }

        List<lunch_option> list_of_lunches = new List<lunch_option>();
        Connection_Handler Connection_Handler = new Connection_Handler();



        private void main_form_Load(object sender, EventArgs e)
        {
            InitLunchLists();
        }

        private void InitLunchLists()
        {
            //initializes the columns for all the three lists in the form
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ListView)
                {
                    ListView ListView_instance = ctrl as ListView;
                    ListView_instance.View = View.Details;
                    ListView_instance.Columns.Add("Lunch Description", 600, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Cost", 100, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Quantity", 100, HorizontalAlignment.Left);
                }
            }

        }

        private bool PopulateLunchList()
        { //populates the list of available lunches
            DataTable dt = new DataTable();
            lunch_option lunch_option_instance = new lunch_option();
            try
            {
                dt = SQL_Queries.GetValues(Connection_Handler, lunch_option_instance.P_MyTable, "", DistinctOrGeneral.General);
                foreach (DataRow dataRow in dt.Rows)
                {
                    lunch_option lunch_opt = new lunch_option();
                    lunch_opt.UpdateProperty(dataRow, lunch_opt, dt);
                    list_of_lunches.Add(lunch_opt);
                }
                return true;
            }
            catch (ErrorHandler error)
            {
                error.LogWrite();
                return false;
            }

        }

        private bool PopulateLunchListViews()
        {
            //populates the list of available lunches with the name, price and available quantity
            foreach (lunch_option lunch in list_of_lunches)
            {
                return true;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //opens the quantity editing screen - required authentication before proceeding
            login_form login_Form = new login_form(this); 
            login_Form.ShowDialog();
            if(login_Form.autorized)
            {
                lunch_warehouse lunch_Warehouse = new lunch_warehouse();
                lunch_Warehouse.current_user = login_Form.P_User_Object;
                lunch_Warehouse.Show();
            }

        }
    }
}