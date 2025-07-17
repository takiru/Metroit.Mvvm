using Metroit.DDD.ContentRoot;
using Metroit.DDD.Domain.Annotations;
using Metroit.DDD.Domain.ValueObjects;
using Metroit.Mvvm.WinForms.Extensions;
using Metroit.Mvvm.WinForms.ReactiveProperty.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : ViewBase
    {
        private new Form1ViewModel ViewModel = new Form1ViewModel();


        public Form1()
        {
            try
            {
                InitializeComponent();

                textBox1.BindText(() => ViewModel.Text.Value);
                button1.BindClick(ViewModel.TestCommand);

                textBox1.Bind(() => ViewModel.Text.Value);
                button1.Bind(ViewModel.TestCommand);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ViewModel.Text.Value);
        }
    }
}
