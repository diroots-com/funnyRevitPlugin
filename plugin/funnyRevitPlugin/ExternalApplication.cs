using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using funnyRevitPlugin;
using System.Drawing;

namespace funnyRevitPlugin
{
    class ExternalApplication : IExternalApplication
    {
        // method create our tab and button
        static void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "Be Smart";
            application.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Try me");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            
            // create push button for CurveTotalLength
            PushButtonData b1Data = new PushButtonData("button1",
        "Use Plugins", thisAssemblyPath, "funnyRevitPlugin.YouReSmart");

            PushButton pb1 = ribbonPanel.AddItem(b1Data) as PushButton;
            pb1.ToolTip = "Use plugins to improve your workflow";
            BitmapImage pb1Image = new BitmapImage(new Uri(@"\images\question_16x16.png")); // this is the button's image and you must change the path
            pb1.LargeImage = pb1Image;
        }
        
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonPanel(application);
            return Result.Succeeded;
        }
    }
}
