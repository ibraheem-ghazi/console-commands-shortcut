using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Forms;
using ConsoleCommandsShortcut.Helpers;
using ConsoleCommandsShortcut.Structs;
using ExtensionMethods;

namespace ConsoleCommandsShortcut
{
    public partial class Form1 : Form
    {

        private BindingList<ConsoleCommand> tableContentList ;

        private static bool IsDirty = false;

        public Form1()
        {
            InitializeComponent();

            // init table content
            tableContentList = GeneralHelper.LoadData<BindingList<ConsoleCommand>>() ?? new BindingList<ConsoleCommand>();

            //set tableContentList as table data source
            dgv_table_view.SetDataSource(tableContentList);

            //if any value changed set set app as dirty to prompt user for save
            dgv_table_view.CellValueChanged += (object sender, DataGridViewCellEventArgs e) => { IsDirty = true; };
            dgv_table_view.CurrentCellDirtyStateChanged += (object sender, EventArgs e) => { IsDirty = true; };

            //inform user where does the commands are loaded
            label2.Text = "Commands are loaded from: " + GeneralHelper.IncludePath;

            //if include commands path is not created or not in PATH Environment variable then create and add it
            GeneralHelper.CheckIncludePath();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv_table_view.DeleteCurrentRow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GeneralHelper.SaveData(tableContentList);
            
            foreach(ConsoleCommand console_cmd in tableContentList)
            {
                if (console_cmd.Enable)
                {
                    CommandsHelper.ActivateCommand(console_cmd);
                }
                else
                {
                    CommandsHelper.DeactivateCommand(console_cmd);
                }
            }

            MessageBox.Show(null, "Commands Has Been Saved", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            IsDirty = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDirty)
            {
                DialogResult result = MessageBox.Show(null, "You have unsaved edits, Do you want to save them ?", "Unsaved Modifications", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                switch (result)
                {
                    case DialogResult.Cancel: e.Cancel = true; break;
                    case DialogResult.No:  break;
                    case DialogResult.Yes: GeneralHelper.SaveData(tableContentList); break;
                }
            }
        }
    }
}

