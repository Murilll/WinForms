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

var xRetangulo = 0;
var yRetanguloSprite2 = form.Bottom;

Image newImage = Image.FromFile("image/sonic.png");

int xSprite1 = 400;
int xSprite2 = 15;

var tm = new Timer();
tm.Interval = 20;
tm.Tick += delegate
{
    Rectangle retanguloSprite2 = new Rectangle(600, 400, 50, 50);

    Rectangle retangulo = new Rectangle(xRetangulo, 400, 50, 50);
    if (xRetangulo >= form.Width)
        xRetangulo = 0;

    if (yRetanguloSprite2 >= form.Bottom)
        yRetanguloSprite2 = form.Height;

    if (xSprite1 >= 750)
        xSprite1 = 400;

    if (xSprite2 >= 398)
        xSprite2 = 15;
        
    g.Clear(Color.White);
    pb.Refresh();
    int ySprite1 = 235;
    int widthSprite1 = 34;
    int heightSprite1 = 38;

    int ySprite2 = 548;
    int widthSprite2 = 34;
    int heightSprite2 = 38;
    GraphicsUnit units = GraphicsUnit.Pixel;

    xSprite1 = xSprite1 + 34 + 16;
    xSprite2 = xSprite2 + 36 + 16;

    yRetanguloSprite2 -= 7; 
    xRetangulo += 7;

    g.DrawImage(newImage, retangulo, xSprite1, ySprite1, widthSprite1, heightSprite1, units);
    g.DrawImage(newImage, retanguloSprite2, xSprite2, ySprite2, widthSprite2, heightSprite2, units);
    pb.Refresh();
};

form.Load += delegate
{
    bmp = new Bitmap(pb.Width, pb.Height);
    g = Graphics.FromImage(bmp);
    
    pb.Image = bmp;
    tm.Start();
};

form.KeyPreview = true;
form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Application.Run(form);