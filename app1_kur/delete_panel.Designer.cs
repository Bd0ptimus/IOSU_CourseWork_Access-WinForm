namespace app1_kur
{
    partial class delete_panel
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
            this.deletepanel_grid_view = new System.Windows.Forms.DataGridView();
            this.delete_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deletepanel_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // deletepanel_grid_view
            // 
            this.deletepanel_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deletepanel_grid_view.Location = new System.Drawing.Point(9, 79);
            this.deletepanel_grid_view.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deletepanel_grid_view.Name = "deletepanel_grid_view";
            this.deletepanel_grid_view.ReadOnly = true;
            this.deletepanel_grid_view.RowHeadersWidth = 51;
            this.deletepanel_grid_view.RowTemplate.Height = 24;
            this.deletepanel_grid_view.Size = new System.Drawing.Size(1242, 583);
            this.deletepanel_grid_view.TabIndex = 6;
            this.deletepanel_grid_view.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.deletepanel_grid_view_CellClick);
            // 
            // delete_btn
            // 
            this.delete_btn.Enabled = false;
            this.delete_btn.Location = new System.Drawing.Point(12, 12);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(150, 46);
            this.delete_btn.TabIndex = 7;
            this.delete_btn.Text = "Удалить";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // delete_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.deletepanel_grid_view);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "delete_panel";
            this.Text = "delete_panel";
            this.Load += new System.EventHandler(this.delete_panel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deletepanel_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView deletepanel_grid_view;
        private System.Windows.Forms.Button delete_btn;
    }
}