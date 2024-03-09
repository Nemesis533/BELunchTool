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
using System.Reflection;
using System.Diagnostics.Metrics;
using ExcelLibrary.SpreadSheet;
using Microsoft.VisualBasic.ApplicationServices;

namespace BELunchTool.Properties
{
    public partial class lunch_warehouse : Form
    {
        /**
         * @brief This is the constructor of the lunch_warehouse class.
         * It initializes the components, sets the event handlers for the DropDown events of user_name, lunch_name, and lunch_type_desc,
         * initializes the lunch lists, populates the lunch view list, and sets the values of start_date and end_date.
         */
        public lunch_warehouse()
        {
            InitializeComponent(); ///< @brief Initialize the components.
            this.user_name.DropDown += new System.EventHandler(this.user_name_DropDown); ///< @brief Set the event handler for the DropDown event of user_name.
            this.lunch_name.DropDown += new System.EventHandler(this.lunch_name_DropDown); ///< @brief Set the event handler for the DropDown event of lunch_name.
            this.lunch_type_desc.DropDown += new System.EventHandler(this.lunch_type_desc_DropDown); ///< @brief Set the event handler for the DropDown event of lunch_type_desc.
            InitLunchLists(); ///< @brief Initialize the lunch lists.
            populate_lunch_view_list(); ///< @brief Populate the lunch view list.
            // Existing comment: setting datetimepicker values
            start_date.Value = DateTime.Today.AddDays(-30); ///< @brief Set the value of start_date to 30 days before today.
            end_date.Value = DateTime.Today; ///< @brief Set the value of end_date to today.
        }

        public User_Object current_user = new User_Object(); ///< @brief current_user is an instance of the User_Object class.
        Connection_Handler Connection_Handler = new Connection_Handler(); ///< @brief Connection_Handler is an instance of the Connection_Handler class.
        lunch_option current_option = new lunch_option(); ///< @brief current_option is an instance of the lunch_option class.
        lunch_type current_type = new lunch_type(); ///< @brief current_type is an instance of the lunch_type class.
        List<lunch_option> list_of_purchased_items = new List<lunch_option>(); ///< @brief list_of_purchased_items is a list of purchased lunch options.
        List<user_purchase_obj> user_purchase_obj_list = new List<user_purchase_obj>(); ///< @brief user_purchase_obj_list is a list of user purchase objects.
        main_form main_Form = new main_form(); ///< @brief main_Form is an instance of the main_form class.

