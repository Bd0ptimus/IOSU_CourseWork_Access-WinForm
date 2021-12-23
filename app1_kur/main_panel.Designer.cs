namespace app1_kur
{
    partial class main_panel
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
            this.add_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.main_grid_view = new System.Windows.Forms.DataGridView();
            this.choose_table = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.main_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(34, 10);
            this.add_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(136, 32);
            this.add_button.TabIndex = 0;
            this.add_button.Text = "Добавить";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(331, 152);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(6, 6);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(34, 54);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(136, 32);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "Удалить";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // main_grid_view
            // 
            this.main_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.main_grid_view.Location = new System.Drawing.Point(9, 140);
            this.main_grid_view.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.main_grid_view.Name = "main_grid_view";
            this.main_grid_view.RowHeadersWidth = 51;
            this.main_grid_view.RowTemplate.Height = 24;
            this.main_grid_view.Size = new System.Drawing.Size(1242, 522);
            this.main_grid_view.TabIndex = 4;
            // 
            // choose_table
            // 
            this.choose_table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choose_table.FormattingEnabled = true;
            this.choose_table.Location = new System.Drawing.Point(1032, 92);
            this.choose_table.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.choose_table.Name = "choose_table";
            this.choose_table.Size = new System.Drawing.Size(219, 21);
            this.choose_table.TabIndex = 5;
            this.choose_table.SelectedIndexChanged += new System.EventHandler(this.choose_table_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(912, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выбирать таблицу";
            // 
            // main_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.choose_table);
            this.Controls.Add(this.main_grid_view);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.add_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "main_panel";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.main_grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.DataGridView main_grid_view;
        private System.Windows.Forms.ComboBox choose_table;
        private System.Windows.Forms.Label label1;
    }
}

