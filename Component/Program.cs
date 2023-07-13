using System;
using System.Windows.Forms;
using System.Drawing;

ApplicationConfiguration.Initialize();

var form = new Form();

form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.Fixed3D;

Panel pn = new Panel();

TextBox labelName = new TextBox();
labelName.Location = new System.Drawing.Point(8, 8);
labelName.Size = new System.Drawing.Size(112, 23);
labelName.Text = "Name:";
form.Controls.Add(labelName);

TextBox textEmail = new TextBox();
textEmail.Location = new System.Drawing.Point(120, 104);
textEmail.Size = new System.Drawing.Size(232, 20);
textEmail.TabIndex = 6;
labelName.Text = "Email:";
form.Controls.Add(textEmail);

// pg.Image = Image.FromFile("logoJequiti.jpg");
// pg.SizeMode = PictureBoxSizeMode.Zoom;
// form.Controls.Add(pg);



form.Load += delegate
{
    form.Show();
};

Application.Run(form);
