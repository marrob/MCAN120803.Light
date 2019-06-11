namespace Konvolucio.MCAN120803.GUI.AppModules.Main.View
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    using Properties;
    using WinForms.Framework;
    using Statistics.Message.View;

    public interface IMainView: IWindowLayoutRestoring
    {
        ITraceSenderView TraceAndPagesView { get; }
        KnvTreeView TreeView { get; }
        ToolStrip TreeToolStrip { get; }
        DockStyle Dock { get; set; }
        IStatisticsGridView StatisticsView { get; }

        void ShowTraceView(ToolStripMenuItem[] menuItems);

        void ShowWorkspaceView(ToolStripMenuItem[] menuItems);
        void ShowStatisticsView(ToolStripMenuItem[] menuItems);

    }

    public partial class MainView : UserControl, IMainView
    {
        public ITraceSenderView TraceAndPagesView => _traceAndPagesView;
        public KnvTreeView TreeView => treeView1;
        public ToolStrip TreeToolStrip => toolStrip2;
        public IStatisticsGridView StatisticsView => _statisticsGridView;
        public ToolStrip MainToolStrip => toolStrip1;

        private readonly TraceSenderView _traceAndPagesView;
        private readonly StatisticsGridView _statisticsGridView;



        public MainView()
        {
            InitializeComponent();
            _traceAndPagesView = new TraceSenderView(){ Dock = DockStyle.Fill };
            _statisticsGridView = new StatisticsGridView() {Dock = DockStyle.Fill,};

        }

        private void MainView_Load(object sender, EventArgs e)
        {
            splitContainerMainView.Panel2Collapsed = !Settings.Default.IsDeveloperMode;
            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);
        }

        void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName ==  PropertyPlus.GetPropertyName( () => Settings.Default.IsDeveloperMode ))
            { 
                splitContainerMainView.Panel2Collapsed = !Settings.Default.IsDeveloperMode;
            }
        }

        public void ShowTraceView(ToolStripMenuItem[] menuItems)
        {
            if (!splitContainerMainView.Panel1.Controls.Contains(splitContainerMainTree))
            {
                splitContainerMainView.Panel1.Controls.Clear();
                splitContainerMainView.Panel1.Controls.Add(splitContainerMainTree);
            }

            splitContainerMainTree.Panel2.Controls.Clear();
            splitContainerMainTree.Panel2.Controls.Add(_traceAndPagesView);

            MainToolStrip.Items.Clear();
            MainToolStrip.Items.AddRange(menuItems);

        }

        public void ShowLogView(ToolStripMenuItem[] menuItems)
        {
            if (!splitContainerMainView.Panel1.Controls.Contains(splitContainerMainTree))
            { /*Workspace-en volt előtte*/
                splitContainerMainView.Panel1.Controls.Clear();
                splitContainerMainView.Panel1.Controls.Add(splitContainerMainTree);
            }
            MainToolStrip.Items.Clear();
            MainToolStrip.Items.AddRange(menuItems);
        }

        public void ShowWorkspaceView(ToolStripMenuItem[] menuItems)
        {
            splitContainerMainView.Panel1.Controls.Clear();

            MainToolStrip.Items.Clear();
            MainToolStrip.Items.AddRange(menuItems);
        }

        public void ShowStatisticsView(ToolStripMenuItem[] menuItems)
        {
            if (!splitContainerMainView.Panel1.Controls.Contains(splitContainerMainTree))
            { /*Workspace-en volt előtte*/
                splitContainerMainView.Panel1.Controls.Clear();
                splitContainerMainView.Panel1.Controls.Add(splitContainerMainTree);
            }

            if (!splitContainerMainTree.Panel2.Controls.Contains(_statisticsGridView))
            { /*Nem villog*/
                splitContainerMainTree.Panel2.Controls.Clear();
                splitContainerMainTree.Panel2.Controls.Add(_statisticsGridView);
            }
            MainToolStrip.Items.Clear();
            MainToolStrip.Items.AddRange(menuItems);
        }


        public void LayoutSave()
        {
            Settings.Default.splitContainerMainView_SplitterDistance = splitContainerMainView.SplitterPrecent;
            Settings.Default.splitContainerMainTree_SplitterDistance = splitContainerMainTree.SplitterPrecent;
            TraceAndPagesView.LayoutSave();

        }

        public void LayoutRestore()
        {
            splitContainerMainView.SplitterPrecent = Settings.Default.splitContainerMainView_SplitterDistance;
            splitContainerMainTree.SplitterPrecent = Settings.Default.splitContainerMainTree_SplitterDistance;
            TraceAndPagesView.LayoutRestore();

        }

        private void splitContainerMainView_SplitterMoved(object sender, SplitterEventArgs e)
        {
 
        }

        private void splitContainerMainTree_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

    }
}
