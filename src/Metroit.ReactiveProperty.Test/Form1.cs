namespace Metroit.ReactiveProperty.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var record = new Record();
            record.Name.Value = $"hoge";
            record.Name.Value = $"hoge";
            record.Age.Value = 10;
            record.Hoge = "aaa";
        }
    }
}
