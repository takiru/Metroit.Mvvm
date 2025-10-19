namespace Metroit.Mvvm.WinForms.Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            var a = new Form4();
            var b = a.Response.StringValue;
        }
    }
}
