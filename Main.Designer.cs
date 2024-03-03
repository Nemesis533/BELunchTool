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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            label1 = new Label();
            add = new Button();
            remove = new Button();
            add_to_basket = new Button();
            label4 = new Label();
            label2 = new Label();
            basket_total = new Label();
            label5 = new Label();
            see_history = new Button();
            purchases_total = new Label();
            label7 = new Label();
            lunch_list = new ListView();
            basket = new ListView();
            purchases = new ListView();
            button1 = new Button();
            label9 = new Label();
            version = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(78, 37);
            label1.TabIndex = 1;
            label1.Text = "Piatti";
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
            add.Click += add_Click;
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
            remove.Click += remove_Click;
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
            add_to_basket.Click += add_to_basket_Click;
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
            // basket_total
            // 
            basket_total.AutoSize = true;
            basket_total.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            basket_total.Location = new Point(1278, 483);
            basket_total.Name = "basket_total";
            basket_total.Size = new Size(28, 37);
            basket_total.TabIndex = 17;
            basket_total.Text = "/";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(1092, 574);
            label5.Name = "label5";
            label5.Size = new Size(170, 37);
            label5.TabIndex = 19;
            label5.Text = "Ordini Aperti";
            // 
            // see_history
            // 
            see_history.BackgroundImage = Properties.Resources.LoginIcon1;
            see_history.BackgroundImageLayout = ImageLayout.Zoom;
            see_history.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            see_history.Location = new Point(1764, 902);
            see_history.Name = "see_history";
            see_history.Size = new Size(128, 128);
            see_history.TabIndex = 20;
            see_history.Text = "Accedi";
            see_history.UseVisualStyleBackColor = true;
            see_history.Click += see_history_Click;
            // 
            // purchases_total
            // 
            purchases_total.AutoSize = true;
            purchases_total.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            purchases_total.Location = new Point(1278, 899);
            purchases_total.Name = "purchases_total";
            purchases_total.Size = new Size(28, 37);
            purchases_total.TabIndex = 22;
            purchases_total.Text = "/";
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
            // lunch_list
            // 
            lunch_list.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lunch_list.FullRowSelect = true;
            lunch_list.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lunch_list.Location = new Point(12, 68);
            lunch_list.MultiSelect = false;
            lunch_list.Name = "lunch_list";
            lunch_list.Size = new Size(934, 928);
            lunch_list.TabIndex = 24;
            lunch_list.UseCompatibleStateImageBehavior = false;
            lunch_list.SelectedIndexChanged += lunch_list_SelectedIndexChanged;
            // 
            // basket
            // 
            basket.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            basket.FullRowSelect = true;
            basket.Location = new Point(1092, 69);
            basket.MultiSelect = false;
            basket.Name = "basket";
            basket.Size = new Size(800, 408);
            basket.TabIndex = 25;
            basket.UseCompatibleStateImageBehavior = false;
            // 
            // purchases
            // 
            purchases.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            purchases.FullRowSelect = true;
            purchases.Location = new Point(1092, 617);
            purchases.MultiSelect = false;
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
            button1.Location = new Point(952, 868);
            button1.Name = "button1";
            button1.Size = new Size(128, 128);
            button1.TabIndex = 27;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(12, 1017);
            label9.Name = "label9";
            label9.Size = new Size(54, 15);
            label9.TabIndex = 29;
            label9.Text = "Versione:";
            label9.Click += label9_Click;
            // 
            // version
            // 
            version.AutoSize = true;
            version.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            version.Location = new Point(64, 1017);
            version.Name = "version";
            version.Size = new Size(51, 15);
            version.TabIndex = 30;
            version.Text = "Versione";
            // 
            // main_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            Controls.Add(version);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(purchases);
            Controls.Add(basket);
            Controls.Add(lunch_list);
            Controls.Add(purchases_total);
            Controls.Add(label7);
            Controls.Add(see_history);
            Controls.Add(label5);
            Controls.Add(basket_total);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(add_to_basket);
            Controls.Add(remove);
            Controls.Add(add);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "main_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += main_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button add;
        private Button remove;
        private Button add_to_basket;
        private Label label4;
        private Label label2;
        private Label basket_total;
        private Label label5;
        private Button see_history;
        private Label purchases_total;
        private Label label7;
        private ListView lunch_list;
        private ListView basket;
        private ListView purchases;
        private Button button1;
        private Label label9;
        private Label version;
    }
}