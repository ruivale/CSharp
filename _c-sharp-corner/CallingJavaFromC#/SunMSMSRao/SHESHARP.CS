using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System;


public class shesharp : Form
{
    private Pen pn = null;
    private Button b = null;

    public shesharp()
    {
        Color nyc = Color.FromArgb(200, 50, 5, 200);
        b = new Button();
        b.Text = "Call Java";
        b.Size = new Size(290, 35);
        b.Location = new Point(0, 240);
        b.BackColor = nyc;
        b.ForeColor = Color.Red;
        b.Font = new Font("Arial", 14, FontStyle.Bold);
        b.Click += new System.EventHandler(calljava);
        pn = new Pen(Color.LightGreen, 10);
        this.Text = "C#";
        this.Paint += new PaintEventHandler(format);
        this.Controls.Add(new pp());
        this.Controls.Add(b);
        this.TopMost = true;
        this.MaximizeBox = false;
    }
    public void format(object s, PaintEventArgs a)
    {
        Graphics g = CreateGraphics();
        Rectangle rect = new Rectangle(0, 0, 300, 300);
        Color nyc = Color.FromArgb(200, 50, 5, 200);
        LinearGradientBrush b = new LinearGradientBrush(rect, Color.DarkOrange, nyc, LinearGradientMode.Vertical);
        g.FillRectangle(b, rect);
    }
    private void calljava(object ob, EventArgs arg)
    {
        Process.Start("j.bat");
    }
    public class pp : Panel
    {
        int x;
        int y;
        Timer t = new Timer();
        String s = "Hi...\nyou Know?\nWe are good Friends\nI can call Java ...";
        String mail = "mail me..\nmallm_uma@rediffmail.com\nmahe_proj@rediffmail.com";
        private Label l = null;
        private Label maill = null;
        Color nyc;
        public pp()
        {
            x = 10;
            y = 200;
            this.Location = new Point(0, 10);
            nyc = Color.FromArgb(200, 10, 5, 225);
            this.Size = new Size(300, 230);
            maill = new Label();
            l = new Label();
            l.Text = s;
            l.Size = new Size(250, 100);
            l.ForeColor = nyc;
            l.BackColor = Color.Transparent;
            l.Font = new Font("verdana", 15, FontStyle.Bold);
            l.TextAlign = ContentAlignment.MiddleCenter;
            maill.Text = mail;
            maill.Size = new Size(160, 40);
            maill.Location = new Point(10, 192);
            maill.Font = new Font("verdana", 7, FontStyle.Bold);
            maill.ForeColor = Color.Yellow;
            maill.BackColor = Color.Transparent;
            this.Controls.Add(l);
            this.Controls.Add(maill);
            t.Interval = 50;
            t.Tick += new EventHandler(draw);
            t.Enabled = true;
        }
        protected override void OnPaint(PaintEventArgs a)
        {
            Graphics g = a.Graphics;
            Rectangle rect = new Rectangle(0, 0, 300, 230);
            LinearGradientBrush b = new LinearGradientBrush(rect, Color.DarkOrange, nyc, LinearGradientMode.Vertical);
            g.FillRectangle(b, rect);
            Font ff = new Font("Arial", 14, FontStyle.Bold);
            SolidBrush bb = new SolidBrush(nyc);
            StringFormat df = new StringFormat();
        }
        void draw(object ob, EventArgs a)
        {
            l.Location = new Point(x, y);
            --y;
            if (y == -100) y = 230;
        }
    }
    public static void Main()
    {
        Application.Run(new shesharp());
    }
}
