﻿// -----------------------------------------------------------------------
// <copyright file="AddMessageFilter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Konvolucio.WinForms.Framework.DataGridViewControl.UnitTest.Commands
{
    using System.ComponentModel;
    using System.Windows.Forms;

    using Properties;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal sealed class CutRowsCommand : KnvDataGridViewCutRowsBaseCommand
    {
        public CutRowsCommand(DataGridView dataGridView, IBindingList collection)  : base(dataGridView, collection)
        {
            Text = @"Cut";
        }
    }
}
