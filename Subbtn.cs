using static MDIMainForm.DefaultColors;

namespace MDIMainForm
{
    public partial class Subbtn : Flatbtn
    {
        private void initialize()
        {
            
            Dock = DockStyle.Top;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Margin = new Padding(10);
            Size = new Size(200, 30);
            Text = "Subbutton";
            TextAlign = ContentAlignment.MiddleLeft;
            Font = subFont;
            ForeColor = Color.Gray;
        }
        public Subbtn()
        {
            initialize();
            BackColor = subBackColor;
            
            //event
            Click += Flatbtnclick!;
            MouseEnter += (s, e) =>
            {
                BackColor = checkedColor;
            };
            MouseLeave += (s, e) => {
                if (this != MainForm.Instance.checkedbtn)
                {
                    BackColor = subBackColor;
                }
            };
        }
        public override void repaint(bool _=false)
        {
            BackColor = this == MainForm.Instance.checkedbtn ? checkedColor : subBackColor;
            ForeColor = subForeColor;
        }
    }
}
