
namespace Konvolucio.MCAN120803.GUI.AppModules.Options.View
{
    using System.Windows.Forms;

    using Common;
    using DataStorage;
    using WinForms.Framework;

    public partial class ProjectlCustomArbIdColumnsView : UserControl, IOptionPage
    {
        public bool RequiedRestart
        {
            get { return false; }
        }

        public bool RequiedDefault
        {
            get { return false; }
        }


        public ProjectlCustomArbIdColumnsView()
        {
            InitializeComponent();
            knvDataGridView1.KnvColumnHeaderContextMenu();
            columnType.ValueType = typeof(ArbitrationIdType);
            columnType.Items.AddRange(ArbitrationIdType.Extended, ArbitrationIdType.Standard);

            knvDataGridView1.DataBindingComplete += (o, e1) =>
            {
                knvDataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            };

        }


        public void UpdateValues()
        {
        }

        public void Save()
        {

        }

        public void Defualt()
        {

        }
    }
}
