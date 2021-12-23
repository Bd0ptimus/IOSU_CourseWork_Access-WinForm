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
    public partial class delete_panel : Form
    {
        //-----For call Database
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kur.accdb");
        OleDbCommand cmd = new OleDbCommand();
        String makeQuery = "";
        String condition = "";
        int panelForTable;//Index of table choosen

        public delete_panel(int tableIndex)
        {
            panelForTable = tableIndex;
            InitializeComponent();
        }

        private void delete_panel_Load(object sender, EventArgs e)
        {
            String queryString = "";
            switch (panelForTable)
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

        private void loadGridView(string queryString)
        {
            cmd.Connection = connection;
            connection.Open();
            try
            {
                makeQuery = queryString;
                cmd.CommandText = makeQuery;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                deletepanel_grid_view.DataSource = dt;
                for (int i = 0; i < deletepanel_grid_view.Columns.Count; i++)
                {
                    deletepanel_grid_view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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



        private void deletepanel_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            delete_btn.Enabled = true;
            int selectedIndex = e.RowIndex;
            DataGridViewRow selectedRow = deletepanel_grid_view.Rows[selectedIndex];
            condition = selectedRow.Cells[0].Value.ToString();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            String queryString = "";
            switch (panelForTable)
            {
                case 0:
                    queryString = "UPDATE Человек_ищет_работу SET Ищет_работу = NULL WHERE Ищет_работу IN(SELECT Код_работка FROM Работка WHERE Код_компании="+condition+");";
                    updateDb(queryString);
                    queryString = "DELETE Компании.*, Работка.* FROM Компании INNER JOIN Работка ON Компании.Код_компании = Работка.Код_компании WHERE Компании.Код_компании=" + condition;
                    updateDb(queryString);
                    break;
                case 1:
                    queryString = "UPDATE Человек_ищет_работу SET Ищет_работу=NULL WHERE Человек_ищет_работу.Ищет_работу=" + condition;
                    updateDb(queryString);
                    queryString = "DELETE * FROM Работка WHERE Работка.Код_работка=" + condition;
                    updateDb(queryString);
                    break;
                case 2:
                    queryString = "DELETE * FROM Человек_ищет_работу WHERE Человек_ищет_работу.Код_чекловека=" + condition;
                    updateDb(queryString);
                    break;
            }
            reloadPage();
        }

        private void updateDb(String query) {
            connection.Open();
            try
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
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

        //Function reload form
        private void reloadPage()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            object sender = new object();
            EventArgs e = new EventArgs();
            delete_panel_Load(sender, e);
        }
    }
}
