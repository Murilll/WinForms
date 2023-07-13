private Image picture;
private Point pictureLocation;

public Form1()
{
   this.AllowDrop = true;
   this.DragDrop += new DragEventHandler(this.Form1_DragDrop);
   this.DragEnter += new DragEventHandler(this.Form1_DragEnter);
}

protected override void OnPaint(PaintEventArgs e)
{
   base.OnPaint(e);
   if(this.picture != null && this.pictureLocation != Point.Empty)
   {
      e.Graphics.DrawImage(this.picture, this.pictureLocation);
   }
}

private void Form1_DragDrop(object sender, DragEventArgs e)
{
   if(e.Data.GetDataPresent(DataFormats.FileDrop) )
   {
      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
      try
      {
         this.picture = Image.FromFile(files[0]);
         this.pictureLocation = this.PointToClient(new Point(e.X, e.Y) );
      }
      catch(Exception ex)
      {
         MessageBox.Show(ex.Message);
         return;
      }
   }

   if(e.Data.GetDataPresent(DataFormats.Bitmap) )
   {
      try
      {
         this.picture = (Image)e.Data.GetData(DataFormats.Bitmap);
         this.pictureLocation = this.PointToClient(new Point(e.X, e.Y) );
      }
      catch(Exception ex)
      {
         MessageBox.Show(ex.Message);
         return;
      }
   }

   this.Invalidate();
}

private void Form1_DragEnter(object sender, DragEventArgs e)
{
   if (e.Data.GetDataPresent(DataFormats.Bitmap) || 
      e.Data.GetDataPresent(DataFormats.FileDrop) ) 
   {
      e.Effect = DragDropEffects.Copy;
   }
   else
   {
      e.Effect = DragDropEffects.None;
   }
}