        /**
         * @brief This method initializes the columns for all the three lists in the form.
         */
        private void InitLunchLists()
        {
            // Existing comment: initializes the columns for all the three lists in the form
            foreach (Control ctrl in this.Controls) ///< @brief Iterate over the controls in this form.
            {
                if (ctrl is ListView) ///< @brief Check if the control is a ListView.
                {
                    if (ctrl.Name == "lunch_options_view") ///< @brief Check if the control is lunch_options_view.
                    {
                        ListView ListView_instance = ctrl as ListView; ///< @brief ListView_instance is the current ListView control.
                        ListView_instance.View = View.Details; ///< @brief Set the ListView's view to Details.
                        // Add columns to the ListView.
                        ListView_instance.Columns.Add("Piatto", 200, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Descrizione", 400, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Costo", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Prezzo", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Quantita", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Codice BE", 100, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Codice Fornitore", 100, HorizontalAlignment.Left);
                    }

                    if (ctrl.Name == "user_purchases") ///< @brief Check if the control is user_purchases.
                    {
                        ListView ListView_instance = ctrl as ListView; ///< @brief ListView_instance is the current ListView control.
                        ListView_instance.View = View.Details; ///< @brief Set the ListView's view to Details.
                        // Add columns to the ListView.
                        ListView_instance.Columns.Add("ID", 50, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Piatto", 550, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Prezzo", 100, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Data", 100, HorizontalAlignment.Left);
                        ListView_instance.Columns.Add("Stato", 100, HorizontalAlignment.Left);
                    }

                    if (ctrl.Name == "lunch_type_view") ///< @brief Check if the control is lunch_type_view.
                    {
                        ListView ListView_instance = ctrl as ListView; ///< @brief ListView_instance is the current ListView control.
                        ListView_instance.View = View.Details; ///< @brief Set the ListView's view to Details.
                        ListView_instance.Columns.Add("Tipo Piatto", 285, HorizontalAlignment.Left); ///< @brief Add a column to the ListView.
                    }
                }
            }
        }


        /**
  * @brief This method populates the lunch_options_view ListView with lunch options.
  * It fetches the values from the database, clears the ListView, and adds the fetched values to the ListView.
  */
        private void populate_lunch_view_list()
        {
            lunch_option lunch_option_item = new lunch_option(); ///< @brief lunch_option_item is an instance of the lunch_option class.
            System.Data.DataTable dataTable = new System.Data.DataTable(); ///< @brief dataTable is used to store the fetched data.
            dataTable = SQL_Queries.GetValues(current_user.P_Conn_Handler, lunch_option_item.P_MyTable, lunch_option_item.P_MyNameString, DistinctOrGeneral.General); ///< @brief Fetch the values from the database.
            lunch_options_view.Items.Clear(); ///< @brief Clear all items of the lunch_options_view.
            foreach (DataRow row in dataTable.Rows) ///< @brief Iterate over the rows of the fetched data.
            {
                lunch_option_item.P_lunch_id = Convert.ToInt32(row[0]); ///< @brief Set the lunch_id of lunch_option_item.
                lunch_option_item.PopulateSelf(current_user.P_Conn_Handler); ///< @brief Populate the properties of lunch_option_item.
                ListViewItem item = new ListViewItem(new[] { lunch_option_item.P_lunch_name, lunch_option_item.P_lunch_desc, lunch_option_item.P_lunch_cost.ToString(), lunch_option_item.P_lunch_price.ToString(), lunch_option_item.P_lunch_stock_qty.ToString(), lunch_option_item.P_lunch_be_code, lunch_option_item.P_lunch_supplier_code }); ///< @brief item is a ListViewItem created for each lunch option.
                lunch_options_view.Items.Add(item); ///< @brief Add item to the lunch_options_view.
            }
        }

        /**
         * @brief This method is triggered when the DropDown event of user_name is fired.
         * It populates the ComboBox with the names of the users.
         */
        private void user_name_DropDown(object sender, EventArgs e)
        {
            Common_Functions_WinfForm.PopulateComboBoxWithObjName(user_name, current_user, Connection_Handler, true); ///< @brief Populate the ComboBox with the names of the users.
        }

        /**
         * @brief This method is triggered when the DropDown event of lunch_name is fired.
         * It populates the ComboBox with the names of the lunch options.
         */
        private void lunch_name_DropDown(object sender, EventArgs e)
        {
            lunch_option lunch_Option = new lunch_option(); ///< @brief lunch_Option is an instance of the lunch_option class.
            Common_Functions_WinfForm.PopulateComboBoxWithObjName(lunch_name, lunch_Option, Connection_Handler, false); ///< @brief Populate the ComboBox with the names of the lunch options.
        }

        /**
         * @brief This method is triggered when the DropDown event of lunch_type_desc is fired.
         * It populates the ComboBox with the descriptions of the lunch types.
         */
        private void lunch_type_desc_DropDown(object sender, EventArgs e)
        {
            lunch_type lunch_Type = new lunch_type(); ///< @brief lunch_Type is an instance of the lunch_type class.
            Common_Functions_WinfForm.PopulateComboBoxWithObjName(lunch_type_desc, lunch_Type, Connection_Handler, false); ///< @brief Populate the ComboBox with the descriptions of the lunch types.
        }

        /**
         * @brief This method confirms the update of a meal or a lunch type.
         * It shows a message box to ask the user if they want to update the meal or the lunch type.
         * @param control_name The name of the control to be updated.
         * @return true if the user confirmed the update, false otherwise.
         */
        private bool confirm_update(string control_name)
        {
            string item_to_update = ""; ///< @brief item_to_update is the item to be updated.
            if (control_name == current_option.P_MyNameString) ///< @brief Check if the control to be updated is a meal.
            {
                item_to_update = current_option.P_lunch_name; ///< @brief Set item_to_update to the name of the meal.
            }
            else
            {
                item_to_update = current_type.P_lunch_type_desc; ///< @brief Set item_to_update to the description of the lunch type.
            }
            DialogResult result = MessageBox.Show($"Do you want to update meal {item_to_update} ", "Confirmation", MessageBoxButtons.YesNo); ///< @brief Show a message box to ask the user if they want to update the meal or the lunch type.
            if (result == DialogResult.Yes) ///< @brief Check if the user confirmed the update.
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /**
 * @brief This method saves or updates the data of a lunch option or a lunch type.
 * It populates the lunch option and lunch type objects from the UI, and then inserts or updates the values in the database.
 * @param create_lunch_name A boolean indicating whether to create a new lunch name.
 * @param update_type_name A boolean indicating whether to update the lunch type name.
 * @return true if the operation is successful, false otherwise.
 */
        private bool save_or_update_data(bool create_lunch_name = false, bool update_type_name = false)
        {
            lunch_option lunch_Option = new lunch_option(); ///< @brief lunch_Option is an instance of the lunch_option class.
            lunch_type lunch_type = new lunch_type(); ///< @brief lunch_type is an instance of the lunch_type class.
            try
            {
                Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(lunch_Option, this, false); ///< @brief Populate the lunch option object from the UI.
                // Existing comment: this way the name can be updated instead of creating a new option - otherwise it just writes what it finds
                if (create_lunch_name) { current_option.P_lunch_id = 0; }; ///< @brief Set the lunch_id of current_option to 0 if a new lunch name is to be created.
                // Existing comment: should this be an existing option, the id gets written so it can update
                if (current_option.P_lunch_id != 0) { lunch_Option.P_lunch_id = current_option.P_lunch_id; } ///< @brief Set the lunch_id of lunch_Option if the current option is an existing option.
                current_option.P_lunch_id = SQL_Queries.UpdateOrWriteSingleLine(lunch_Option, current_user, true); ///< @brief Update or write a single line to the database.
            }
            catch (ErrorHandler err) ///< @brief Catch any ErrorHandler exceptions.
            {
                err.LogWrite("Errore Durante il Salvataggio"); ///< @brief Write the error log.
                return false;
            }
            try
            {
                Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(lunch_type, this, false); ///< @brief Populate the lunch type object from the UI.
                // Existing comment: should this be an existing option, the id gets written so it can update
                if (current_type.P_lunch_type_id != 0) { lunch_type.P_lunch_type_id = current_type.P_lunch_type_id; } ///< @brief Set the lunch_type_id of lunch_type if the current type is an existing type.
                lunch_to_lunch_type_match Lunch_Type_Match = new lunch_to_lunch_type_match(); ///< @brief Lunch_Type_Match is an instance of the lunch_to_lunch_type_match class.
                Lunch_Type_Match.P_lunch_id = current_option.P_lunch_id; ///< @brief Set the lunch_id of Lunch_Type_Match.
                Lunch_Type_Match.P_lunch_type_id = lunch_type.P_lunch_type_id; ///< @brief Set the lunch_type_id of Lunch_Type_Match.
                Lunch_Type_Match.P_lunch_match_id = SQL_Queries.UpdateOrWriteSingleLine(Lunch_Type_Match, current_user, true); ///< @brief Update or write a single line to the database.
            }
            catch (ErrorHandler err) ///< @brief Catch any ErrorHandler exceptions.
            {
                err.LogWrite("Errore Durante il Salvataggio"); ///< @brief Write the error log.
                return false;
            }
            return true;
        }

        /**
         * @brief This method is triggered when the save_lunch_data button is clicked.
         * It checks if all compulsory fields are populated and then inserts or updates the values.
         */
        private void save_lunch_data_Click(object sender, EventArgs e)
        {
            // Existing comment: will check if all compulsory fields are populated and then insert or update the values
            if (Common_Functions_WinfForm.CheckControlsByTag(this, Common_Functions_WinfForm.TagsList.compulsory)) ///< @brief Check if all compulsory fields are populated.
            {
                DialogResult result; ///< @brief result is the result of the message box.
                if (create_new.Checked) ///< @brief Check if the create_new checkbox is checked.
                {
                    result = MessageBox.Show($"Creare un nuovo piatto chiamato {lunch_name.Text}?", "Conferma", MessageBoxButtons.YesNo); ///< @brief Show a message box to ask the user if they want to create a new meal.
                }
                else
                {
                    result = MessageBox.Show($"Aggiornare il piatto {current_option.P_lunch_name} ? ", "Conferma", MessageBoxButtons.YesNo); ///< @brief Show a message box to ask the user if they want to update the meal.
                }
                try
                {
                    if (result == DialogResult.Yes) ///< @brief Check if the user confirmed the operation.
                    {
                        if (save_or_update_data(create_new.Checked)) ///< @brief Save or update the data.
                        {
                            Common_Functions_WinfForm.DisplayMessage($"Dati salvati per il piatto {lunch_name.Text}", "Salvato", ButtonTypesEnum.OkOnly); ///< @brief Display a message to confirm the successful save.
                            populate_lunch_view_list(); ///< @brief Populate the lunch view list.
                            reset_lunch_data(); ///< @brief Reset the lunch data.
                        }
                    }
                }
                catch (ErrorHandler err) ///< @brief Catch any ErrorHandler exceptions.
                {
                    err.LogWrite(); ///< @brief Write the error log.
                }
            }
        }



        /**
         * @brief This method is triggered when the selected item of lunch_name is changed.
         * It populates the current_option object from the UI and the database.
         */
        private void lunch_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_option = new lunch_option(); ///< @brief current_option is an instance of the lunch_option class.
            if (lunch_name.SelectedItem is not null) ///< @brief Check if an item is selected in lunch_name.
            {
                // Get the lunch_id of the selected item from the database.
                current_option.P_lunch_id = Convert.ToInt32(SQL_Queries.GetValues(Connection_Handler, current_option.P_MyTable, current_option.P_MyIdString, DistinctOrGeneral.Distinct, current_option.P_MyNameString, lunch_name.SelectedItem.ToString()).Rows[0][0]);
                if (int.TryParse(current_option.P_lunch_id.ToString(), out _)) ///< @brief Check if the lunch_id is an integer.
                {
                    current_option.PopulateSelf(Connection_Handler); ///< @brief Populate the properties of current_option.
                    Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(current_option, this, true); ///< @brief Populate the UI from the current_option object.
                }
                else
                {
                    current_option.P_lunch_id = 0; ///< @brief Reset the lunch_id of current_option.
                }
            }
        }

        /**
         * @brief This method is triggered when the selected item of lunch_type_desc is changed.
         * It populates the current_type object from the UI and the database.
         */
        private void lunch_type_desc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            current_type = new lunch_type(); ///< @brief current_type is an instance of the lunch_type class.
            if (lunch_type_desc.SelectedItem is not null) ///< @brief Check if an item is selected in lunch_type_desc.
            {
                // Get the lunch_type_id of the selected item from the database.
                current_type.P_lunch_type_id = Convert.ToInt32(SQL_Queries.GetValues(Connection_Handler, current_type.P_MyTable, current_type.P_MyIdString, DistinctOrGeneral.Distinct, current_type.P_MyNameString, lunch_type_desc.SelectedItem.ToString()).Rows[0][0]);
                if (int.TryParse(current_type.P_lunch_type_id.ToString(), out _)) ///< @brief Check if the lunch_type_id is an integer.
                {
                    current_type.PopulateSelf(Connection_Handler); ///< @brief Populate the properties of current_type.
                    Common_Functions_WinfForm.PopObjFromUIOrUIFromObj(current_type, this, true); ///< @brief Populate the UI from the current_type object.
                }
                else
                {
                    current_type.P_lunch_type_id = 0; ///< @brief Reset the lunch_type_id of current_type.
                }
            }
        }

