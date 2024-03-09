using BELunchTool.Classes;
using BELunchTool.Properties;
using BEToolsClassLibrary;
using Common_Classes_Namespace;
using Common_WinfForm;
using CommonWinForms.CommonForms;
using ConnectivityAndSQl_Namespace;
using System;
using System.Collections.Generic;
using System.Data;

namespace BELunchTool
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
            version.Text = Common_Functions_WinfForm.ReadRegValues(0);

        }

        List<lunch_option> list_of_lunches = new List<lunch_option>();
        List<lunch_option> list_of_selected_items = new List<lunch_option>();
        List<lunch_option> list_of_purchased_items = new List<lunch_option>();
        Connection_Handler Connection_Handler = new Connection_Handler();



        private void main_form_Load(object sender, EventArgs e)
        {
            InitLunchLists();
            PopulateLunchList(list_of_lunches, lunch_list);
        }

        private void InitLunchLists()
        {
            //initializes the columns for all the three lists in the form
            /**
           * @brief This method iterates over all controls in the current form.
           * If the control is a ListView, it clears its columns and adds new ones.
           * The last column of the 'purchases' ListView is set to "Data", which is an exception to the general rule.
           */
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ListView)
                {
                    ListView ListView_instance = ctrl as ListView; ///< @brief ListView_instance is the current ListView control.
                    ListView_instance.Columns.Clear(); ///< @brief Clear all columns of the ListView.
                    ListView_instance.View = View.Details; ///< @brief Set the ListView's view to Details.
                    // Add new columns to the ListView.
                    ListView_instance.Columns.Add("ID", 50, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Piatto", 550, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Quantita'", 100, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Prezzo (Ticket)", 100, HorizontalAlignment.Left);
                }
            }
            // Exception to the rule as only this column varies.
            purchases.Columns[2].Text = "Data"; ///< @brief Set the text of the third column of the 'purchases' ListView to "Data".
        }

        /**
         * @brief This method populates the list of available lunches.
         * It clears the lunch_list and list_of_lunches, then fetches the lunch options from the database.
         * Each row of the fetched data is used to create a lunch_option object, which is added to list_to_use.
         * Finally, it calls PopulateLunchListViews to populate the ListView with the lunch options.
         * @param list_to_use The list to which the lunch_option objects are added.
         * @param list_to_pop The ListView to be populated with the lunch options.
         * @return true if the operation is successful, false otherwise.
         */
        private bool PopulateLunchList(List<lunch_option> list_to_use, ListView list_to_pop)
        {
            DataTable dt = new DataTable(); ///< @brief dt is used to store the fetched data.
            lunch_option lunch_option_instance = new lunch_option(); ///< @brief lunch_option_instance is an instance of the lunch_option class.
            lunch_list.Items.Clear(); ///< @brief Clear all items of the lunch_list.
            list_of_lunches.Clear(); ///< @brief Clear all items of the list_of_lunches.
            try
            {
                // Fetch the values from the database.
                dt = SQL_Queries.GetValues(Connection_Handler, lunch_option_instance.P_MyTable, "", DistinctOrGeneral.General);
                foreach (DataRow dataRow in dt.Rows)
                {
                    lunch_option lunch_opt = new lunch_option(); ///< @brief lunch_opt is an instance of the lunch_option class.
                    lunch_opt.UpdateProperty(dataRow, lunch_opt, dt); ///< @brief Update the properties of lunch_opt using the current dataRow.
                    lunch_opt.P_lunch_id = Convert.ToInt16(dataRow[lunch_opt.P_MyIdString]); ///< @brief Set the lunch_id of lunch_opt.
                    list_to_use.Add(lunch_opt); ///< @brief Add lunch_opt to list_to_use.
                }
                PopulateLunchListViews(list_to_pop, list_to_use); ///< @brief Populate the ListView with the lunch options.
                return true;
            }
            catch (ErrorHandler error)
            {
                error.LogWrite(); ///< @brief Write the error log.
                return false;
            }
        }

        /**
         * @brief This method populates the ListView with the available lunches.
         * It iterates over the list_to_use and for each lunch_option, it creates a ListViewItem and adds it to the ListView.
         * @param list_to_pop The ListView to be populated with the lunch options.
         * @param list_to_use The list of lunch_option objects to be added to the ListView.
         * @return true if the operation is successful, false otherwise.
         */
        private bool PopulateLunchListViews(ListView list_to_pop, List<lunch_option> list_to_use)
        {
            try
            {
                // Populate the ListView with the available lunches.
                foreach (lunch_option lunch in list_to_use)
                {
                    ListViewItem item = new ListViewItem(new[] { lunch.P_lunch_id.ToString(), lunch.P_lunch_name + lunch.P_lunch_desc, lunch.P_lunch_stock_qty.ToString(), lunch.P_lunch_price.ToString() }); ///< @brief item is a ListViewItem created for each lunch_option.
                    list_to_pop.Items.Add(item); ///< @brief Add item to the ListView.
                }
                return true;
            }
            catch (ErrorHandler error)
            {
                error.LogWrite(); ///< @brief Write the error log.
                return true;
            }
        }


        /**
 * @brief This method is triggered when button1 is clicked.
 * It opens the login form and checks if the user is authorized and an admin.
 * If the user is authorized and an admin, it opens the lunch warehouse form.
 */
        private void button1_Click(object sender, EventArgs e)
        {
            // Existing comment: opens the quantity editing screen - required authentication before proceeding
            login_form login_Form = new login_form(this); ///< @brief login_Form is an instance of the login_form class.
            login_Form.ShowDialog(); ///< @brief Show the login form as a modal dialog box.
            try
            {
                // Check if the user is authorized and an admin.
                if (login_Form.autorized & login_Form.P_User_Object.P_is_admin == 1)
                {
                    lunch_warehouse lunch_Warehouse = new lunch_warehouse(); ///< @brief lunch_Warehouse is an instance of the lunch_warehouse class.
                    lunch_Warehouse.current_user = login_Form.P_User_Object; ///< @brief Set the current user of the lunch warehouse form.
                    lunch_Warehouse.Show(); ///< @brief Show the lunch warehouse form.
                }
                else
                {
                    // Show a message box if the user is not authorized.
                    MessageBox.Show($"Utente non Autorizzato", "Impossibile Procedere", MessageBoxButtons.YesNo);
                }
            }
            catch (ErrorHandler error) ///< @brief Catch any ErrorHandler exceptions.
            {
                error.LogWrite(); ///< @brief Write the error log.
            }
        }

        /**
         * @brief This method is triggered when the add button is clicked.
         * If a meal is selected in the lunch list and it's not already in the basket, it adds the meal to the basket and updates the total price.
         */
        private void add_Click(object sender, EventArgs e)
        {
            // Existing comment: when the user clicks it, if there is a meal selected, it will be added to the basket and the total price updated, as well as the list
            if (lunch_list.SelectedItems.Count > 0) ///< @brief Check if a meal is selected in the lunch list.
            {
                if (!basket.Items.Contains(lunch_list.SelectedItems[0])) ///< @brief Check if the selected meal is not already in the basket.
                {
                    var item = lunch_list.SelectedItems[0]; ///< @brief item is the selected meal.

                    lunch_option selected_meal = new lunch_option(); ///< @brief selected_meal is an instance of the lunch_option class.
                    selected_meal = Common_Functions_WinfForm.ReturnObjFromListByName(list_of_lunches, selected_meal.P_MyIdString, lunch_list.SelectedItems[0].SubItems[0].Text); ///< @brief Get the selected meal from the list of lunches.
                    int meals_in_basket = list_of_selected_items.Count(list_item => list_item.P_lunch_id == selected_meal.P_lunch_id); ///< @brief Get the number of the selected meals in the basket.
                    // Check if the selected meal is available and not already in the basket.
                    if (selected_meal.P_lunch_stock_qty > 0 & (selected_meal.P_lunch_stock_qty - meals_in_basket) > 0)
                    {
                        list_of_selected_items.Add(selected_meal); ///< @brief Add the selected meal to the list of selected items.
                        basket_total.Text = get_sum_from_list(list_of_selected_items).ToString() + " Ticket"; ///< @brief Update the total price in the basket.
                        basket.Items.Add((ListViewItem)item.Clone()); ///< @brief Add the selected meal to the basket.
                    }
                    else
                    {
                        // Show a message box if the selected meal is not available.
                        MessageBox.Show($"Il piatto {lunch_list.SelectedItems[0].SubItems[1].Text} non e' disponibile", "Impossibile Procedere", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /**
         * @brief This method calculates the total price of the selected items.
         * @param list_of_items The list of selected items.
         * @return The total price of the selected items.
         */
        public float get_sum_from_list(List<lunch_option> list_of_items)
        {
            float sum_from_list = 0; ///< @brief sum_from_list is the total price of the selected items.
            // Existing comment: sums the total of the selected items
            foreach (lunch_option lunch in list_of_items) ///< @brief Iterate over the list of selected items.
            {
                sum_from_list = sum_from_list + lunch.P_lunch_price; ///< @brief Add the price of the current lunch to the total price.
            }
            return sum_from_list; ///< @brief Return the total price.
        }

        /**
         * @brief This method is triggered when the remove button is clicked.
         * If an item is selected in the basket, it removes the item from the basket and the list of selected items, and updates the total price.
         */
        private void remove_Click(object sender, EventArgs e)
        {
            // Existing comment: when clicked will remove the itema from the basket and the current list, also updating the cost
            if (basket.SelectedItems.Count > 0) ///< @brief Check if an item is selected in the basket.
            {
                lunch_option selected_meal = new lunch_option(); ///< @brief selected_meal is an instance of the lunch_option class.
                selected_meal = Common_Functions_WinfForm.ReturnObjFromListByName(list_of_lunches, selected_meal.P_MyIdString, basket.SelectedItems[0].SubItems[0].Text); ///< @brief Get the selected meal from the list of lunches.
                basket.Items.Remove(basket.SelectedItems[0]); ///< @brief Remove the selected item from the basket.
                list_of_selected_items.Remove(selected_meal); ///< @brief Remove the selected meal from the list of selected items.
                basket_total.Text = get_sum_from_list(list_of_selected_items).ToString() + " Ticket"; ///< @brief Update the total price in the basket.
            }
        }


        /**
         * @brief This method is triggered when the add_to_basket button is clicked.
         * It checks out what you purchased, populates the correct object and then writes to DB after user confirmation.
         */
        private void add_to_basket_Click(object sender, EventArgs e)
        {
            // Existing comment: the add to basket actually checks out what you purchased - it will populate the correct object and then write to DB after user confirmation
            DialogResult result = MessageBox.Show($"Procedere all'ordine di {list_of_selected_items.Count()} piatti?", "Conferma Ordine", MessageBoxButtons.YesNo); ///< @brief Show a message box to confirm the order.

            if (result == DialogResult.Yes) ///< @brief Check if the user confirmed the order.
            {
                login_form login_Form = new login_form(this); ///< @brief login_Form is an instance of the login_form class.
                login_Form.ShowDialog(); ///< @brief Show the login form as a modal dialog box.
                if (login_Form.autorized) ///< @brief Check if the user is authorized.
                {
                    try
                    {
                        User_Object current_user = login_Form.P_User_Object; ///< @brief current_user is the current user.
                        foreach (lunch_option lunch in list_of_selected_items) ///< @brief Iterate over the list of selected items.
                        {
                            user_purchase_obj user_Purchase_Obj = new user_purchase_obj(); ///< @brief user_Purchase_Obj is an instance of the user_purchase_obj class.
                            user_Purchase_Obj.P_user_id = current_user.P_user_id; ///< @brief Set the user_id of user_Purchase_Obj.
                            user_Purchase_Obj.P_lunch_id = lunch.P_lunch_id; ///< @brief Set the lunch_id of user_Purchase_Obj.
                            user_Purchase_Obj.P_date = DateTime.Now; ///< @brief Set the date of user_Purchase_Obj to the current date.
                            user_Purchase_Obj.P_status = 0; ///< @brief Set the status of user_Purchase_Obj to 0.
                            SQL_Queries.UpdateOrWriteSingleLine(user_Purchase_Obj, current_user, false); ///< @brief Update or write a single line to the database.
                            // Existing comment: when an item is purchased, its quantity is reduced by 1
                            lunch.P_lunch_stock_qty = lunch.P_lunch_stock_qty - 1; ///< @brief Reduce the stock quantity of the lunch by 1.
                            SQL_Queries.UpdateOrWriteSingleLine(lunch, current_user, false); ///< @brief Update or write a single line to the database.
                        }

                        PopulateLunchList(list_of_lunches, lunch_list); ///< @brief Update the list of available lunches.
                        MessageBox.Show("Acquisto effettuato con successo!", "Buon Pranzo!", MessageBoxButtons.OK); ///< @brief Show a message box to confirm the successful purchase.
                    }
                    catch (ErrorHandler err) ///< @brief Catch any ErrorHandler exceptions.
                    {
                        err.LogWrite("Errore duarante acquisto"); ///< @brief Write the error log.
                    }
                }
                else
                {
                    // Show a message box if there was an error during login.
                    MessageBox.Show("Errore durante login, riprovare", "Error login", MessageBoxButtons.OK);
                }
            }
            else
            {
                // The user did not confirm the order.
            }
        }


        /**
  * @brief This method is triggered when the see_history button is clicked.
  * It allows the user to see their pending items for this month.
  */
        private void see_history_Click(object sender, EventArgs e)
        {
            // Existing comment: allows the user to see their pending items for this month
            DialogResult result = MessageBox.Show("Vuoi vedere gli ordini da saldare?", "Vedere Ordini?", MessageBoxButtons.YesNo); ///< @brief Show a message box to ask the user if they want to see their orders.

            if (result == DialogResult.Yes) ///< @brief Check if the user wants to see their orders.
            {
                login_form login_Form = new login_form(this); ///< @brief login_Form is an instance of the login_form class.
                login_Form.ShowDialog(); ///< @brief Show the login form as a modal dialog box.
                if (login_Form.autorized) ///< @brief Check if the user is authorized.
                {
                    purchases.Items.Clear(); ///< @brief Clear all items of the purchases.
                    // Adding columns.

                    DataTable dt = new DataTable(); ///< @brief dt is used to store the fetched data.
                    user_purchase_obj user_Purchase_Obj = new user_purchase_obj(); ///< @brief user_Purchase_Obj is an instance of the user_purchase_obj class.
                    lunch_option lunch_Option = new lunch_option(); ///< @brief lunch_Option is an instance of the lunch_option class.
                    // Existing comment: getting all the user open purchases
                    dt = SQL_Queries.GetValues(Connection_Handler, user_Purchase_Obj.P_MyTable, lunch_Option.P_MyIdString, DistinctOrGeneral.General, login_Form.P_User_Object.P_MyIdString + "|" + "status", login_Form.P_User_Object.P_user_id.ToString() + "|" + "0"); ///< @brief Fetch the values from the database.
                    foreach (DataRow dataRow in dt.Rows) ///< @brief Iterate over the rows of the fetched data.
                    {
                        // Existing comment: populating objects
                        user_Purchase_Obj.P_user_purchase_id = Convert.ToInt32(dataRow[0]); ///< @brief Set the user_purchase_id of user_Purchase_Obj.
                        user_Purchase_Obj.PopulateSelf(Connection_Handler); ///< @brief Populate the properties of user_Purchase_Obj.
                        lunch_Option.P_lunch_id = Convert.ToInt32(dataRow[lunch_Option.P_MyIdString]); ///< @brief Set the lunch_id of lunch_Option.
                        lunch_Option.PopulateSelf(Connection_Handler); ///< @brief Populate the properties of lunch_Option.

                        // Existing comment: doing it directly instead of writing a dedicated function
                        ListViewItem item = new ListViewItem(new[] { user_Purchase_Obj.P_user_purchase_id.ToString(), lunch_Option.P_lunch_name, user_Purchase_Obj.P_date.ToShortDateString(), lunch_Option.P_lunch_price.ToString() }); ///< @brief item is a ListViewItem created for each user purchase.
                        purchases.Items.Add(item); ///< @brief Add item to the purchases.

                        list_of_purchased_items.Add(lunch_Option); ///< @brief Add lunch_Option to the list of purchased items.
                    }
                    // Existing comment: resizing columns and updating total price
                    purchases.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); ///< @brief Resize the columns of the purchases.
                    purchases_total.Text = get_sum_from_list(list_of_purchased_items).ToString() + " Ticket"; ///< @brief Update the total price in the purchases.
                }
            }
        }

        /**
         * @brief This method is triggered when the clear_basket button is clicked.
         * It clears the items in the basket, the list of selected items, and the total price.
         */
        private void clear_basket_Click(object sender, EventArgs e)
        {
            basket.Items.Clear(); ///< @brief Clear all items of the basket.
            list_of_selected_items.Clear(); ///< @brief Clear all items of the list of selected items.
            basket_total.Text = "/"; ///< @brief Reset the total price in the basket.
        }

        /**
         * @brief This method is triggered when the clear_history button is clicked.
         * It clears the items in the purchases, the list of purchased items, and the total price.
         */
        private void clear_history_Click(object sender, EventArgs e)
        {
            purchases.Items.Clear(); ///< @brief Clear all items of the purchases.
            list_of_purchased_items.Clear(); ///< @brief Clear all items of the list of purchased items.
            purchases_total.Text = "/"; ///< @brief Reset the total price in the purchases.
        }

    }
}
