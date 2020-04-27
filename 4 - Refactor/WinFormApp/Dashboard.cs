using Refactor.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Dashboard : Form
    {
        public static DataAccessLayer dataAccessLayer = new DataAccessLayer();
        readonly BindingList<UserModel> users = new BindingList<UserModel>();

        public Dashboard()
        {
            InitializeComponent();

            userDisplayList.DataSource = users;
            userDisplayList.DisplayMember = "FullName";

            PrintData();
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            var user = new
            {
                FirstName = firstNameText.Text,
                LastName = lastNameText.Text
            };

            dataAccessLayer.CreateUser(user);
            firstNameText.Text = "";
            lastNameText.Text = "";
            firstNameText.Focus();

            PrintData();
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {

            var p = new
            {
                Filter = filterUsersText.Text
            };

            PrintData(true, p);
        }

        public void PrintData(bool IsFilter = false, object data = null)
        {
            List<UserModel> records = null;

            if (IsFilter)
                records = dataAccessLayer.FilterUser(data);
            else
                records = dataAccessLayer.GetUser();

            users.Clear();
            records.ForEach(x => users.Add(x));
        }
    }
}
