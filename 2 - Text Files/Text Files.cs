using _2___Text_Files.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace _2___Text_Files
{
    public partial class frmTextFile : Form
    {
        private readonly List<Person> tempPersons = new List<Person>();
        private readonly string csvPath = @".\Data\users.csv";
        private int currentDataCount = 0;

        public frmTextFile()
        {
            InitializeComponent();
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            Person person = new Person(
                FirstName: txtFname.Text,
                LastName: txtLname.Text,
                Age: numAge.Value,
                IsAlive: chkIsAlive.Checked
                );

            if (person.FirstName.Length > 0 && person.LastName.Length > 0 && person.Age > 0)
            {
                AddToList(person);

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
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Person>();

            foreach (var item in records)
            {
                currentDataCount++;
                AddToList(item);
            }
        }

        private void BtnSaveList_Click(object sender, EventArgs e)
        {
            //check if there's new data
            if (currentDataCount < tempPersons.Count)
            {
                using var writer = new StreamWriter(csvPath);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(tempPersons);
                writer.Flush();

                MessageBox.Show("Save successfully");
            }
        }

        private void AddToList(Person data)
        {
            tempPersons.Add(new Person(data.FirstName, data.LastName, data.Age, data.IsAlive));
            lstUsers.Items.Add(data.FullText);
        }
    }
}