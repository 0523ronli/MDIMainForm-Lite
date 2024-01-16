﻿using static MDIMainForm.DefaultColors;

namespace MDIMainForm
{
    public partial class Leftbtn : Flatbtn
    {
        public List<Subbtn> subbtnList = new();
        private void initialize()
        {
            BackColor = leftBackColor;
            Dock = DockStyle.Top;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Margin = new Padding(10);
            Size = new Size(200, 50);
            Text = "Leftbutton";
            TextAlign = ContentAlignment.MiddleLeft;
            Font = defaultFont;

            expandPanel.Dock = DockStyle.Top;
            expandPanel.Margin = new Padding(10);
            expandPanel.Size = new Size(200, 0);
            expandPanel.Font = defaultFont;
            expandPanel.ForeColor = Color.Gray;
        }
        public Leftbtn()
        {
            initialize();
            //event
            Click += Flatbtnclick!;
            MouseEnter += (s, e) =>
            {
                BackColor = checkedColor;
            };
            MouseLeave += (s, e) => {
                if (this != MainForm.Instance.checkedbtn)
                {
                    BackColor = leftBackColor;
                }
            };
        }

        public override void repaint(bool restruct=false)
        {
            BackColor = this == MainForm.Instance.checkedbtn ? checkedColor : leftBackColor;
            ForeColor = leftForeColor;
            foreach (Subbtn sb in subbtnList) sb.repaint();
            if (restruct)
            {
                expandPanel.Controls.Clear();
                expandPanel.Controls.AddRange(subbtnList.Reverse<Subbtn>().ToArray());
            }
        }
    }
}