        /**
         * @brief This method is triggered when the selected item of user_name is changed.
         * It loads the user purchases.
         */
        private void user_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_user_purchases(null); ///< @brief Load the user purchases.
        }

        /**
 * @brief This method loads the purchases of all users or those of a single one, either open or closed or both.
 * It fetches the values from the database, clears the ListView and the lists, and adds the fetched values to the ListView and the lists.
 * @param selected_user The selected user. If it is null, it will be created and its user_id will be fetched from the database.
 */
        private void load_user_purchases(User_Object selected_user)
        {
            // Existing comment: this will either load the purchases of all users or those of a single one, either open or closed or both

            System.Data.DataTable dt = new System.Data.DataTable(); ///< @brief dt is used to store the fetched data.
            user_purchase_obj user_Purchase_Obj = new user_purchase_obj(); ///< @brief user_Purchase_Obj is an instance of the user_purchase_obj class.
            lunch_option lunch_Option = new lunch_option(); ///< @brief lunch_Option is an instance of the lunch_option class.
            if (selected_user is null) ///< @brief Check if selected_user is null.
            {
                selected_user = new User_Object(); ///< @brief selected_user is an instance of the User_Object class.
                // Get the user_id of the selected item from the database.
                selected_user.P_user_id = Convert.ToInt32(SQL_Queries.GetValues(Connection_Handler, selected_user.P_MyTable, selected_user.P_MyIdString, DistinctOrGeneral.Distinct, selected_user.P_MyNameString, user_name.SelectedItem.ToString(), AndOR.ANDEnum, true).Rows[0][0]);
            }

            user_purchases.Items.Clear(); ///< @brief Clear all items of the user_purchases.
            user_purchase_obj_list.Clear(); ///< @brief Clear all items of the user_purchase_obj_list.
            list_of_purchased_items.Clear(); ///< @brief Clear all items of the list_of_purchased_items.

            if (selected_user.P_user_id == 0) ///< @brief Check if the user_id of selected_user is 0.
            {
                return;
            }
            else
            {
                selected_user.PopulateSelf(Connection_Handler); ///< @brief Populate the properties of selected_user.
            }
            if (include_closed.Checked) ///< @brief Check if the include_closed checkbox is checked.
            {
                // Get the values from the database.
                dt = SQL_Queries.GetValues(Connection_Handler, user_Purchase_Obj.P_MyTable, lunch_Option.P_MyIdString, DistinctOrGeneral.General, selected_user.P_MyIdString, selected_user.P_user_id.ToString());
            }
            else
            {
                // Get the values from the database.
                dt = SQL_Queries.GetValues(Connection_Handler, user_Purchase_Obj.P_MyTable, lunch_Option.P_MyIdString, DistinctOrGeneral.General, selected_user.P_MyIdString + "|" + "status", selected_user.P_user_id.ToString() + "|" + "0");
            }

            foreach (DataRow dataRow in dt.Rows) ///< @brief Iterate over the rows of the fetched data.
            {
                user_Purchase_Obj = new user_purchase_obj(); ///< @brief user_Purchase_Obj is an instance of the user_purchase_obj class.
                user_Purchase_Obj.P_user_purchase_id = Convert.ToInt16(dataRow[user_Purchase_Obj.P_MyIdString]); ///< @brief Set the user_purchase_id of user_Purchase_Obj.
                user_Purchase_Obj.PopulateSelf(Connection_Handler); ///< @brief Populate the properties of user_Purchase_Obj.
                if (TimeBetween(user_Purchase_Obj.P_date, start_date.Value.Date, end_date.Value.Date)) ///< @brief Check if the date of user_Purchase_Obj is between start_date and end_date.
                {
                    lunch_Option.P_lunch_id = Convert.ToInt32(dataRow[lunch_Option.P_MyIdString]); ///< @brief Set the lunch_id of lunch_Option.
                    lunch_Option.PopulateSelf(Connection_Handler); ///< @brief Populate the properties of lunch_Option.
                    lunch_Option.P_lunch_id = Convert.ToInt16(dataRow[lunch_Option.P_MyIdString]); ///< @brief Set the lunch_id of lunch_Option.
                    list_of_purchased_items.Add(lunch_Option); ///< @brief Add lunch_Option to the list_of_purchased_items.
                    ListViewItem item = new ListViewItem(new[] { user_Purchase_Obj.P_user_purchase_id.ToString(), lunch_Option.P_lunch_name, lunch_Option.P_lunch_price.ToString(), user_Purchase_Obj.P_date.ToString(), (user_Purchase_Obj.P_status == 0) ? "Aperto" : "Chiuso" }); ///< @brief item is a ListViewItem created for each user purchase.
                    user_purchases.Items.Add(item); ///< @brief Add item to the user_purchases.
                    user_purchase_obj_list.Add(user_Purchase_Obj); ///< @brief Add user_Purchase_Obj to the user_purchase_obj_list.
                }
            }
            user_open.Text = main_Form.get_sum_from_list(list_of_purchased_items).ToString() + " Ticket"; ///< @brief Update the total price in the user_open.
        }

