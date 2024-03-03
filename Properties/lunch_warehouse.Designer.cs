﻿namespace BELunchTool.Properties
{
    partial class lunch_warehouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lunch_warehouse));
            label1 = new Label();
            lunch_name = new ComboBox();
            lunch_type_desc = new ComboBox();
            label2 = new Label();
            user_name = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            mark_paid = new Button();
            user_purchases = new ListView();
            button4 = new Button();
            lunch_options_view = new ListView();
            label7 = new Label();
            lunch_stock_qty = new TextBox();
            lunch_price = new TextBox();
            save_lunch_data = new Button();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            lunch_cost = new TextBox();
            label11 = new Label();
            ddt = new TextBox();
            user_open = new Label();
            print_all = new CheckBox();
            pictureBox1 = new PictureBox();
            start_date = new DateTimePicker();
            end_date = new DateTimePicker();
            label14 = new Label();
            label15 = new Label();
            groupBox1 = new GroupBox();
            label16 = new Label();
            lunch_supplier_code = new TextBox();
            label17 = new Label();
            lunch_be_code = new TextBox();
            lunch_desc = new TextBox();
            label = new Label();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 15);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Lunch";
            // 
            // lunch_name
            // 
            lunch_name.FormattingEnabled = true;
            lunch_name.Location = new Point(71, 12);
            lunch_name.Name = "lunch_name";
            lunch_name.Size = new Size(255, 23);
            lunch_name.TabIndex = 2;
            lunch_name.Tag = "compulsory";
            lunch_name.SelectedIndexChanged += lunch_name_SelectedIndexChanged;
            // 
            // lunch_type_desc
            // 
            lunch_type_desc.FormattingEnabled = true;
            lunch_type_desc.Location = new Point(398, 12);
            lunch_type_desc.Name = "lunch_type_desc";
            lunch_type_desc.Size = new Size(275, 23);
            lunch_type_desc.TabIndex = 4;
            lunch_type_desc.Tag = "compulsory";
            lunch_type_desc.SelectedIndexChanged += lunch_type_desc_SelectedIndexChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 15);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "Type";
            // 
            // user_name
            // 
            user_name.FormattingEnabled = true;
            user_name.Location = new Point(71, 446);
            user_name.Name = "user_name";
            user_name.Size = new Size(355, 23);
            user_name.TabIndex = 8;
            user_name.SelectedIndexChanged += user_name_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 449);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 7;
            label3.Text = "User";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 731);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 10;
            label5.Text = "User Total";
            // 
            // mark_paid
            // 
            mark_paid.BackgroundImage = Resources.GreenButton_v2;
            mark_paid.BackgroundImageLayout = ImageLayout.Zoom;
            mark_paid.FlatAppearance.BorderSize = 0;
            mark_paid.FlatStyle = FlatStyle.Flat;
            mark_paid.Location = new Point(940, 720);
            mark_paid.Name = "mark_paid";
            mark_paid.Size = new Size(160, 37);
            mark_paid.TabIndex = 11;
            mark_paid.Text = "Close Monthly Bill";
            mark_paid.UseVisualStyleBackColor = true;
            mark_paid.Click += mark_paid_Click;
            // 
            // user_purchases
            // 
            user_purchases.FullRowSelect = true;
            user_purchases.Location = new Point(27, 475);
            user_purchases.MultiSelect = false;
            user_purchases.Name = "user_purchases";
            user_purchases.Size = new Size(1080, 242);
            user_purchases.TabIndex = 12;
            user_purchases.UseCompatibleStateImageBehavior = false;
            // 
            // button4
            // 
            button4.BackgroundImage = Resources.BlueButton_v2;
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(118, 196);
            button4.Name = "button4";
            button4.Size = new Size(160, 37);
            button4.TabIndex = 13;
            button4.Text = "Print Report";
            button4.UseVisualStyleBackColor = true;
            // 
            // lunch_options_view
            // 
            lunch_options_view.Location = new Point(306, 90);
            lunch_options_view.Name = "lunch_options_view";
            lunch_options_view.Size = new Size(1090, 312);
            lunch_options_view.TabIndex = 15;
            lunch_options_view.UseCompatibleStateImageBehavior = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(306, 72);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 17;
            label7.Text = "Lunches";
            // 
            // lunch_stock_qty
            // 
            lunch_stock_qty.Location = new Point(731, 14);
            lunch_stock_qty.Name = "lunch_stock_qty";
            lunch_stock_qty.Size = new Size(162, 23);
            lunch_stock_qty.TabIndex = 18;
            lunch_stock_qty.Tag = "compulsory";
            // 
            // lunch_price
            // 
            lunch_price.Location = new Point(731, 46);
            lunch_price.Name = "lunch_price";
            lunch_price.Size = new Size(162, 23);
            lunch_price.TabIndex = 19;
            lunch_price.Tag = "compulsory";
            // 
            // save_lunch_data
            // 
            save_lunch_data.BackgroundImage = Resources.GreenButton_v2;
            save_lunch_data.BackgroundImageLayout = ImageLayout.Zoom;
            save_lunch_data.FlatAppearance.BorderSize = 0;
            save_lunch_data.FlatStyle = FlatStyle.Flat;
            save_lunch_data.Location = new Point(1237, 408);
            save_lunch_data.Name = "save_lunch_data";
            save_lunch_data.Size = new Size(160, 37);
            save_lunch_data.TabIndex = 6;
            save_lunch_data.Text = "Save Changes";
            save_lunch_data.UseVisualStyleBackColor = true;
            save_lunch_data.Click += save_lunch_data_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(692, 17);
            label8.Name = "label8";
            label8.Size = new Size(26, 15);
            label8.TabIndex = 20;
            label8.Text = "Qty";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(692, 49);
            label9.Name = "label9";
            label9.Size = new Size(33, 15);
            label9.TabIndex = 21;
            label9.Text = "Price";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(941, 17);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 23;
            label10.Text = "Cost";
            // 
            // lunch_cost
            // 
            lunch_cost.Location = new Point(980, 13);
            lunch_cost.Name = "lunch_cost";
            lunch_cost.Size = new Size(163, 23);
            lunch_cost.TabIndex = 22;
            lunch_cost.Tag = "compulsory";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1195, 17);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 25;
            label11.Text = "DDT";
            // 
            // ddt
            // 
            ddt.Location = new Point(1246, 13);
            ddt.Name = "ddt";
            ddt.Size = new Size(151, 23);
            ddt.TabIndex = 24;
            // 
            // user_open
            // 
            user_open.AutoSize = true;
            user_open.Location = new Point(145, 731);
            user_open.Name = "user_open";
            user_open.Size = new Size(12, 15);
            user_open.TabIndex = 27;
            user_open.Text = "/";
            // 
            // print_all
            // 
            print_all.AutoSize = true;
            print_all.Location = new Point(14, 94);
            print_all.Name = "print_all";
            print_all.Size = new Size(155, 19);
            print_all.TabIndex = 28;
            print_all.Text = "Print Report for All Users";
            print_all.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Resources.BE_Logo_Single_Line_RGB_jpg;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(1313, 720);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 39);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // start_date
            // 
            start_date.Location = new Point(78, 33);
            start_date.Name = "start_date";
            start_date.Size = new Size(200, 23);
            start_date.TabIndex = 30;
            // 
            // end_date
            // 
            end_date.Location = new Point(78, 65);
            end_date.Name = "end_date";
            end_date.Size = new Size(200, 23);
            end_date.TabIndex = 31;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(14, 39);
            label14.Name = "label14";
            label14.Size = new Size(58, 15);
            label14.TabIndex = 32;
            label14.Text = "Start Date";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(14, 71);
            label15.Name = "label15";
            label15.Size = new Size(54, 15);
            label15.TabIndex = 33;
            label15.Text = "End Date";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(print_all);
            groupBox1.Controls.Add(start_date);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(end_date);
            groupBox1.Location = new Point(1112, 475);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 239);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reports";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(941, 49);
            label16.Name = "label16";
            label16.Size = new Size(35, 15);
            label16.TabIndex = 36;
            label16.Text = "Code";
            // 
            // lunch_supplier_code
            // 
            lunch_supplier_code.Location = new Point(980, 45);
            lunch_supplier_code.Name = "lunch_supplier_code";
            lunch_supplier_code.Size = new Size(163, 23);
            lunch_supplier_code.TabIndex = 35;
            lunch_supplier_code.Tag = "compulsory";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(1189, 49);
            label17.Name = "label17";
            label17.Size = new Size(51, 15);
            label17.TabIndex = 38;
            label17.Text = "BE Code";
            // 
            // lunch_be_code
            // 
            lunch_be_code.Location = new Point(1246, 45);
            lunch_be_code.Name = "lunch_be_code";
            lunch_be_code.Size = new Size(151, 23);
            lunch_be_code.TabIndex = 37;
            lunch_be_code.Tag = "compulsory";
            // 
            // lunch_desc
            // 
            lunch_desc.Location = new Point(27, 90);
            lunch_desc.MaxLength = 255;
            lunch_desc.Multiline = true;
            lunch_desc.Name = "lunch_desc";
            lunch_desc.Size = new Size(273, 312);
            lunch_desc.TabIndex = 39;
            lunch_desc.Tag = "compulsory";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(26, 72);
            label.Name = "label";
            label.Size = new Size(103, 15);
            label.TabIndex = 40;
            label.Text = "Lunch Description";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1120, 418);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(111, 19);
            checkBox1.TabIndex = 41;
            checkBox1.Text = "Update Selected";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // lunch_warehouse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1403, 761);
            Controls.Add(checkBox1);
            Controls.Add(label);
            Controls.Add(lunch_desc);
            Controls.Add(label17);
            Controls.Add(lunch_be_code);
            Controls.Add(label16);
            Controls.Add(lunch_supplier_code);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(user_open);
            Controls.Add(label11);
            Controls.Add(ddt);
            Controls.Add(label10);
            Controls.Add(lunch_cost);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(lunch_price);
            Controls.Add(lunch_stock_qty);
            Controls.Add(label7);
            Controls.Add(lunch_options_view);
            Controls.Add(user_purchases);
            Controls.Add(mark_paid);
            Controls.Add(label5);
            Controls.Add(user_name);
            Controls.Add(label3);
            Controls.Add(save_lunch_data);
            Controls.Add(lunch_type_desc);
            Controls.Add(label2);
            Controls.Add(lunch_name);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "lunch_warehouse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "lunch_warehouse";
            Load += lunch_warehouse_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ComboBox lunch_name;
        private ComboBox lunch_type_desc;
        private Label label2;
        private ComboBox user_name;
        private Label label3;
        private Label label5;
        private Button mark_paid;
        private ListView user_purchases;
        private Button button4;
        private ListView lunch_options_view;
        private Label label7;
        private TextBox lunch_stock_qty;
        private TextBox lunch_price;
        private Button save_lunch_data;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox lunch_cost;
        private Label label11;
        private TextBox ddt;
        private Label user_open;
        private CheckBox print_all;
        private PictureBox pictureBox1;
        private DateTimePicker start_date;
        private DateTimePicker end_date;
        private Label label14;
        private Label label15;
        private GroupBox groupBox1;
        private Label label16;
        private TextBox lunch_supplier_code;
        private Label label17;
        private TextBox lunch_be_code;
        private TextBox lunch_desc;
        private Label label;
        private CheckBox checkBox1;
    }
}