using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace app1_kur
{
    public partial class main_panel : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kur.accdb");
        OleDbCommand cmd = new OleDbCommand();
        String makeQuery = "";
        public main_panel()
        {
            InitializeComponent();
            onload(true);
        }

        //load new form
        public void onload(bool loadNewForm) {
            String queryString = "";
            if (loadNewForm)
            {
                loadNewComboBox();
            }
            switch (choose_table.SelectedIndex)
            {
                case 0:
                    queryString = "SELECT * FROM Компании ORDER BY Код_компании ASC";
                    break;
                case 1:
                    queryString = "SELECT Работка.Код_работка, Поле_работы.Детали_работы, Компании.Название_компании, Работка.Рабочее_место FROM(Работка LEFT JOIN Поле_работы ON Поле_работы.Код_поле = Работка.Рекомендуемая_работа) LEFT JOIN Компании ON Компании.Код_компании = Работка.Код_компании ORDER BY Работка.Код_работка ASC; ";
                    break;
                case 2:
                    queryString = "SELECT Человек_ищет_работу.*, Поле_работы.Детали_работы FROM(Человек_ищет_работу LEFT JOIN Работка ON Человек_ищет_работу.Ищет_работу = Работка.Код_работка) LEFT JOIN Поле_работы ON Поле_работы.Код_поле = Работка.Рекомендуемая_работа; ";
                    break;
            }
            loadGridView(queryString);

        }

        //load new combobox
        private void loadNewComboBox() {
            choose_table.Items.Add("Компании");
            choose_table.Items.Add("Работка");
            choose_table.Items.Add("Человек ищет работу ");
            choose_table.SelectedIndex = 0;
        }

        //Grid view 
        private void loadGridView(string queryString) {
            cmd.Connection = connection;
            connection.Open();
            try
            {
                makeQuery = queryString;
                cmd.CommandText = makeQuery;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                main_grid_view.DataSource = null;
                main_grid_view.DataSource = dt;
                for (int i = 0; i < main_grid_view.Columns.Count; i++)
                {
                    main_grid_view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Add button
        private void add_button_Click(object sender, EventArgs e)
        {
            int tableIndex = choose_table.SelectedIndex;
            add_panel addPanel_move = new add_panel(tableIndex);
            addPanel_move.ShowDialog();
            onload(false);
        }

        //Delete button
        private void delete_button_Click(object sender, EventArgs e)
        {
            int tableIndex = choose_table.SelectedIndex;
            delete_panel deletePanel_move = new delete_panel(tableIndex);
            deletePanel_move.ShowDialog();
            onload(false);
        }

        //Choose table combobox
        public void choose_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            onload(false);
        }

        
    }
}
