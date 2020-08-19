
namespace Konvolucio.MCAN120803.GUI.AppModules.Main.View
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Statistics.Message.View;
    using Properties;
    using WinForms.Framework;

    public interface IMainForm: IWindowLayoutRestoring
    {
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;
       
        event EventHandler Shown;
        event KeyEventHandler KeyUp;
        event HelpEventHandler HelpRequested; /*????*/

        string Text { get; set; }

        void Close();

        ITraceSenderView TraceAndPagesView { get; }
        KnvTreeView TreeView { get; }
        ToolStrip TreeToolStrip { get; }
        DockStyle Dock { get; set; }
        IStatisticsGridView StatisticsView { get; }
        void ShowTraceView(ToolStripMenuItem[] menuItems);
        void ShowStatisticsView(ToolStripMenuItem[] menuItems);

        void CursorWait();
        void CursorDefault();
    }

    public partial class MainForm : Form,  IMainForm
    {
        private readonly TraceSenderView _traceAndPagesView;
        private readonly StatisticsGridView _statisticsGridView;

        public ITraceSenderView TraceAndPagesView => _traceAndPagesView;


        public KnvTreeView TreeView => treeView1;
        public ToolStrip TreeToolStrip => toolStrip2;
        public IStatisticsGridView StatisticsView => _statisticsGridView;
        //public ToolStrip MainToolStrip => toolStrip1;

        public new string Text
        {
            get { return base.Text; }
            set
            {
                value += " " + Application.ProductVersion;
                if (InvokeRequired)
                    this.Invoke((MethodInvoker)delegate{ base.Text = value; });
                else
                    base.Text = value;
            }
        }
        
        readonly Timer readyTimer;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            readyTimer = new Timer();
            readyTimer.Interval = 2000;
            readyTimer.Tick += new EventHandler(readyTimer_Tick);
        }

        void readyTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }



        /// <summary>
        /// Defaultban ezt történik
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Mensd a ennek a vezérlő állapotát
        /// </summary>
        public void LayoutSave()
        {
            Settings.Default.MainFormLocation = Location;
            Settings.Default.MainFormWindowState = WindowState;
            Settings.Default.MainFormSize = Size;
        }
        /// <summary>
        /// Állisd vissza ennek a vezélrlőnek az állapotát
        /// </summary>
        public void LayoutRestore()
        {
            Location = Settings.Default.MainFormLocation;
            WindowState = Settings.Default.MainFormWindowState;
            Size = Settings.Default.MainFormSize;
        }
        public void ShowStatisticsView(ToolStripMenuItem[] menuItems)
        {
           
            if (!splitContainerMainTree.Panel2.Controls.Contains(_statisticsGridView))
            { /*Nem villog*/
                splitContainerMainTree.Panel2.Controls.Clear();
                splitContainerMainTree.Panel2.Controls.Add(_statisticsGridView);
            }
        }

        public void ShowTraceView(ToolStripMenuItem[] menuItems)
        {
            if (!splitContainerMainTree.Panel2.Controls.Contains(_traceAndPagesView))
            { 
                splitContainerMainTree.Panel2.Controls.Clear();
                splitContainerMainTree.Panel2.Controls.Add(_traceAndPagesView);
            }

            splitContainerMainTree.Panel2.Controls.Clear();
            splitContainerMainTree.Panel2.Controls.Add(_traceAndPagesView);
        }

        public void CursorWait()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public void CursorDefault()
        {
            Cursor.Current = Cursors.Default;
        }
    }
}

