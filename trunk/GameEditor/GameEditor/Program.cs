using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Org.Mentalis.Utilities;

namespace GameEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ///////////////// ASSOCIATE IT WITH REGISTRY ////////////////////
            string fileName = null;
            for (int i = 0; i < args.Length; i++)
            {
                fileName = args[i];
            }
            GameEditor.m_GfxFilePath = fileName;

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileAssociation FA = new FileAssociation();
            FA.Extension = "gfx";
            FA.ContentType = "application/GameEditor";
            FA.FullName = "GFX Files!";
            FA.ProperName = "GFX File";
            FA.AddCommand("open", path + " %1");
            FA.IconPath = path;
            FA.IconIndex = 0;       //Icon data in exe always ate the begining with index 0
            FA.Create();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameEditor());
        }
    }
}
