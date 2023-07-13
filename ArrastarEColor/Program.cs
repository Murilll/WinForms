using System;
using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form();

// form.WindowState = FormWindowState.Maximized;
// form.FormBorderStyle = FormBorderStyle.None;

Panel pn = new Panel();
pn.Height = 100;
pn.Width = 100;
pn.Left = 100;
pn.Top = 100;
pn.BackColor = Color.Blue;
form.Controls.Add(pn);



Point? p = null;
var bt = new Button();
bt.Text = "Xispita!!";
bt.MouseMove += (s, e) =>
{
    if (p is null)
        return;

    var dx = e.Location.X - p.Value.X;
    var dy = e.Location.Y - p.Value.Y;
    bt.Location = new Point(
        bt.Location.X + dx,
        bt.Location.Y + dy
    );
};
bt.MouseDown += (s, e) =>
{
    p = e.Location;
};
bt.MouseUp += (s, e) =>
{
    p = null;
};
form.Controls.Add(bt);

var tm = new Timer();
tm.Interval = 100;
tm.Tick += delegate
{
    var xBT = bt.Location.X;
    var yBT = bt.Location.Y;

    if (pn.Location.X > xBT && pn.Location.Y < yBT)
    {
        if (pn.Location.X - pn.Width < xBT && pn.Location.Y - pn.Height > yBT)
        {
            pn.BackColor = Color.Red;
        }
    }

};

form.Load += delegate
{
    tm.Start();
};

form.KeyPreview = true;
form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Application.Run(form);