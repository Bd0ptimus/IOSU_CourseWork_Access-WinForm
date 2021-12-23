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
    public partial class add_panel : Form
    {
        public event System.Windows.Forms.FormClosingEventHandler FormClosing;
        //-----For call Database
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kur.accdb");
        OleDbCommand cmd = new OleDbCommand();
        String makeQuery = "";
        List<String> idWorkForChoosing = new List<String>();//Claim id in work existed
        List<String> idCompanyExist = new List<String>(); //Claim id of Company
        List<String> idWorkProposed = new List<String>();//Claim id work proposed 
        int panelForTable;//Index of table choosen
        public add_panel(int tableIndex)
        {
            panelForTable = tableIndex;
            InitializeComponent();
        }

        //Load New Panel
        private void add_panel_Load(object sender, EventArgs e)
        {
            String queryString = "";
            switch (panelForTable)
            {
                case 0:
                    controlInterfaceCompanyTable(true);
                    controlInterfacePersonTable(false);
                    controlInterfaceWorkTable(false);
                    queryString = "SELECT * FROM Компании ORDER BY Код_компании ASC";
                    break;
                case 1:
                    controlInterfaceCompanyTable(false);
                    controlInterfacePersonTable(false);
                    controlInterfaceWorkTable(true);
                    loadCompany();
                    loadWorkProposed();
                    queryString = "SELECT Работка.Код_работка, Поле_работы.Детали_работы, Компании.Название_компании, Работка.Рабочее_место FROM(Работка LEFT JOIN Поле_работы ON Поле_работы.Код_поле = Работка.Рекомендуемая_работа) LEFT JOIN Компании ON Компании.Код_компании = Работка.Код_компании ORDER BY Работка.Код_работка ASC; ";
                    break;
                case 2:
                    controlInterfaceCompanyTable(false);
                    controlInterfacePersonTable(true);
                    controlInterfaceWorkTable(false);
                    loadWorkDesired();
                    personadd_gender_cmb.Items.Add("М");
                    personadd_gender_cmb.Items.Add("Ж");
                    personadd_gender_cmb.SelectedIndex = 0;
                    queryString = "SELECT Человек_ищет_работу.*, Поле_работы.Детали_работы FROM(Человек_ищет_работу LEFT JOIN Работка ON Человек_ищет_работу.Ищет_работу = Работка.Код_работка) LEFT JOIN Поле_работы ON Поле_работы.Код_поле = Работка.Рекомендуемая_работа; ";
                    break;
            }
            loadGridView(queryString);
        }

        //------------------Control these interfaces-------------------
        private void controlInterfaceCompanyTable(bool turnOn)
        {
            if (turnOn)
            {
                companyadd_name.Visible = true;
                companyadd_name_textbox.Visible = true;
                companyadd_head.Visible = true;
                companyadd_head_textbox.Visible = true;
            }
            else
            {
                companyadd_name.Visible = false;
                companyadd_name_textbox.Visible = false;
                companyadd_head.Visible = false;
                companyadd_head_textbox.Visible = false;
            }
        }

        private void controlInterfaceWorkTable(bool turnOn)
        {
            if (turnOn)
            {
                workadd_choosecompany.Visible = true;
                workadd_choosecompany_cmb.Visible = true;
                workadd_chooseworkfeild.Visible = true;
                workadd_chooseworkfeild_cmb.Visible = true;
                workadd_workplace.Visible = true;
                workadd_workadress_textbox.Visible = true;
            }
            else
            {
                workadd_choosecompany.Visible = false;
                workadd_choosecompany_cmb.Visible = false;
                workadd_chooseworkfeild.Visible = false;
                workadd_chooseworkfeild_cmb.Visible = false;
                workadd_workplace.Visible = false;
                workadd_workadress_textbox.Visible = false;
            }
        }

        private void controlInterfacePersonTable(bool turnOn)
        {
            if (turnOn)
            {
                personadd_name.Visible = true;
                personadd_name_textbox.Visible = true;
                personadd_datebirth.Visible = true;
                personadd_datebirth_picker.Visible = true;
                personadd_gender.Visible = true;
                personadd_gender_cmb.Visible = true;
                personadd_jobdesired.Visible = true;
                personadd_jobdesired_cmb.Visible = true;
                personadd_adress.Visible = true;
                personadd_adress_textbox.Visible = true;
            }
            else
            {
                personadd_name.Visible = false;
                personadd_name_textbox.Visible = false;
                personadd_datebirth.Visible = false;
                personadd_datebirth_picker.Visible = false;
                personadd_gender.Visible = false;
                personadd_gender_cmb.Visible = false;
                personadd_jobdesired.Visible = false;
                personadd_jobdesired_cmb.Visible = false;
                personadd_adress.Visible = false;
                personadd_adress_textbox.Visible = false;
            }
        }
        //------------------------

        //----------------Load these comboboxes inside each panel-------------------

        private void loadCompany()
        {
            cmd.Connection = connection;
            connection.Open();
            try
            {
                makeQuery = "SELECT * FROM Компании ORDER BY Код_компании ASC";
                cmd.CommandText = makeQuery;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                DataSet newdataset = new DataSet();
                dataAdapter.Fill(newdataset, "onloadTable");
                DataTable dt = newdataset.Tables["onloadTable"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    workadd_choosecompany_cmb.Items.Add(dt.Rows[i].ItemArray[1].ToString());
                    idCompanyExist.Add(dt.Rows[i].ItemArray[0].ToString());
                }
                workadd_choosecompany_cmb.SelectedIndex = 0;
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

        private void loadWorkProposed()
        {
            cmd.Connection = connection;
            connection.Open();
            try
            {
                makeQuery = "SELECT * FROM Поле_работы ORDER BY Код_поле ASC";
                cmd.CommandText = makeQuery;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                DataSet newdataset = new DataSet();
                dataAdapter.Fill(newdataset, "onloadTable");
                DataTable dt = newdataset.Tables["onloadTable"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    workadd_chooseworkfeild_cmb.Items.Add(dt.Rows[i].ItemArray[2].ToString());
                    idWorkProposed.Add(dt.Rows[i].ItemArray[0].ToString());
                }
                workadd_chooseworkfeild_cmb.SelectedIndex = 0;
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

        private void loadWorkDesired()
        {
            cmd.Connection = connection;
            connection.Open();
            try
            {
                makeQuery = "SELECT Работка.Код_работка, Поле_работы.Детали_работы, Компании.Название_компании, Работка.Рабочее_место FROM(Работка LEFT JOIN Поле_работы ON Поле_работы.Код_поле = Работка.Рекомендуемая_работа) LEFT JOIN Компании ON Компании.Код_компании = Работка.Код_компании WHERE Работка.Код_работка NOT IN(SELECT Ищет_работу FROM Человек_ищет_работу WHERE Ищет_работу IS NOT NULL) ORDER BY Работка.Код_работка; ";
                cmd.CommandText = makeQuery;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                DataSet newdataset = new DataSet();
                dataAdapter.Fill(newdataset, "onloadTable");
                DataTable dt = newdataset.Tables["onloadTable"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    personadd_jobdesired_cmb.Items.Add(dt.Rows[i].ItemArray[1].ToString() + " - " + dt.Rows[i].ItemArray[2].ToString() + " - " + dt.Rows[i].ItemArray[3].ToString());
                    idWorkForChoosing.Add(dt.Rows[i].ItemArray[0].ToString());
                }
                personadd_jobdesired_cmb.SelectedIndex = 0;
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
        //---------------

        //----------------Load gridview------------------
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
                addpanel_grid_view.DataSource = dt;
                for (int i = 0; i < addpanel_grid_view.Columns.Count; i++)
                {
                    addpanel_grid_view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
        //---------------

        //Handle event in adding button
        private void add_button_Click(object sender, EventArgs e)
        {
            bool textboxesFilled = true;
            bool ageAllow = true;
            if (panelForTable == 0)
            {
                if (companyadd_name_textbox.Text == "" || companyadd_head_textbox.Text == "")
                {
                    textboxesFilled = false;
                }
                else
                {
                    textboxesFilled = true;
                }
            }
            else if (panelForTable == 1)
            {
                if (workadd_workadress_textbox.Text == "")
                {
                    textboxesFilled = false;
                }
                else
                {
                    textboxesFilled = true;
                }
            }
            else
            {
                if (personadd_adress_textbox.Text == "" || personadd_name_textbox.Text == "")
                {
                    textboxesFilled = false;
                }
                else
                {
                    int currentYear = DateTime.Now.Year;
                    if (currentYear - personadd_datebirth_picker.Value.Year > 17)
                    {
                        ageAllow = true;
                    }
                    else
                    {
                        ageAllow = false;
                    }
                    textboxesFilled = true;
                }
            }
            if (!textboxesFilled)
            {
                textbox_not_filled.Visible = true;
            }
            else
            {
                textbox_not_filled.Visible = false;
                if (!ageAllow)
                {
                    datebirth_not_allow.Visible = true;
                }
                else
                {
                    datebirth_not_allow.Visible = false;
                    addDataToDb();
                }
            }
        }

        //Function reload form
        private void reloadPage()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            object sender = new object();
            EventArgs e = new EventArgs();
            add_panel_Load(sender,e);
        }

        //Add infomation to Access
        private void addDataToDb()
        {
            String query = "";
            switch (panelForTable)
            {
                case 0:
                    query = "INSERT INTO Компании(Название_компании, Штаб_квартира) VALUES('"
                   + companyadd_name_textbox.Text + "','"
                   + companyadd_head_textbox.Text + "')";
                    break;
                case 1:
                    //id company existed
                    String idChoosenCompanyStr = idCompanyExist[workadd_choosecompany_cmb.SelectedIndex].ToString();
                    //id work existed
                    String idWorkStr = idWorkProposed[workadd_chooseworkfeild_cmb.SelectedIndex].ToString();
                    query = "INSERT INTO Работка(Код_компании, Рекомендуемая_работа, Рабочее_место) VALUES("
                   + idChoosenCompanyStr + ","
                   + idWorkStr + ",'"
                   + workadd_workadress_textbox.Text + "')";
                    break;
                case 2:
                    //id work desired
                    String idWorkDesired = idWorkForChoosing[personadd_jobdesired_cmb.SelectedIndex];
                    //gender
                    String gender = "";
                    if (personadd_jobdesired_cmb.SelectedIndex == 0)
                    {
                        gender = "М";
                    }
                    else
                    {
                        gender = "Ж";
                    }
                    //date of birth
                    String dateBirth = personadd_datebirth_picker.Value.Day.ToString() + "."
                        + personadd_datebirth_picker.Value.Month.ToString() + "."
                        + personadd_datebirth_picker.Value.Year.ToString();
                    query = "INSERT INTO Человек_ищет_работу(ФИО, Дата_рождения, Пол, Адрес,Ищет_работу) VALUES('"
                   + personadd_name_textbox.Text + "','"
                   + dateBirth + "','"
                   + gender + "','"
                   + personadd_adress_textbox.Text + "',"
                   + idWorkDesired + ")";
                    break;
            }

            connection.Open();
            try
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Добавить успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            reloadPage();

        }

    }
    
    
}
