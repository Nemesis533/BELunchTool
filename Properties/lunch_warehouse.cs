using BELunchTool.Classes;
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
using Common_WinfForm;
using BEToolsClassLibrary;
using CommonWinForms.CommonForms;
using BELunchTool;

namespace BELunchTool.Properties
{
    public partial class lunch_warehouse : Form
    {
        public lunch_warehouse()
        {
            InitializeComponent();
            this.user_name.DropDown += new System.EventHandler(this.user_name_DropDown);
            this.lunch_name.DropDown += new System.EventHandler(this.lunch_name_DropDown);
            this.lunch_type_desc.DropDown += new System.EventHandler(this.lunch_type_desc_DropDown);
            InitLunchLists();

        }
        public User_Object current_user = new User_Object();
        Connection_Handler Connection_Handler = new Connection_Handler();
        lunch_option current_option = new lunch_option();
        lunch_type current_type = new lunch_type();
        List<lunch_option> list_of_purchased_items = new List<lunch_option>();
        main_form main_Form = new main_form();

        private void InitLunchLists()
        {
            //initializes the columns for all the three lists in the form
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ListView)
                {
                    if (ctrl.Name == "lunch_options_view")
                    {
                        ListView ListView_instance = ctrl as ListView;
                        ListView_instance.View = View.Details;
                        ListView_instance.Columns.Add("Piatto", 200, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Descrizione", 400, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Costo", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Prezzo", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Quantita", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Codice BE", 100, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Codice Fornitore", 100, HorizontalAlignment.Left);
                    }

                    if (ctrl.Name == "user_purchases")
                    {
                        ListView ListView_instance = ctrl as ListView;
                        ListView_instance.View = View.Details;
                        ListView_instance.Columns.Add("ID", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Piatto", 550, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Quantita'", 100, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Prezzo", 100, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Data", 100, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Stato", 100, HorizontalAlignment.Left);

                    }

                    if (ctrl.Name == "lunch_type_view")
                    {
                        ListView ListView_instance = ctrl as ListView;
                        ListView_instance.View = View.Details;
                        ListView_instance.Columns.Add("Tipo Piatto", 285, HorizontalAlignment.Left);
                    }
                }


            }

        }


        private void lunch_warehouse_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void user_name_DropDown(object sender, EventArgs e)
        {
            Common_Functions_WinfForm.PopulateComboBoxWithObjName(user_name, current_user, Connection_Handler, true);
        }


        private void lunch_name_DropDown(object sender, EventArgs e)
        {

            lunch_option lunch_Option = new lunch_option();
            Common_Functions_WinfForm.PopulateComboBoxWithObjName(lunch_name, lunch_Option, Connection_Handler, false);
        }

        private void lunch_type_desc_DropDown(object sender, EventArgs e)
        {
            lunch_type lunch_Type = new lunch_type();
            Common_Functions_WinfForm.PopulateComboBoxWithObjName(lunch_type_desc, lunch_Type, Connection_Handler, false);
        }