        /**
 * @brief This method checks if a DateTime is between a start and end DateTime.
 * @param datetime The DateTime to check.
 * @param start The start DateTime.
 * @param end The end DateTime.
 * @return true if datetime is between start and end, false otherwise.
 */
        private bool TimeBetween(DateTime datetime, DateTime start, DateTime end)
        {
            bool result = start <= datetime && datetime <= end; ///< @brief result is true if datetime is between start and end, false otherwise.
            return result;
        }

        /**
         * @brief This method is triggered when the mark_paid button is clicked.
         * It shows a message box to ask the user if they want to mark all purchases of the selected user as paid.
         * If the user confirmed, it marks all purchases of the selected user in the current month as paid and updates the values in the database.
         */
        private void mark_paid_Click(object sender, EventArgs e)
        {
            // Show a message box to ask the user if they want to mark all purchases of the selected user as paid.
            DialogResult result = MessageBox.Show($"Stornare tutti gli acquisti dell'utente {user_name.SelectedItem} del periodo selezionato? ", "Conferma", MessageBoxButtons.YesNo);
            try
            {
                if (result == DialogResult.Yes) ///< @brief Check if the user confirmed the operation.
                {
                    foreach (user_purchase_obj purchase in user_purchase_obj_list) ///< @brief Iterate over the user_purchase_obj_list.
                    {
                        if (purchase.P_date.Month == DateTime.Now.Month) ///< @brief Check if the month of the purchase date is the current month.
                        {
                            purchase.P_changed_date = DateTime.Now;
                            purchase.P_status_changed_by = current_user.P_user_id;
                            purchase.P_status = 1; ///< @brief Mark the purchase as paid.
                            SQL_Queries.UpdateOrWriteSingleLine(purchase, current_user, false); ///< @brief Update or write a single line to the database.
                        }
                    }
                    user_name.Text = "";
                }
                load_user_purchases(null); ///< @brief Load the user purchases.
                // Show a message box to confirm the successful operation.
                MessageBox.Show($"Completato, ho stornato tutti gli acquisti dell'utente {user_name.SelectedItem} nel periodo selezionato ", "Completato!", MessageBoxButtons.OK);
            }
            catch (ErrorHandler err) ///< @brief Catch any ErrorHandler exceptions.
            {
                err.LogWrite(); ///< @brief Write the error log.
            }
        }

