using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using FactoryMiddlayer;
//using DomainLayer;
//using FactoryDalLib;
//using IDal;
//using System.Transactions;
//using Facade;
//using ICustomerInterface;

using InterfaceCustomer;
using FactoryDomainLayer;

namespace WindowsCustomerUI
{
    public partial class Form1 : Form
    {
        //CustomerUiFacade Fac = new CustomerUiFacade("AdoCustDal");
        //ICustomer icust = null;

        private ICustomer customer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtAddress.Text = "";
            txtBillingAmount.Text = "";
            txtBillingDate.Text = "";
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            cmbCustomerType.Focus();
        }

        private void LoadData()
        {

            txtAddress.Text = customer.Address.ToString();
            txtBillingAmount.Text = customer.BillAmount.ToString();
            txtBillingDate.Text = customer.BillDate.ToString();
            txtCustomerName.Text = customer.CustomerName;
            txtPhoneNumber.Text = customer.PhoneNumber;
            //cmbCustomerType.Text = customer.type;
        }

        private void SetData()
        {
            
            customer.CustomerName = txtCustomerName.Text;
            customer.Address = txtAddress.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.BillDate = Convert.ToDateTime(txtBillingDate.Text);
            customer.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);

        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //icust = Factory<ICustomer>.Create(cmbCustomerType.Text);

            //customer =  Factory.Create(cmbCustomerType.Text);
            customer = Factory.Create(cmbCustomerType.Text);
            txtBillingDate.Text = DateTime.Now.ToString();
            txtBillingAmount.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
           // dataGridView1.DataSource = Fac.GetCustomers();
        }


        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                SetData();
               customer.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



        #region Design Pattern Examples

        //private void btnAdd_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        icust = Fac.Get(cmbCustomerType.Text);


        //        icust.CustomerName = txtCustomerName.Text;
        //        icust.Address = txtAddress.Text;
        //        icust.PhoneNumber = txtPhoneNumber.Text;
        //        icust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
        //        icust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);

        //        Fac.Save(icust);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    dataGridView1.DataSource = Fac.GetCustomers(); ;
        //    Clear();
        //}

        //private void comboRepository_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Fac = new CustomerUiFacade(comboRepository.Text);
        //    dataGridView1.DataSource = Fac.GetCustomers();
        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    icust = Fac.Revert();
        //    LoadData();
        //}


        //private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    //icust = Fac.Select(e.RowIndex);
        //    //LoadData(); 
        //}


        #endregion

      

       
    }
}
