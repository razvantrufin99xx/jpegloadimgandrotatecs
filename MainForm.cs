/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 9/28/2024
 * Time: 6:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace jpegloadimgandrotateit
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			ImageRotator();
		}
		   private PictureBox pictureBox;
    private Bitmap bitmap;

    public void ImageRotator()
    {
        // Initialize the PictureBox
        pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.Zoom
        };
        this.Controls.Add(pictureBox);

        // Load the image
        LoadImage("j.jpg");

        // Create buttons for rotating left and right
        Button rotateLeftButton = new Button { Text = "Rotate Left", Dock = DockStyle.Left };
        rotateLeftButton.Click += (sender, e) => RotateImage(RotateFlipType.Rotate270FlipNone);

        Button rotateRightButton = new Button { Text = "Rotate Right", Dock = DockStyle.Right };
        rotateRightButton.Click += (sender, e) => RotateImage(RotateFlipType.Rotate90FlipNone);

        this.Controls.Add(rotateLeftButton);
        this.Controls.Add(rotateRightButton);
    }

    private void LoadImage(string path)
    {
        try
        {
            bitmap = new Bitmap(path);
            pictureBox.Image = bitmap;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading image: {ex.Message}");
        }
    }

    private void RotateImage(RotateFlipType rotateFlipType)
    {
        if (bitmap != null)
        {
            bitmap.RotateFlip(rotateFlipType);
            pictureBox.Image = bitmap;
        }
    }
	}
}
