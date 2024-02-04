namespace BELunchTool
{
    partial class main_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            first_courses = new Button();
            second_courses = new Button();
            desserts = new Button();
            drinks = new Button();
            show_all = new Button();
            add = new Button();
            remove = new Button();
            add_to_basket = new Button();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            see_history = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lunch_list = new ListView();
            basket = new ListView();
            purchases = new ListView();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(146, 28);
            label1.Name = "label1";
            label1.Size = new Size(78, 37);
            label1.TabIndex = 1;
            label1.Text = "Piatti";
            // 
            // first_courses
            // 
            first_courses.BackgroundImage = Properties.Resources.spaghetti;
            first_courses.BackgroundImageLayout = ImageLayout.Zoom;
            first_courses.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            first_courses.Location = new Point(12, 271);
            first_courses.Name = "first_courses";
            first_courses.Size = new Size(128, 128);
            first_courses.TabIndex = 2;
            first_courses.UseVisualStyleBackColor = true;
            // 
            // second_courses
            // 
            second_courses.BackgroundImage = Properties.Resources.meat;
            second_courses.BackgroundImageLayout = ImageLayout.Zoom;
            second_courses.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            second_courses.Location = new Point(12, 405);
            second_courses.Name = "second_courses";
            second_courses.Size = new Size(128, 128);
            second_courses.TabIndex = 7;
            second_courses.UseVisualStyleBackColor = true;
            // 
            // desserts
            // 
            desserts.BackgroundImage = Properties.Resources.dessert;
            desserts.BackgroundImageLayout = ImageLayout.Zoom;
            desserts.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            desserts.Location = new Point(12, 539);
            desserts.Name = "desserts";
            desserts.Size = new Size(128, 128);
            desserts.TabIndex = 8;
            desserts.UseVisualStyleBackColor = true;
            // 
            // drinks
            // 
            drinks.BackgroundImage = Properties.Resources.drink;
            drinks.BackgroundImageLayout = ImageLayout.Zoom;
            drinks.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            drinks.Location = new Point(12, 673);
            drinks.Name = "drinks";
            drinks.Size = new Size(128, 128);
            drinks.TabIndex = 9;
            drinks.UseVisualStyleBackColor = true;
            // 
            // show_all
            // 
            show_all.BackColor = Color.LightCyan;
            show_all.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            show_all.Location = new Point(12, 68);
            show_all.Name = "show_all";
            show_all.Size = new Size(128, 128);
            show_all.TabIndex = 10;
            show_all.Text = "Mostra Tutto";
            show_all.UseVisualStyleBackColor = false;
            // 
            // add
            // 
            add.BackgroundImage = Properties.Resources.arrow_right;
            add.BackgroundImageLayout = ImageLayout.Zoom;
            add.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            add.Location = new Point(952, 68);
            add.Name = "add";
            add.Size = new Size(128, 128);
            add.TabIndex = 12;
            add.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            remove.BackgroundImage = Properties.Resources.arrow_left;
            remove.BackgroundImageLayout = ImageLayout.Zoom;
            remove.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            remove.Location = new Point(952, 349);
            remove.Name = "remove";
            remove.Size = new Size(128, 128);
            remove.TabIndex = 13;
            remove.UseVisualStyleBackColor = true;
            // 
            // add_to_basket
            // 
            add_to_basket.BackgroundImage = Properties.Resources.add_to_basket;
            add_to_basket.BackgroundImageLayout = ImageLayout.Zoom;
            add_to_basket.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            add_to_basket.Location = new Point(1764, 483);
            add_to_basket.Name = "add_to_basket";
            add_to_basket.Size = new Size(128, 128);
            add_to_basket.TabIndex = 14;
            add_to_basket.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(1092, 9);
            label4.Name = "label4";
            label4.Size = new Size(110, 37);
            label4.TabIndex = 15;
            label4.Text = "Carrello";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1092, 483);
            label2.Name = "label2";
            label2.Size = new Size(94, 37);
            label2.TabIndex = 16;
            label2.Text = "Totale:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1180, 483);
            label3.Name = "label3";
            label3.Size = new Size(94, 37);
            label3.TabIndex = 17;
            label3.Text = "Totale:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(1092, 574);
            label5.Name = "label5";
            label5.Size = new Size(284, 37);
            label5.TabIndex = 19;
            label5.Text = "Vedi Acquisti del Mese";
            // 
            // see_history
            // 
            see_history.BackgroundImage = Properties.Resources.JobReport;
            see_history.BackgroundImageLayout = ImageLayout.Zoom;
            see_history.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            see_history.Location = new Point(1764, 902);
            see_history.Name = "see_history";
            see_history.Size = new Size(128, 128);
            see_history.TabIndex = 20;
            see_history.Text = "Accedi";
            see_history.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(1180, 899);
            label6.Name = "label6";
            label6.Size = new Size(94, 37);
            label6.TabIndex = 22;
            label6.Text = "Totale:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(1092, 899);
            label7.Name = "label7";
            label7.Size = new Size(94, 37);
            label7.TabIndex = 21;
            label7.Text = "Totale:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(39, 231);
            label8.Name = "label8";
            label8.Size = new Size(76, 37);
            label8.TabIndex = 23;
            label8.Text = "Filtra";
            // 
            // lunch_list
            // 
            lunch_list.Location = new Point(146, 68);
            lunch_list.Name = "lunch_list";
            lunch_list.Size = new Size(800, 961);
            lunch_list.TabIndex = 24;
            lunch_list.UseCompatibleStateImageBehavior = false;
            // 
            // basket
            // 
            basket.Location = new Point(1092, 69);
            basket.Name = "basket";
            basket.Size = new Size(800, 408);
            basket.TabIndex = 25;
            basket.UseCompatibleStateImageBehavior = false;
            // 
            // purchases
            // 
            purchases.Location = new Point(1092, 617);
            purchases.Name = "purchases";
            purchases.Size = new Size(800, 274);
            purchases.TabIndex = 26;
            purchases.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.note_s;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(952, 902);
            button1.Name = "button1";
            button1.Size = new Size(128, 128);
            button1.TabIndex = 27;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // main_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(purchases);
            Controls.Add(basket);
            Controls.Add(lunch_list);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(see_history);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(add_to_basket);
            Controls.Add(remove);
            Controls.Add(add);
            Controls.Add(show_all);
            Controls.Add(drinks);
            Controls.Add(desserts);
            Controls.Add(second_courses);
            Controls.Add(first_courses);
            Controls.Add(label1);
            Name = "main_form";
            Text = "Form1";
            Load += main_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button first_courses;
        private Button second_courses;
        private Button desserts;
        private Button drinks;
        private Button show_all;
        private Button add;
        private Button remove;
        private Button add_to_basket;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label5;
        private Button see_history;
        private Label label6;
        private Label label7;
        private Label label8;
        private ListView lunch_list;
        private ListView basket;
        private ListView purchases;
        private Button button1;
    }
}