using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

ApplicationConfiguration.Initialize();

var form = new Form();

form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

Graphics g = null;
Bitmap bmp = null;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);

Point cursor = Point.Empty;
pb.MouseMove += (s, e) =>
{
    cursor = e.Location;
};

Queue<DateTime> queue = new Queue<DateTime>();
queue.Enqueue(DateTime.Now);

var tm = new Timer();
tm.Interval = 20;
tm.Tick += delegate
{
    g.Clear(Color.White);
    var now = DateTime.Now;
    queue.Enqueue(now);
    if (queue.Count > 19)
    {
        DateTime old = queue.Dequeue();
        var time = now - old;
        var fps = (int)(19 / time.TotalSeconds);
        var drawFont = new Font("Arial", 16);
        PointF drawPoint = new PointF(150.0F, 150.0F);
        g.DrawString($"{fps} fps", drawFont, Brushes.Black, drawPoint);
    }

    pb.Refresh();
};

form.Load += delegate
{
    bmp = new Bitmap(pb.Width, pb.Height);
    g = Graphics.FromImage(bmp);
    g.Clear(Color.Red);
    pb.Image = bmp;
    tm.Start();
};

private void DrawImageRect4Int(PaintEventArgs e)
{      
    Image newImage = Image.FromFile("SampImag.jpg");
    Rectangle destRect = new Rectangle(100, 100, 450, 150);

    int x = 50;
    int y = 50;
    int width = 150;
    int height = 150;
    GraphicsUnit units = GraphicsUnit.Pixel;
             
    e.Graphics.DrawImage(newImage, destRect, x, y, width, height, units);
}

form.KeyPreview = true;
form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Application.Run(form);