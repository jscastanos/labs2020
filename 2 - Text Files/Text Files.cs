using _2___Text_Files.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _2___Text_Files
{
    public partial class frmTextFile : Form
    {
        readonly List<Person> tempPersons = new List<Person>();
        readonly string csvPath = "../../Data/users.csv";
        int currentDataCount = 0;

        public frmTextFile()
        {
            InitializeComponent();
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            string firstName = txtFname.Text;
            string lastName = txtLname.Text;
            decimal age = numAge.Value;
            bool isAlive = chkIsAlive.Checked;

            if (firstName.Length > 0 && lastName.Length > 0 && age > 0)
            {
                tempPersons.Add(new Person(firstName, lastName, age, isAlive));
                lstUsers.Items.Add($"{firstName} {lastName} is {age} and is {(isAlive ? "alive" : "dead")}");

                //reset value
                txtFname.Text = "";
                txtLname.Text = "";
                numAge.Value = 0;
                chkIsAlive.Checked = false;
            }
            else
            {
                MessageBox.Show("Can't \"Add User\" some fields appears to be empty");
            }


        }

        private void FrmTextFile_Load(object sender, EventArgs e)
        {

            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Person>();

                foreach (var item in records)
                {
                    currentDataCount++;
                    tempPersons.Add(new Person(item.FirstName, item.LastName, item.Age, item.IsAlive));
                    lstUsers.Items.Add($"{item.FirstName} {item.LastName} is {item.Age} and is {(item.IsAlive ? "alive" : "dead")}");
                }
            }
        }

        private void BtnSaveList_Click(object sender, EventArgs e)
        {
            //check if there's new data
            if (currentDataCount < tempPersons.Count())
            {
                using (var writer = new StreamWriter(csvPath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(tempPersons);
                    writer.Flush();

                    MessageBox.Show("Save successfully");
                }
            }
        }
    }
}