        private bool confirm_update(string control_name)
        {
            string item_to_update = "";
            if (control_name == current_option.P_MyNameString)
            {
                item_to_update = current_option.P_lunch_name;
            }
            else
            {
                item_to_update = current_type.P_lunch_type_desc;
            }
            DialogResult result = MessageBox.Show($"Do you want to update meal {item_to_update} ", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool save_or_update_data(bool update_lunch_name = false, bool update_type_name = false)
        {
            lunch_option lunch_Option = new lunch_option();
            lunch_type lunch_type = new lunch_type();
            try
            {
                Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(lunch_Option, this, false);
                if (update_lunch_name) { lunch_Option.P_lunch_name = current_option.P_lunch_name; }; //this way the name can be updated instead of creatign a new option - otherwise it just writes what it finds
                if (current_option.P_lunch_id != 0) { lunch_Option.P_lunch_id = current_option.P_lunch_id; } //shoudl this be an existing option, the id gets written to it can update
                lunch_Option.P_lunch_id = SQL_Queries.UpdateOrWriteSingleLine(lunch_Option, current_user, true);
            }
            catch (ErrorHandler err)
            {
                err.LogWrite("Error while saving");
                return false;
            }
            try
            {
                Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(lunch_type, this, false);
                if (current_type.P_lunch_type_id != 0) { lunch_type.P_lunch_type_id = current_type.P_lunch_type_id; } //should this be an existing option, the id gets written to it can update
                lunch_to_lunch_type_match Lunch_Type_Match = new lunch_to_lunch_type_match();
                Lunch_Type_Match.P_lunch_id = lunch_Option.P_lunch_id;
                Lunch_Type_Match.P_lunch_type_id = lunch_type.P_lunch_type_id;
                Lunch_Type_Match.P_lunch_match_id = SQL_Queries.UpdateOrWriteSingleLine(Lunch_Type_Match, current_user, true);
            }
            catch (ErrorHandler err)
            {
                err.LogWrite("Error while saving");
                return false;
            }
            return true;
        }

        private void save_lunch_data_Click(object sender, EventArgs e)
        {
            //will check if all compulsory fields are populated and then insert or update the values
            if (Common_Functions_WinfForm.CheckControlsByTag(this, Common_Functions_WinfForm.TagsList.compulsory))
            {
                if (save_or_update_data())
                {
                    Common_Functions_WinfForm.DisplayMessage($"Data successfully saved for meal {lunch_name.Text}", "Data Saved", ButtonTypesEnum.OkOnly);
                }
            }
        }

        private void lunch_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_option = new lunch_option();
            current_option.P_lunch_id = Convert.ToInt32(SQL_Queries.GetValues(Connection_Handler, current_option.P_MyTable, current_option.P_MyIdString, DistinctOrGeneral.Distinct, current_option.P_MyNameString, lunch_name.SelectedItem.ToString()).Rows[0][0]);
            if (int.TryParse(current_option.P_lunch_id.ToString(), out _))
            {
                current_option.PopulateSelf(Connection_Handler);
                Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(current_option, this, true);
            }
            else
            {
                current_option.P_lunch_id = 0;
            }

        }
        private void lunch_type_desc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            current_type = new lunch_type();
            current_type.P_lunch_type_id = Convert.ToInt32(SQL_Queries.GetValues(Connection_Handler, current_type.P_MyTable, current_type.P_MyIdString, DistinctOrGeneral.Distinct, current_type.P_MyNameString, lunch_type_desc.SelectedItem.ToString()).Rows[0][0]);
            if (int.TryParse(current_type.P_lunch_type_id.ToString(), out _))
            {
                current_type.PopulateSelf(Connection_Handler);
                Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(current_type, this, true);
            }
            else
            {
                current_type.P_lunch_type_id = 0;
            }
        }

        private void user_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_user_purchases();
        }

        private void load_user_purchases()
        {
            //this will either load the purchases of all users or those of a single one, either open or closed or both

            DataTable dt = new DataTable();
            user_purchase_obj user_Purchase_Obj = new user_purchase_obj();
            lunch_option lunch_Option = new lunch_option();
            User_Object selected_user = new User_Object();
            selected_user.P_user_id = Convert.ToInt32(SQL_Queries.GetValues(Connection_Handler, selected_user.P_MyTable, selected_user.P_MyIdString, DistinctOrGeneral.Distinct, selected_user.P_MyNameString, user_name.SelectedItem.ToString(), AndOR.ANDEnum, true).Rows[0][0]);
            if (selected_user.P_user_id == 0)
            {
                return;
            }
            else
            {
                selected_user.PopulateSelf(Connection_Handler);
            }
            dt = SQL_Queries.GetValues(Connection_Handler, user_Purchase_Obj.P_MyTable, lunch_Option.P_MyIdString, DistinctOrGeneral.General, selected_user.P_MyIdString + "|" + "status", selected_user.P_user_id.ToString() + "|" + "0");
            foreach (DataRow dataRow in dt.Rows)
            {
                user_Purchase_Obj.P_user_purchase_id = Convert.ToInt16(dataRow[user_Purchase_Obj.P_MyIdString]);
                user_Purchase_Obj.PopulateSelf(Connection_Handler);
                lunch_Option.P_lunch_id = Convert.ToInt32(dataRow[lunch_Option.P_MyIdString]);
                lunch_Option.PopulateSelf(Connection_Handler);
                lunch_Option.P_lunch_id = Convert.ToInt16(dataRow[lunch_Option.P_MyIdString]);
                list_of_purchased_items.Add(lunch_Option);
                ListViewItem item = new ListViewItem(new[] { user_Purchase_Obj.P_user_purchase_id.ToString(), lunch_Option.P_lunch_name + lunch_Option.P_lunch_desc, lunch_Option.P_lunch_price.ToString(), user_Purchase_Obj.P_date.ToString(), user_Purchase_Obj.P_status.ToString() });
                user_purchases.Items.Add(item);
            }
            user_open.Text = main_Form.get_sum_from_list(list_of_purchased_items).ToString() + " Euro";
        }

    }
}
