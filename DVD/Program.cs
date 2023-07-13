using System;
using System.Windows.Forms;
using System.Drawing;

ApplicationConfiguration.Initialize();

var form = new Form();

form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.Fixed3D;

// PictureBox pg = new PictureBox();
// pg.Dock = DockStyle.Fill;
// pg.Image = Image.FromFile("logoJequiti.jpg");
// pg.SizeMode = PictureBoxSizeMode.Zoom;
// form.Controls.Add(pg);

Panel pn = new Panel();
Panel Base = new Panel();

Base.Width = 50;
Base.Height = 50;

pn.BackColor = Color.Pink;
Base.BackColor = Color.Black;

form.Controls.Add(pn);
form.Controls.Add(Base);

form.BackColor = Color.AliceBlue;
// form.TransparencyKey = Color.AliceBlue;

int flagX = 10;
int flagY = 10;

Random random = new Random();

var tm = new Timer();
tm.Interval = 1;
tm.Tick += delegate
{
    var x = pn.Location.X;
    var y = pn.Location.Y;

    if (pn.Location.X >= form.Width - pn.Width || pn.Location.X < 0)
    {
        flagX *= -1;
        pn.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), 0);
    }

    else if (pn.Location.Y < 0 || pn.Location.Y >= form.Height - pn.Height)
    {
        flagY *= -1;
        pn.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), 0);
    }

    x -= Base.Location.X;
    y -= Base.Location.Y;


    if (pn.Location.Y == Base.Location.Y && pn.Location.X == Base.Location.X)
    {
        // flagY *= -1;
        pn.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), 0);
    }

    x += flagX;
    y += flagY;

    pn.Location = new Point(x, y);
};


var xBase = Base.Location.X;
var yBase = Base.Location.Y;

form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Up)
    {
        yBase -= 20;
    }

    Base.Location = new Point(xBase, yBase);
};

form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Down)
    {
        yBase += 20;
    }

    Base.Location = new Point(xBase, yBase);
};

form.KeyDown += (s, e) =>
{

    if (e.KeyCode == Keys.Right)
    {
        xBase += 20;
    }

    Base.Location = new Point(xBase, yBase);
};

form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Left)
    {
        xBase -= 20;
    }

    Base.Location = new Point(xBase, yBase);
};

form.Load += delegate
{
    form.Show();
    tm.Start();
};

Application.Run(form);

// var show = false;
// var timer = new Timer();
// timer.Interval = 200;
// timer.Tick += delegate
// {
//     var rand = Random.Shared;
//     if(show)
//     {
//         form.Hide();
//         show = false;
//     }

//     if(rand.Next(100) < 2)
//     {
//         form.Show();
//         show = true;
//     }
// };

// form.Load += delegate
// {
//     form.Hide();
//     timer.Start();
// };

// var bt = new Button();
// bt.Width = 200;
// bt.Text = "Olá, Windows Forms !";
// bt.Anchor = AnchorStyles.Right | AnchorStyles.Left;
// form.Controls.Add(bt);

// form.KeyPreview = true;
// form.KeyDown +=  (s, e) =>
// {
//     if(e.KeyCode == Keys.Escape)
//         Application.Exit();
// };

