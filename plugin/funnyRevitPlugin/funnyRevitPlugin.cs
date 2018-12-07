using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace funnyRevitPlugin
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class YouReSmart : IExternalCommand
    {
        public void CreateMyForm()
        {
            // Create a new instance of the form.
            System.Windows.Forms.Form form1 = new System.Windows.Forms.Form();

            Size formSize = new Size(750, 585);

            // Creates PictureBox and Image to display
            PictureBox pictureBox1 = new PictureBox();
            Image image1 = new Bitmap(@"\images\smartHomer.gif"); // this is the gif and you must change the path
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ClientSize = new Size(735, 540);
            pictureBox1.Image = image1;

            form1.Size = formSize;
            
            // Set the caption bar text of the form.   
            form1.Text = "Using plugins to improve your workflow?";
            // Display a help button on the form.
            form1.HelpButton = true;

            // Define the border style of the form to a dialog box.
            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            form1.MaximizeBox = true;
            // Set the MinimizeBox to false to remove the minimize box.
            form1.MinimizeBox = true;

            // Set the start position of the form to the center of the screen.
            form1.StartPosition = FormStartPosition.CenterScreen;

            // Add Image 
            form1.Controls.Add(pictureBox1);

            // Display the form as a modal dialog box.
            form1.ShowDialog();
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            CreateMyForm();
            return Result.Succeeded;
        }
        
    }


}
