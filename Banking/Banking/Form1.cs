using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Banking
{
    public partial class Form1 : Form
    {
        List<string> AccountList = new List<string>();
        //string path = @".\document.txt";
        public Form1()
        {
            InitializeComponent();
            AccountList = new List<string>();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            bank obj = new bank();
            obj.balance = Convert.ToDecimal(textbalance.Text);
            string acclist = Convert.ToString(obj.account) + " : $" + Convert.ToString(obj.balance);
            AccountList.Add(acclist);
            listBox1.Items.Add(acclist);
            //File.AppendAllText(path, acclist);
            textbalance.Clear();
        }

        private void BtnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = Convert.ToDecimal(textamount.Text);
                if (amount > 0)
                {

                    int index = listBox1.SelectedIndex;
                    string str = Convert.ToString(AccountList.ElementAt(index));
                    string[] result = str.Split('$');
                    decimal curItem = Convert.ToDecimal(result[1]);
                    decimal curItem1 = curItem + amount;
                    string Updated = result[0] + "$" + Convert.ToString(curItem1);
                    AccountList.RemoveAt(index);
                    AccountList.Insert(index, Updated);
                    listBox1.Items.RemoveAt(index);
                    listBox1.Items.Insert(index, Updated);
                    textamount.Clear();
                    lblerror.Text = "";
                 }
            else
                {
                lblerror.Text = "Enter valid amount.";
                }
            }
            catch (Exception)
            {
                lblerror.Text = "Something went wrong!";
            }
        }

        private void BtnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = Convert.ToDecimal(textamount.Text);
                int index = listBox1.SelectedIndex;
                string str = Convert.ToString(AccountList.ElementAt(index));
                string[] result = str.Split('$');
                decimal curItem = Convert.ToDecimal(result[1]);
                if (amount > 0 & amount < curItem)
                {
                    decimal curItem1 = curItem - amount;
                    string Updated = result[0] + "$" + Convert.ToString(curItem1);
                    AccountList.RemoveAt(index);
                    AccountList.Insert(index, Updated);
                    listBox1.Items.RemoveAt(index);
                    listBox1.Items.Insert(index, Updated);
                    textamount.Clear();
                    lblerror.Text = "";
                }
                else
                {
                    lblerror.Text = "Amount can't be 0 or greater than balance.";
                }
            }
            catch (Exception)
            {
                lblerror.Text = "Something went wrong!";
            }
        }

    }
}

