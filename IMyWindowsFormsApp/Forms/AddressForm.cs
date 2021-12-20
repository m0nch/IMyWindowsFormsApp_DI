using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Services;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IMyWindowsFormsApp.Forms
{
    public partial class AddressForm : Form
    {
        public Student StudentInfo { get; set; }

        private readonly IAddressService _addressService;
        public AddressForm(IAddressService addressService)
        {
            InitializeComponent();
            _addressService = addressService;
        }
        private void AddressForm_Load(object sender, EventArgs e)
        {
            lblSGuid.Visible = true;
            lblSGuid.Text = StudentInfo.Id.ToString();
            lblStFullName.Visible = true;
            lblStFullName.Text = $"{StudentInfo.LastName} { StudentInfo.FirstName}";
            Address address = _addressService.Get(StudentInfo.Id);
            if (address != null)
            {
                txtAddress1.Text = address.Address1;
                txtAddress2.Text = address.Address2;
                txtCity.Text = address.City;
                txtState.Text = address.State;
                txtCountry.Text = address.Country;
                txtZip.Text = address.ZipCode;
                txtPhone.Text = address.PhoneNumber;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Address address = new Address
            {
                StudentId = StudentInfo.Id,
                Address1 = txtAddress1.Text,
                Address2 = txtAddress2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Country = txtCountry.Text,
                ZipCode = txtZip.Text,
                PhoneNumber = txtPhone.Text
            };
            _addressService.Add(address);
            MessageBox.Show($"This address\n{txtAddress1.Text} {txtAddress2.Text}\n{txtCity.Text} {txtState.Text} {txtCountry.Text}\n{txtZip.Text} {txtPhone.Text}\nwas added to AddressList", "Addres Info");
            this.Close();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Address address = _addressService.Get(StudentInfo.Id);
            _addressService.Remove(address);
            MessageBox.Show($"Address was deleted from AddressList", "Addres Info");

            this.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Address address = new Address
            {
                Address1 = txtAddress1.Text,
                Address2 = txtAddress2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Country = txtCountry.Text,
                ZipCode = txtZip.Text,
                PhoneNumber = txtPhone.Text,
                StudentId = Guid.Parse(lblSGuid.Text)                
            };
            _addressService.Update(address);
            MessageBox.Show($"The address was edited to this one - \n{txtAddress1.Text} {txtAddress2.Text}\n{txtCity.Text} {txtState.Text} {txtCountry.Text}\n{txtZip.Text} {txtPhone.Text}", "Addres Info");

            this.Close();
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[+]?[(]?[0-9]{1,3}[)]?[-s.]?[\\s.]?[0-9]{2,3}[-s.]?[\\s.]?[0-9]{6,7}$";
            if (!Regex.IsMatch(txtPhone.Text, pattern))
            {
                txtPhone.Clear();
            }
        }
        private void txtZip_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[0-2]{1}[0-9]{3}$";
            if (!Regex.IsMatch(txtZip.Text, pattern))
            {
                txtZip.Clear();
            }
        }
    }
}
