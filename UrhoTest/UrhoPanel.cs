using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Urho;
using Urho.Desktop;

namespace UrhoTest
{
    public partial class UrhoPanel : Form
    {
        Urho.Application currentApplication;
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

        MySample f;

        public UrhoPanel()
        {
            InitializeComponent();
            DesktopUrhoInitializer.AssetsDirectory = @"../../../../Assets";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // todo: 3 This method hangs the app when closing, fix.
            f = new MySample(new ApplicationOptions("Data") { });
            f.Run();
            f?.Engine.Exit();
        }

        async private void button2_Click(object sender, EventArgs e)
        {            
            currentApplication?.Engine.Exit();
            currentApplication = null;
            await semaphoreSlim.WaitAsync();

            urhoSurfacePlaceholder.Controls.Clear(); //urho will destroy previous control so we have to create a new one
            var urhoSurface = new Panel { Dock = DockStyle.Fill };
            urhoSurfacePlaceholder.Controls.Add(urhoSurface);
            await Task.Delay(100);//give some time for GC to cleanup everything
            currentApplication = Urho.Application.CreateInstance(typeof(MySample), new ApplicationOptions("Data") { ExternalWindow = urhoSurface.Handle });
            urhoSurface.Focus();
            currentApplication.Run();
            semaphoreSlim.Release();
        }

        async private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentApplication?.Engine.Exit();
            currentApplication = null;
            await semaphoreSlim.WaitAsync();

            f?.Engine.Exit();
        }

        async private void Form1_Load(object sender, EventArgs e)
        {
            currentApplication?.Engine.Exit();
            currentApplication = null;
            await semaphoreSlim.WaitAsync();

            urhoSurfacePlaceholder.Controls.Clear(); //urho will destroy previous control so we have to create a new one
            var urhoSurface = new Panel { Dock = DockStyle.Fill };
            urhoSurfacePlaceholder.Controls.Add(urhoSurface);
            await Task.Delay(100);//give some time for GC to cleanup everything
            currentApplication = Urho.Application.CreateInstance(typeof(MySample), new ApplicationOptions("Data") { ExternalWindow = urhoSurface.Handle });
            urhoSurface.Focus();
            currentApplication.Run();
            semaphoreSlim.Release();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((MySample)currentApplication).y_speed = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((MySample)currentApplication).y_speed = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((MySample)currentApplication).y_speed = -1;
        }
    }
}
