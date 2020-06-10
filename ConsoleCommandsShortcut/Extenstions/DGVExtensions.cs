using System.ComponentModel;
using System.Windows.Forms;
namespace ExtensionMethods
{
    public static class DGVExtensions
    {
        public static void DeleteCurrentRow(this DataGridView dgv_table_view)
        {
            if (dgv_table_view.CurrentRow != null)
            {
                (dgv_table_view.DataSource as IBindingList).Remove(dgv_table_view.CurrentRow.DataBoundItem);
            }
            else if (dgv_table_view.SelectedCells.Count == 1)
            {
                MessageBox.Show(null, "There should be at least one command", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(null, "Select command first!", "No command selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void SetDataSource(this DataGridView dgv_table_view,IBindingList tableContentList)
        {
            dgv_table_view.DataSource = new BindingSource(tableContentList, null);
        }
    }
}