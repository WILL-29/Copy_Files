using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Copy_Files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string SourcePath = Environment.CurrentDirectory;
            string SourcePath = @"C:\Fim5";
            var SourcePathInfo = new DirectoryInfo(SourcePath); 
            
            var DestPath = @"C:\Users\WILL\Desktop\Prueba";
            DirectoryInfo DestPathInfo = new DirectoryInfo(DestPath);
            
            void CopyFiles(DirectoryInfo Source, DirectoryInfo Destination)
            {
                Directory.CreateDirectory(Destination.FullName);
                foreach (FileInfo file in Source.GetFiles())
                {
                    file.CopyTo(Path.Combine(Destination.FullName, file.Name), true);
                }
                foreach (var SourceSubDirectory in Source.GetDirectories())
                {
                    var DestinationSubDirectory = Destination.CreateSubdirectory(SourceSubDirectory.Name);
                    CopyFiles(SourceSubDirectory, DestinationSubDirectory);
                }
          
            }

            CopyFiles(SourcePathInfo, DestPathInfo);
        }
    }
}
