using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace AdvancedWindowsService
{
    public interface IServiceForm
    {
        event EventHandler StartServiceClick;
        event EventHandler StopServiceClick;
        string WorkingPanelContent { get; set; }
        string WatchingDirectory { set; }
        string ArchiveFileDirectory { set; }
    }

    public partial class ServiceForm : Form, IServiceForm        
    {

        #region IServiceForm

        public string ArchiveFileDirectory
        {
            set { ArchiveFileDirectoryName.Text = value; }
        }

        public string WatchingDirectory
        {
            set { WatchingDirectoryName.Text = value; }
        }

        public string WorkingPanelContent
        {
            get { return this.WorkingPanelTextBox.Text; }
            set
            {
                Action action = () => { WorkingPanelTextBox.Text = value; };
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            }
        }

        public event EventHandler StartServiceClick;
        public event EventHandler StopServiceClick;
        #endregion

        public ServiceForm()
        {
            InitializeComponent();
            Start_Button.Click += Start_Button_Click;
            Stop_Button.Click += Stop_Button_Click;
            Start_Button.Enabled = false;
            //Stop_Button.Enabled = false;
        }

        private void Stop_Button_Click(object sender, EventArgs e)
        {
            Start_Button.Enabled = true;
            Stop_Button.Enabled = false;     
            StopServiceClick?.Invoke(this, EventArgs.Empty);
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            WorkingPanelTextBox.Text = "Starting service...";
            Stop_Button.Enabled = true;
            Start_Button.Enabled = false;
            StartServiceClick?.Invoke(this, EventArgs.Empty);
        }

    }
}
