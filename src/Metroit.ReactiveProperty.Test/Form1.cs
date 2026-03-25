using Metroit.Mvvm.WinForms.Extensions;
using System.Text;

namespace Metroit.ReactiveProperty.Test
{
    public partial class Form1 : Form
    {
        private Record record = new Record();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            record.Name.Value = $"hoge";
            record.Name.Value = $"hoge";
            record.Age.Value = 10;
            record.Hoge = "aaa";

            toolStripButton1.BindEnabled(() => record.ButtonEnabled.Value);
            toolStripButton1.BindVisible(() => record.ButtonVisible.Value);

            toolStripButton2.BindEnabled(() => record.CheckButtonEnabled.Value);
            toolStripButton2.BindVisible(() => record.CheckButtonVisible.Value);
            toolStripButton2.BindChecked(() => record.CheckButtonChecked.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            record.ButtonEnabled.Value = !record.ButtonEnabled.Value;
            record.ButtonVisible.Value = !record.ButtonVisible.Value;
            record.CheckButtonEnabled.Value = !record.CheckButtonEnabled.Value;
            record.CheckButtonVisible.Value = !record.CheckButtonVisible.Value;
            record.CheckButtonChecked.Value = !record.CheckButtonChecked.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Button.Enabled={toolStripButton1.Enabled}, VM={record.ButtonEnabled.Value}");
            sb.AppendLine($"Button.Visible={toolStripButton1.Enabled}, VM={record.ButtonVisible.Value}");
            sb.AppendLine($"CheckButton.Enabled={toolStripButton2.Enabled}, VM={record.CheckButtonEnabled.Value}");
            sb.AppendLine($"CheckButton.Visible={toolStripButton2.Visible}, VM={record.CheckButtonVisible.Value}");
            sb.AppendLine($"CheckButton.Checked={toolStripButton2.Checked}, VM={record.CheckButtonChecked.Value}");

            textBox1.Text = sb.ToString();
        }
    }
}
