namespace MDIMainForm
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public Button checkedbtn = new();
        public bool leftfold;
        public List<Leftbtn> originalleftbtn = new();
        public void ReFreshColor()
        {
            foreach (Flatbtn button in originalleftbtn.Reverse<Flatbtn>())
            {
                button.repaint();
            }
        }
        public void leftrestore()
        {
            foldablePanel.Controls.Clear();
            foreach (Flatbtn button in originalleftbtn.Reverse<Flatbtn>())
            {
                button.repaint(true);
                foldablePanel.Controls.Add(button);
            }
        }
        public async Task ExpandAsync(Leftbtn leftbtn)
        {
            if (foldablePanel.Contains(leftbtn.expandPanel) || leftbtn.expandPanel.Controls.Count == 0) return;
            leftrestore();
            int index = foldablePanel.Controls.IndexOf(leftbtn);
            List<Control> controlList = [.. foldablePanel.Controls.OfType<Control>()];
            controlList.Insert(index, leftbtn.expandPanel);
            foldablePanel.Controls.Clear();
            foreach (Control control in controlList)
            {
                foldablePanel.Controls.Add(control);
            }
            leftbtn.expandPanel.Size = new Size(0, 0);
            foreach (int i in Enumerable.Range(0, leftbtn.expandPanel.Controls.Count * 5+1))
            {
                leftbtn.expandPanel.Size = new Size(0, i * 6);
                await Task.Delay(1);
            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            //config originalleftbtn here
            originalleftbtn.Clear();
            originalleftbtn.Add(new Leftbtn()
            {
                Text = "Test button",
                subbtnList =
                [
                    new Subbtn() { Text = "Test Subbutton", Linkform = new Form() },
                ]
            }) ;
            leftrestore();
        }
    }
}