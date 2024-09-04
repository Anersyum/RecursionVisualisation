namespace RecursionVisualisation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            int a = (int)numericUpDown1.Value;
            int b = (int)numericUpDown2.Value;

            lblResult.Text = $"Rezultat: {await Mnozenje(a, b)}";
        }

        private async Task<int> Mnozenje(int a, int b, int depth = 1)
        {
            int timeDelay = (int)numericUpDown3.Value;

            GroupBox gBox = GenerateGroupBox(depth);
            Label lbl = GenerateLabel(a, b, depth);

            gBox.Controls.Add(lbl);
             
            Controls.Add(gBox);
            
            if (b == 0)
            {
                lbl.Text = $"A = {a}, B = {b}, Rezultat = 0";
                lbl.Name = $"lbl{depth}";

                await Task.Delay(TimeSpan.FromSeconds(timeDelay));

                Controls.Remove(gBox);

                return 0;
            }

            await Task.Delay(TimeSpan.FromSeconds(timeDelay));

            int result = a + await Mnozenje(a, b - 1, depth + 1);

            lbl.Text = $"A = {a}, B = {b}, Rezultat = {a} + {result - a}";

            await Task.Delay(TimeSpan.FromSeconds(timeDelay));

            Controls.Remove(gBox);

            return result;
        }

        private Label GenerateLabel(int a, int b, int depth)
        {
            Label lbl = new();

            lbl.Location = new(25, 50);
            lbl.Width = 250;

            lbl.Text = $"A = {a}, B = {b}, Rezultat = {a} + Mnozenje({a}, {b - 1})";
            lbl.Name = $"lbl{depth}";

            return lbl;
        }

        private GroupBox GenerateGroupBox(int depth)
        {
            GroupBox gBox = new();

            gBox.Width = 300;
            gBox.Text = $"{depth} poziv";
            gBox.Location = new(321, 27 * ((depth - 1) * 5));
            gBox.Name = $"gBox{depth}";

            return gBox;
        }
    }
}