using System;
using System.IO;
using System.Windows.Forms;

namespace SIT323_Assignment
{
    public partial class TaskHome : Form
    {

        public static TaskAllocation task_allocation;
        public static Configuration task_config;
        public static ErrorList task_error;
        bool CheckCFF;
        public TaskHome()
        {
            task_error = new ErrorList();
            InitializeComponent();
        }
        
        private void File_open_click(object sender, EventArgs e)
        {
            OpenFileDialog TAFFFile = new OpenFileDialog() 
            {
                Multiselect = false,
                Filter = "(*.taff) | *.taff"
            };

            try
            {
                if (TAFFFile.ShowDialog() == DialogResult.OK)
                {

                    task_allocation = new TaskAllocation();
                    task_config = new Configuration();

                    string Address = TAFFFile.FileName;
                    task_error.textBoxForm.Text = "";
                    this.textBox1.Text = "";

                    task_error.textBoxForm.Text += Address.Replace(Path.GetDirectoryName(Address) + "\\", String.Empty) + "\r\n";
                    //Check TAN file
                    if (task_allocation.IsValid(Address))
                    {
                        textBox1.Text += "TAFF file is valid.\r\n";
                    }
                    else
                    {
                        textBox1.Text += "TAFF file is invalid.\r\n";
                        foreach (string value in task_allocation.errorList)
                        {
                            task_error.textBoxForm.Text += value + "\r\n";
                        }
                    }
                    task_error.textBoxForm.Text += Address.Replace(Path.GetDirectoryName(Address) + "\\", String.Empty) + "\r\n";

                    
                    if (task_allocation.lostCFFName)//To check whether the CFF file is missing
                    {
                        task_error.textBoxForm.Text += "CFF Filename is missing\r\n";
                    }
                    else
                    {
                        task_error.textBoxForm.Text += task_allocation.GetCffPath().Replace(Path.GetDirectoryName(Address) + "\\", String.Empty) + "\r\n";
                    }

                    CheckCFF = task_config.IsValid(task_allocation.GetCffPath());
                    
                    if (CheckCFF)//Check the CFF file: valid or invalid
                    {
                        textBox1.Text += "Configuration file is valid.\r\n";
                    }
                    else
                    {
                        textBox1.Text += "Configuration file is invalid.\r\n";
                        foreach (string s in task_config.errorList)
                        {
                            task_error.textBoxForm.Text += "\t" + s + "\r\n";
                        }
                    }
                    if (task_allocation.lostCFFName)
                    {
                        task_error.textBoxForm.Text += "ERROR: Configuration File\r\n";
                    }
                    else
                    {
                        task_error.textBoxForm.Text += "ERROR:" + task_allocation.GetCffPath().Replace(Path.GetDirectoryName(Address) + "\\", String.Empty) + "\r\n";
                    }

                    MenuItem_Validate_Allocations.Enabled = true;
                }
            }
            catch (Exception A)
            {
                MessageBox.Show(A.Message);
            }
        }
        private void Error_open_click(object sender, EventArgs e)
        {
            task_error.Show();
        }
        private void ValidateAllocation_open_click(object sender, EventArgs e)
        {
            if (!task_allocation.ReturnCheckTimes())//this function will return the times. 
            {
                if (CheckCFF)
                {
                    task_config.CheckRunTime();
                }
                textBox1.Text += "Allocation:\r\n";
                //Output the runtime and the energy
                int taskID = 0;
                foreach (Allocation Value in task_allocation.List)
                {
                    if (!Value.valid)//allocation wrong
                    {
                        textBox1.Text += "ID = " + task_allocation.ID[taskID] + " is invalid.\r\n";
                    }
                    else if (!CheckCFF)//CFF file invalid
                    {
                        textBox1.Text += "ID = " + task_allocation.ID[taskID] + ", Time = Invalid, Energy = Invalid\r\n";
                    }
                    else// Error
                    {
                        string ID = "ID = " + task_allocation.ID[taskID];
                        string Time = " ,Time = " + Math.Round(task_config.RunTime(Value), 4);
                        string Energy = " ,Energy = " + Math.Round(task_config.Energy(Value), 4);
                        textBox1.Text += ID + Time + Energy + "\r\n";
                    }
                    Value.OutputAllocation(this);
                    taskID++;
                }
            }
        }
        private void Help_open_click(object sender, EventArgs e)
        {
            AboutBox1 form3 = new AboutBox1();
            form3.ShowDialog();
        }
        private void Exit_click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
