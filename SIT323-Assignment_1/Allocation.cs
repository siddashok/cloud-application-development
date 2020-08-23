using System;
using System.Collections.Generic;

namespace SIT323_Assignment
{
    public class Allocation
    {
        public string id = "";
        public int[,] allocation;
        public int task;
        public int processor;
        public bool valid;
        public List<string> errorList = new List<string>();

        public Allocation(int i, int j)
        {
            allocation = new int[i,j];
            processor = i;
            task = j;
        }
        public void SetAllocation(int i, int j, string value)
        {
            int k = int.Parse(value);
            allocation[i,j] = k;
        }
        public bool Check()
        {
            valid = true;
            int num = 0;
            for (int j = 0; j < task; j++)
            {
                int k = 0;
                for (int i = 0; i < processor; i++)
                {
                    if (allocation[i, j] == 0 || allocation[i, j] == 1)
                    {
                        if (allocation[i, j] == 1)
                        {
                            num++;
                            k++;
                        }
                    }
                    else
                    {
                        errorList.Add("Error: The number in allocation(ID = "+ id +") must be 1 or 0.");
                        valid = false;
                    }
                }
                if (k > 1)
                {
                    errorList.Add("Error: a task(TaskID = "+ (j + 1)+") in an allocation (ID = "
                        + id +") has been allocated to 2 processors instead of 1.");
                    valid = false;
                }
            }
            if (num != task)
            {
                errorList.Add("Error: Allocation(ID = "+ id + ") has " + num.ToString() + " tasks, but " 
                    + task.ToString() + " are expected.");
                valid = false;
            }
            return valid;
        }
        public void OutputAllocation(TaskHome temp)
        {
            for (int i = 0; i < processor; i++)
            {
                for (int j = 0; j < task; j++)
                {
                    if (j == task - 1)
                        temp.textBox1.Text += allocation[i, j] + "\r\n\r\n";
                    else
                        temp.textBox1.Text += allocation[i, j] + ",";
                }
            }
            temp.textBox1.Text += "\r\n\r\n";
        }


    }
}
