using System.Diagnostics;

namespace Metroit.Windows.Forms.Mvvm.Extensions.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = new List<Item>
            {
                new Item { Value = 1, Text = "Item 1" },
                new Item { Value = 2, Text = "Item 2" },
                new Item { Value = 3, Text = "Item 3" }
            };

            var obj = new ItemObject() { Items = list };

            metTextBox1.CustomAutoCompleteBox.BindDataSource(() => obj.Items, nameof(Item.Value), nameof(Item.Text));

            metDateTimePicker1.BindValue(() => obj.DateValue);
            metToggleSwitch1.BindChecked(() => obj.BoolValue);
        }

        private void metTextBox1_CandidateSelected(object sender, CandidateSelectedEventArgs e)
        {
            label1.Text = e.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"metDateTimePicker1 = {metDateTimePicker1.Value}");
            Debug.WriteLine($"metToggleSwitch1 = {metToggleSwitch1.Checked}");
        }
    }

    public class ItemObject
    {
        public List<Item>? Items { get; set; }

        public DateTime? DateValue { get; set; }

        public bool BoolValue { get; set; }
    }

    public class Item
    {
        public int Value { get; set; }

        public string? Text { get; set; }
    }
}
