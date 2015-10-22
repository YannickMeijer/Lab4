using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class ShapeDrawingForm : Form
{
	private List<Shape> shapes;

	public ShapeDrawingForm()
	{
        MenuStrip menuStrip;
        menuStrip = new MenuStrip();

        ToolStripDropDownItem menu;
        menu = new ToolStripMenuItem("File");
		menu.DropDownItems.Add("Open...", null, this.openFileHandler);
		menu.DropDownItems.Add("Export...", null, this.exportHandler);
        menu.DropDownItems.Add("Exit", null, this.closeHandler);
        menuStrip.Items.Add(menu);

        this.Controls.Add(menuStrip);
		// Some basic settings
		Text = "Shape Drawing and Converter";
		Size = new Size(400, 400);
		CenterToScreen();
		SetStyle(ControlStyles.ResizeRedraw, true);
		
		// Initialize shapes
        shapes = new List<Shape>();
		
		// Listen to Paint event to draw shapes
		this.Paint += new PaintEventHandler(this.OnPaint); 
	}

    // What to do when the user closes the program
    private void closeHandler(object sender, EventArgs e)
    {
        this.Close();
    }

    // What to do when the user opens a file
    private void openFileHandler(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "";
        dialog.Title = "Open file...";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            shapes = Parser.ParseShapes(dialog.FileName);
            this.Refresh();
        }

    }

    // What to do when the user wants to export a SVG file
	private void exportHandler (object sender, EventArgs e)
	{
		Stream stream;
		SaveFileDialog saveFileDialog = new SaveFileDialog();

		saveFileDialog.Filter = "SVG files|*.svg";
		saveFileDialog.RestoreDirectory = true;
		
		if(saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			if((stream = saveFileDialog.OpenFile()) != null)
			{
                // Insert code here that generates the string of SVG
                //   commands to draw the shapes

                String SVGtext = "<?xml version=\"1.0\" standalone=\"no\"?>" +
                    "\r\n<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"" +
                    "\r\n\"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">" +
                    "\r\n<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">";
                foreach (Shape shape in shapes)
                {
                    SVGtext = SVGtext + shape.Conversion();
                }
                SVGtext = SVGtext + "\r\n</svg>";
                    using (StreamWriter writer = new StreamWriter(stream))
                {
                        // Write strings to the file here using:
                        writer.WriteLine(SVGtext);
                }				
			}
		}
	}

    private void OnPaint(object sender, PaintEventArgs e)
	{
		// Draw all the shapes
		foreach(Shape shape in shapes)
			shape.Draw(e.Graphics);
	}

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // ShapeDrawingForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ShapeDrawingForm";
            this.Load += new System.EventHandler(this.ShapeDrawingForm_Load);
            this.ResumeLayout(false);

    }

    private void ShapeDrawingForm_Load(object sender, EventArgs e)
    {

    }
}