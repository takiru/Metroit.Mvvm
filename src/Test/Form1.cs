﻿using Metroit.DDD.ContentRoot;
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
        //private new Form1ViewModel ViewModel => (Form1ViewModel)base.ViewModel;
        private new Form1ViewModel ViewModel = new Form1ViewModel();


        public Form1()
        {
            try
            {
                DIConfigration.Configure();

                // launchSettings.json を読み込める！
                var host = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs()).Build();
                var env = host.Services.GetRequiredService<IHostEnvironment>();

                InitializeComponent();

                textBox1.BindText(() => ViewModel.Text.Value);
                button1.BindClick(ViewModel.TestCommand);

                //textBox1.Bind(() => ViewModel.Text.Value);
                //button1.Bind(ViewModel.TestCommand);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public Form1(Form1ViewModel viewModel) : base(viewModel)
        //{
        //    InitializeComponent();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");


                //var a = new RequiredAttribute();
                //var b = new VORequiredAttribute();
                //var c = new Hoge("a");
                //MessageBox.Show("a");

                var b = new Hoge("a@ao.co.jp");

                var a = new Fuga(2, 2, "value1", FugaType.Special);
                //var b = new Fuga(123, "value1", FugaType.Special);
                //if (a == b)
                //{
                //    MessageBox.Show("おなじ");
                //}
                MessageBox.Show(a.ToString());
                MessageBox.Show(a.Value2.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + "\r\n" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ViewModel.Text.Value);
        }
    }

    [VORequired(ErrorMessage = "{0}は必須です。")]
    //[VORequired(ErrorMessageResourceName = "HogeMessage", ErrorMessageResourceType = typeof(Resource1))]
    //[VOMaxLength(5, ErrorMessage = "{0}は{1}桁まで")]   // null 空文字は許容される
    //[VOMaxLength(5, ErrorMessageResourceName = "FugaMessage", ErrorMessageResourceType = typeof(Resource1))]
    //[VOMinLength(2, ErrorMessage = "2桁以上")]     // null だけ許容される
    //[VORegularExpression(@"^[0-9]+$", ErrorMessage = "{0}は数値のみで入力してください。")]       // null 空文字は許容される
    [Display(Name = " DisplayNameで設定した名前")]
    //[VOLength(2, 5, ErrorMessage = "{0} は {1}桁以上{2}桁以下で入力してください。")]
    //[VOStringLength(1, ErrorMessage = "{0}は{1}桁まで")]
    //[VOEmailAddress(ErrorMessage = "形式が不正")]
    public class Hoge : SingleValueObject<string>
    {
        //public string Value { get; set; }

        //[VORequired(ErrorMessage = "{0}は必須です。")]
        ////[VOMaxLength(2, ErrorMessage = "{0} は{1} 桁まで")]
        //[Display(Name = " Fuga のDisplayName")]
        //public string Fuga { get; set; }

        ////[VORange(typeof(DateTime), "2025/01/01 12:23:34", "2025/12/31", "yyyy/MM/dd", ErrorMessage = "{0} は {1} から {2} まで")]
        //[Display(Name = "PiyoのDisplayName")]
        //public DateTime Piyo { get; set; }

        //[Display(Name = "YokaのDisplayName")]
        ////[VOEmailAddress(false, ErrorMessage = "{0}はメールアドレス形式で入力してください。")]
        ////[VOMaxLength(2, ErrorMessage = "{0}は{1}桁まで")]
        //public char[] Yoka { get; set; }

        //public Hoge(string value) : base(value)
        //{
        //    //Value = value;
        //    //Fuga = "Fuga";
        //    //Piyo = new DateTime(2024, 1, 1);
        //    //Yoka = ['a', 'b', 'c'];

        //    //Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
        //    //ValidateObject();
        //}

        public Hoge(string value) : base(false, value)
        {
            ICollection<ValidationResult> r;
            if (!TryValidateObject(out r))
            {
                throw new ArgumentException(r.First().ErrorMessage);
            }
        }
    }

    public class Fuga : MultiValueObject
    {
        //[VORange(1, 10, ErrorMessage = "{0}は{1}から{2}の範囲で入力してください。")]
        [VORange(1, 200, ErrorMessageResourceName = "FugaValue2Message", ErrorMessageResourceType = typeof(Resource1))]
        [VOFeedOrder(0)]
        [Display(Name = "Value1のDisplayName")]
        //[VOLessThan(nameof(Value3), true, ErrorMessage = $"{nameof(Value3)} より大きい")]
        public int? Value1 { get; private set; }

        [VOFeedOrder(1)]
        public int? Value3 { get; private set; }

        [MinLength(1, ErrorMessage = "10文字以上")]
        [VOFeedOrder(2)]
        public string Value2 { get; private set; }

        [VOFeedOrder(3)]
        public FugaType? FugaType { get; private set; }

        public Fuga(int? value1, int? value3, string value2, FugaType? fugaType) : base(value1, value3, value2, fugaType)
        {

        }
    }

    public enum FugaType
    {
        Normal,
        Special
    }
}