        /**
         * @brief This method is triggered when the button4 button is clicked.
         * It shows a SaveFileDialog to ask the user where to save the Excel file.
         * If the user confirmed, it gets the purchases, converts the list to an Excel file, and saves the file.
         */
        private void button4_Click(object sender, EventArgs e)
        {
            List<user_purchase_obj> user_purchase_obj_ = new List<user_purchase_obj>(); ///< @brief user_purchase_obj_ is a list of user purchase objects.
            SaveFileDialog saveDialog = new SaveFileDialog(); ///< @brief saveDialog is a SaveFileDialog.

            saveDialog.Filter = "Excel Files|*.xls"; ///< @brief Set the filter of saveDialog to Excel files.
            DialogResult result = saveDialog.ShowDialog(); ///< @brief Show the saveDialog and get the result.
            if (result == DialogResult.OK) ///< @brief Check if the user confirmed the operation.
            {
                user_purchase_obj_ = get_purchases(print_all.Checked); ///< @brief Get the purchases.
                if (user_purchase_obj_.Count >0)
                {
                    if (ListToExcel(user_purchase_obj_, saveDialog.FileName)) ///< @brief Convert the list to an Excel file and save the file.
                    {
                        // Show a message box to confirm the successful operation.
                        MessageBox.Show($"File {saveDialog.FileName} creato", "Completato!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        // Show a message box if there was an error.
                        MessageBox.Show($"File {saveDialog.FileName} non creato - consultare il log per ulteriori dettagli", "Errore", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show($"nessun dato da esportare - veririfcare la selezione e riprovare", "Errore", MessageBoxButtons.OK);
                }

            }
        }
        /**
 * @brief This method gets the purchases of all users or those of a single one.
 * It fetches the values from the database, and adds the fetched values to a list.
 * @param for_all_users A boolean indicating whether to get the purchases for all users.
 * @return A list of user purchase objects.
 */
        private List<user_purchase_obj> get_purchases(bool for_all_users)
        {
            List<user_purchase_obj> user_purchase_obj_ = new List<user_purchase_obj>(); ///< @brief user_purchase_obj_ is a list of user purchase objects.
            System.Data.DataTable dt = new System.Data.DataTable(); ///< @brief dt is used to store the fetched data.
            user_purchase_obj user_Purchase_Obj = new user_purchase_obj(); ///< @brief user_Purchase_Obj is an instance of the user_purchase_obj class.
            lunch_option lunch_Option = new lunch_option(); ///< @brief lunch_Option is an instance of the lunch_option class.
            if (for_all_users) ///< @brief Check if the purchases are to be gotten for all users.
            {
                // Get the values from the database.
                dt = SQL_Queries.GetValues(Connection_Handler, user_Purchase_Obj.P_MyTable, lunch_Option.P_MyIdString, DistinctOrGeneral.General);
                foreach (DataRow dataRow in dt.Rows) ///< @brief Iterate over the rows of the fetched data.
                {
                    user_purchase_obj user_Purchase = new user_purchase_obj(); ///< @brief user_Purchase is an instance of the user_purchase_obj class.
                    user_Purchase.P_user_purchase_id = Convert.ToInt32(dataRow[user_Purchase.P_MyIdString]); ///< @brief Set the user_purchase_id of user_Purchase.
                    user_Purchase.UpdateProperty(dataRow, user_Purchase, dt); ///< @brief Update the property of user_Purchase.
                    if (TimeBetween(user_Purchase.P_date, start_date.Value.Date, end_date.Value.Date)) ///< @brief Check if the date of user_Purchase is between start_date and end_date.
                    {
                        user_purchase_obj_.Add(user_Purchase); ///< @brief Add user_Purchase to the user_purchase_obj_.
                    }
                }
            }
            else
            {
                user_purchase_obj_ = user_purchase_obj_list; ///< @brief Set user_purchase_obj_ to user_purchase_obj_list.
            }
            return user_purchase_obj_;
        }

        /**
         * @brief This method converts a list to an Excel file and saves the file.
         * It creates a DataTable, populates the DataTable from the list, creates a DataSet, adds the DataTable to the DataSet, and saves the DataSet as an Excel file.
         * @param list The list to be converted to an Excel file.
         * @param filePath The path where to save the Excel file.
         * @return true if the operation is successful, false otherwise.
         */
        public bool ListToExcel(List<user_purchase_obj> list, string filePath)
        {
            try
            {
                DataTable dtTable = new DataTable(); ///< @brief dtTable is a DataTable.

                // Create columns.
                dtTable.Columns.Add(new DataColumn("ID Ordine", typeof(string)));
                dtTable.Columns.Add(new DataColumn("Utente", typeof(string)));
                dtTable.Columns.Add(new DataColumn("Data", typeof(string)));
                dtTable.Columns.Add(new DataColumn("Nome Piatto", typeof(string)));
                dtTable.Columns.Add(new DataColumn("Valore in Ticket", typeof(string)));
                dtTable.Columns.Add(new DataColumn("Stato", typeof(string)));
                dtTable.Columns.Add(new DataColumn("Stornato da", typeof(string)));
                dtTable.Columns.Add(new DataColumn("Data Storno", typeof(string)));

                // Populate data from list.
                for (int i = 0; i < list.Count; i++)
                {
                    user_purchase_obj user_purchase_obj = list[i]; ///< @brief user_purchase_obj is an instance of the user_purchase_obj class.
                    User_Object user = new User_Object(); ///< @brief user is an instance of the User_Object class.
                    lunch_option lunch_Option = new lunch_option(); ///< @brief lunch_Option is an instance of the lunch_option class.
                    user.P_user_id = user_purchase_obj.P_user_id; ///< @brief Set the user_id of user.
                    lunch_Option.P_lunch_id = user_purchase_obj.P_lunch_id; ///< @brief Set the lunch_id of lunch_Option.
                    lunch_Option.PopulateSelf(current_user.P_Conn_Handler); ///< @brief Populate the properties of lunch_Option.
                    user.PopulateSelf(current_user.P_Conn_Handler); ///< @brief Populate the properties of user.
                    // Populate rows.
                    DataRow dr = dtTable.NewRow();
                    dr[0] = user_purchase_obj.P_user_purchase_id;
                    dr[1] = user.P_user_name;
                    dr[2] = user_purchase_obj.P_date;
                    dr[3] = lunch_Option.P_lunch_name;
                    dr[4] = lunch_Option.P_lunch_price;
                    dr[5] = (user_purchase_obj.P_status == 0) ? "Aperto" : "Chiuso";
                    string username = SQL_Queries.MySQLReturnScalar($"SELECT {current_user.P_MyNameString} FROM {current_user.P_MyTable} WHERE {current_user.P_MyIdString} = {current_user.P_user_id}",current_user.P_Conn_Handler,ConnectionToGet.MySQlCommonConnection);
                    dr[6] = username;
                    dr[7] = user_purchase_obj.P_changed_date.ToString();
                    dtTable.Rows.Add(dr);
                }
                for (int i = 0; i < 100; i++)
                {
                    DataRow dr = dtTable.NewRow();
                    dr[0] = "";
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = "";
                    dr[4] = "";
                    dr[5] = "";
                    dr[6] = "";
                    dr[7] = "";
                    dtTable.Rows.Add(dr);
                }

                DataSet ds = new DataSet(); ///< @brief ds is a DataSet.
                ds.Tables.Add(dtTable); ///< @brief Add dtTable to the ds.

                // Save the workbook.
                ExcelLibrary.DataSetHelper.CreateWorkbook(filePath, ds);
                return true;
            }
            catch (ErrorHandler err) ///< @brief Catch any ErrorHandler exceptions.
            {
                err.LogWrite(); ///< @brief Write the error log.
                return false;
            }
        }

        /**
 * @brief This method is triggered when the button1 button is clicked.
 * It shows a message box to ask the user if they want to mark all purchases of all users as paid.
 * If the user confirmed, it marks all purchases of all users in the current month as paid and updates the values in the database.
 */
        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0; ///< @brief counter is the number of updated records.
            // Show a message box to ask the user if they want to mark all purchases of all users as paid.
            DialogResult result = MessageBox.Show($"Stornare tutti gli acquisti di tutti gli utenti per il periodo selezionato? ", "Conferma", MessageBoxButtons.YesNo);
            try
            {
                if (result == DialogResult.Yes) ///< @brief Check if the user confirmed the operation.
                {
                    List<user_purchase_obj> user_purchase_obj_ = new List<user_purchase_obj>(); ///< @brief user_purchase_obj_ is a list of user purchase objects.
                    user_purchase_obj_ = get_purchases(true); ///< @brief Get the purchases for all users.
                    foreach (user_purchase_obj purchase in user_purchase_obj_) ///< @brief Iterate over the user_purchase_obj_.
                    {
                        if (purchase.P_status == 0) ///< @brief Check if the purchase is open.
                        {
                            purchase.P_changed_date = DateTime.Now;
                            purchase.P_status_changed_by = current_user.P_user_id;
                            purchase.P_status = 1; ///< @brief Mark the purchase as paid.
                            SQL_Queries.UpdateOrWriteSingleLine(purchase, current_user, false); ///< @brief Update or write a single line to the database.
                            counter++; ///< @brief Increment the counter.
                        }
                    }
                }
                load_user_purchases(null); ///< @brief Load the user purchases.
                // Show a message box to confirm the successful operation.
                MessageBox.Show($"Completato, ho stornato tutti gli acquisti per tutti gli utenti nel periodo selezionato - aggiornati {counter} record ", "Completato!", MessageBoxButtons.OK);
            }
            catch (ErrorHandler err) ///< @brief Catch any ErrorHandler exceptions.
            {
                err.LogWrite(); ///< @brief Write the error log.
            }
        }

        /**
         * @brief This method is triggered when the button2 button is clicked.
         * It resets the lunch data.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            reset_lunch_data(); ///< @brief Reset the lunch data.
        }

        /**
         * @brief This method resets specific fields in the UI.
         */
        private void reset_lunch_data()
        {
            // Existing comment: reset specific fields in the UI
            lunch_desc.Text = ""; ///< @brief Reset the text of lunch_desc.
            lunch_type_desc.SelectedItem = null; ///< @brief Reset the selected item of lunch_type_desc.
            lunch_stock_qty.Text = ""; ///< @brief Reset the text of lunch_stock_qty.
            lunch_price.Text = ""; ///< @brief Reset the text of lunch_price.
            lunch_cost.Text = ""; ///< @brief Reset the text of lunch_cost.
            ddt.Text = ""; ///< @brief Reset the text of ddt.
            lunch_be_code.Text = ""; ///< @brief Reset the text of lunch_be_code.
            lunch_supplier_code.Text = ""; ///< @brief Reset the text of lunch_supplier_code.
            lunch_name.SelectedItem = null; ///< @brief Reset the selected item of lunch_name.
            lunch_name.Text = ""; ///< @brief Reset the text of lunch_name.
            current_option = new lunch_option(); ///< @brief current_option is a new instance of the lunch_option class.
        }

    }
}

