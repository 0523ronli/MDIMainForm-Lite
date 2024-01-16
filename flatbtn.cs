namespace MDIMainForm
{
    public abstract class Flatbtn : Button
    {
        public Form? Linkform;
        public Panel expandPanel = new();
        public Action? ToRun;
        public abstract void repaint(bool restruct=false);
        public void Flatbtnclick(object sender, EventArgs e)
        {
            MainForm.Instance.checkedbtn = this;
            MainForm.Instance.ReFreshColor();
            MainForm.Instance.centerPenal.Controls.Clear();
            if (Linkform != null)
            {
                Linkform.FormBorderStyle = FormBorderStyle.None;
                Linkform.Dock = DockStyle.Fill;
                Linkform.TopLevel = false;
                MainForm.Instance.centerPenal.Controls.Add(Linkform);
                Linkform.Show();
            }
            ToRun?.Invoke();
            if (this is Leftbtn)
            {
                MainForm.Instance.ExpandAsync(this as Leftbtn);
            }
        }
    }
}
