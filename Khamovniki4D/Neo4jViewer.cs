using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using CefSharp;
using CefSharp.WinForms;

namespace Khamovniki4D
{
    public partial class Neo4jViewer : Form
    {
        private ChromiumWebBrowser browser;
        public Neo4jViewer(string uri= "http://localhost:7474")
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser(uri);
            container.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            Height = SystemInformation.PrimaryMonitorSize.Height - 30;
            Width = SystemInformation.PrimaryMonitorSize.Width;
            StartPosition= FormStartPosition.Manual; 
            DesktopLocation = new Point(Width/2, 0);
            Width = Width / 2;
        }
    }
}
