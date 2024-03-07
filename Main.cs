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
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ListView)
                {
                    
                    ListView ListView_instance = ctrl as ListView;
                    ListView_instance.Columns.Clear();
                    ListView_instance.View = View.Details;
                    ListView_instance.Columns.Add("ID", 50, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Piatto", 550, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Quantita'", 100, HorizontalAlignment.Left);
                    ListView_instance.Columns.Add("Prezzo (Ticket)", 100, HorizontalAlignment.Left);
                }
            }
            //exception tot he rule 
            purchases.Columns[2].Text = "Data";


        }

        private bool PopulateLunchList(List<lunch_option> list_to_use, ListView list_to_pop)
        { //populates the list of available lunches
            DataTable dt = new DataTable();
            lunch_option lunch_option_instance = new lunch_option();
            lunch_list.Items.Clear();
            list_of_lunches.Clear();
            try
            {
                dt = SQL_Queries.GetValues(Connection_Handler, lunch_option_instance.P_MyTable, "", DistinctOrGeneral.General);
                foreach (DataRow dataRow in dt.Rows)
                {
                    lunch_option lunch_opt = new lunch_option();
                    lunch_opt.UpdateProperty(dataRow, lunch_opt, dt);
                    lunch_opt.P_lunch_id = Convert.ToInt16(dataRow[lunch_opt.P_MyIdString]);
                    list_to_use.Add(lunch_opt);
                }
                PopulateLunchListViews(list_to_pop, list_to_use);
                return true;
            }
            catch (ErrorHandler error)
            {
                error.LogWrite();
                return false;
            }
        }

        private bool PopulateLunchListViews(ListView list_to_pop, List<lunch_option> list_to_use)
        {
            try
            {
                //populates the list of available lunches with the name, price and available quantity
                foreach (lunch_option lunch in list_to_use)
                {
                    ListViewItem item = new ListViewItem(new[] { lunch.P_lunch_id.ToString(), lunch.P_lunch_name + lunch.P_lunch_desc, lunch.P_lunch_stock_qty.ToString(), lunch.P_lunch_price.ToString() });
                    list_to_pop.Items.Add(item);
                }
                return true;

            }
            catch (ErrorHandler error)
            {
                error.LogWrite();
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //opens the quantity editing screen - required authentication before proceeding
            login_form login_Form = new login_form(this);
            login_Form.ShowDialog();
            if (login_Form.autorized)
            {
                lunch_warehouse lunch_Warehouse = new lunch_warehouse();
                lunch_Warehouse.current_user = login_Form.P_User_Object;
                lunch_Warehouse.Show();
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        { //when the user clicks it, if there is a meal selected, it will be added to the basket and the total price updated, as well as the list
            if (lunch_list.SelectedItems.Count > 0)
            {
                if (!basket.Items.Contains(lunch_list.SelectedItems[0]))
                {
                    var item = lunch_list.SelectedItems[0];
                    basket.Items.Add((ListViewItem)item.Clone());
                    lunch_option selected_meal = new lunch_option();
                    selected_meal = Common_Functions_WinfForm.ReturnObjFromListByName(list_of_lunches, selected_meal.P_MyIdString, lunch_list.SelectedItems[0].SubItems[0].Text);
                    if(selected_meal.P_lunch_stock_qty != 0)
                    {
                        list_of_selected_items.Add(selected_meal);
                        basket_total.Text = get_sum_from_list(list_of_selected_items).ToString() + " Euro";
                    }
                    else
                    {
                        MessageBox.Show($"Il piatto {lunch_list.SelectedItems[0]} non e' disponibile", "Impossibile Procedere", MessageBoxButtons.YesNo);
                    }

                }
            }
        }

        public float get_sum_from_list(List<lunch_option> list_of_items)
        {
            float sum_from_list = 0;
            //sums the total of the selected items
            foreach (lunch_option lunch in list_of_items)
            {
                sum_from_list = sum_from_list + lunch.P_lunch_price;
            }
            return sum_from_list;

        }

        private void remove_Click(object sender, EventArgs e)
        { //when clicked will remove the itema from the basket and the current list, also updating the cost
            if (basket.SelectedItems.Count > 0)
            {
                lunch_option selected_meal = new lunch_option();
                selected_meal = Common_Functions_WinfForm.ReturnObjFromListByName(list_of_lunches, selected_meal.P_MyIdString, basket.SelectedItems[0].SubItems[0].Text);
                basket.Items.Remove(basket.SelectedItems[0]);
                list_of_selected_items.Remove(selected_meal);
                basket_total.Text = get_sum_from_list(list_of_selected_items).ToString() + " Euro";
            }

        }

        private void lunch_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void add_to_basket_Click(object sender, EventArgs e)
        {
            //the add to basket actuall checks out what you purchased - it will populate the correct object and then write to DB after user confirmatinon
            DialogResult result = MessageBox.Show($"Procedere all'ordine di {list_of_selected_items.Count()} piatti?", "Conferma Ordine", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                login_form login_Form = new login_form(this);
                login_Form.ShowDialog();
                if (login_Form.autorized)
                {
                    try
                    {
                        User_Object current_user = login_Form.P_User_Object;
                        foreach (lunch_option lunch in list_of_selected_items)
                        {
                            user_purchase_obj user_Purchase_Obj = new user_purchase_obj();
                            user_Purchase_Obj.P_user_id = current_user.P_user_id;
                            user_Purchase_Obj.P_lunch_id = lunch.P_lunch_id;
                            user_Purchase_Obj.P_date = DateTime.Now;
                            user_Purchase_Obj.P_status = 0;
                            SQL_Queries.UpdateOrWriteSingleLine(user_Purchase_Obj, current_user, false );
                            //when an item is purchsed, its quntity is reduced by 1
                            lunch.P_lunch_stock_qty = lunch.P_lunch_stock_qty - 1;
                            SQL_Queries.UpdateOrWriteSingleLine(lunch, current_user, false);


                        }

                        PopulateLunchList(list_of_lunches, lunch_list); //when done, updates the list of available lunches
                        MessageBox.Show("Acquisto effettuato con successo!", "Buon Pranzo!", MessageBoxButtons.OK);
                    }
                    catch (ErrorHandler err)
                    {
                        err.LogWrite("Errore duarante acquisto");
                    }
                }
                else
                {
                    MessageBox.Show("Errore durante login, riprovare", "Error login", MessageBoxButtons.OK);
                }

            }
            else
            {

            }
        }

        private void see_history_Click(object sender, EventArgs e)
        {
            //allows the user to see their pending items for this month
            DialogResult result = MessageBox.Show("Vuoi vedere gli ordini da saldare?", "Vedere Ordini?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                login_form login_Form = new login_form(this);
                login_Form.ShowDialog();
                if (login_Form.autorized)
                {
                    purchases.Items.Clear();
                    //adding columns
                   
                    DataTable dt = new DataTable();
                    user_purchase_obj user_Purchase_Obj = new user_purchase_obj();
                    lunch_option lunch_Option = new lunch_option();
                    //getting all the user open purchses
                    dt = SQL_Queries.GetValues(Connection_Handler, user_Purchase_Obj.P_MyTable, lunch_Option.P_MyIdString, DistinctOrGeneral.General, login_Form.P_User_Object.P_MyIdString + "|" + "status", login_Form.P_User_Object.P_user_id.ToString() + "|" + "0");
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        //populating objects
                        user_Purchase_Obj.P_lunch_id = Convert.ToInt32(dataRow[user_Purchase_Obj.P_MyIdString]);
                        user_Purchase_Obj.PopulateSelf(Connection_Handler);
                        lunch_Option.P_lunch_id = Convert.ToInt32(dataRow[lunch_Option.P_MyIdString]);
                        lunch_Option.PopulateSelf(Connection_Handler);

                        //doign it directly instad of writing a dedicated function
                        ListViewItem item = new ListViewItem(new[] { user_Purchase_Obj.P_user_purchase_id.ToString(), lunch_Option.P_lunch_name ,user_Purchase_Obj.P_date.ToShortDateString(), lunch_Option.P_lunch_price.ToString() });
                        purchases.Items.Add(item);
                        
                        list_of_purchased_items.Add(lunch_Option);
                    }
                    //resizing columns and updating total price
                    purchases.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    purchases_total.Text = get_sum_from_list(list_of_purchased_items).ToString() + " Ticket";

                }
            }
        }
    }
}