using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SIT323_Assignment
{
    public class Configuration
    {
        public List<string> errorList = new List<string>();

        private bool valid;
        public string LogFile;
        public int Tasks_MIN;
        public int Tasks_MAX;
        public int Process_MIN;
        public int Process_MAX;
        public int Ram_MIN;
        public int Ram_MAX;
        public float Frequencies_MIN;
        public float Frequencies_MAX;
        private double duration;
        public int ProgramTasks;
        //public int PROCESSOR;
        private double Frequency;
        private float[,] runTime;
        private string[,] Process_ID;
        public double[,] Coefficient_ID;
        public int TASK;
        public int PROCESSOR;
        public int c_id = 0;

        public bool IsValid(string path)
        {
            StreamReader FileIn = new StreamReader(path);
            valid = true;
            // Search for file name.
            while (!FileIn.EndOfStream)
            {
                try
                {
                    String line = FileIn.ReadLine();
                    if (line.StartsWith("//"))
                    {
                        continue;
                    }
                    if (line == "")
                    {
                        continue;
                    }
                    //Match keyword
                    if (line.StartsWith("DEFAULT-LOGFILE"))
                    {

                        if (!line.Contains("="))
                        {
                            errorList.Add("Error:equal to sign is missing after keyword.");
                            valid = false;
                        }
                        else
                        {
                            string[] item = line.Split('=');
                            string KeyWord = item[0];
                            string Addr = item[1];
                            if (KeyWord != "DEFAULT-LOGFILE")
                            {
                                errorList.Add("Error: No DEFAULT-LOGFILE.");
                                valid = false;
                            }
                            LogFile = Addr;
                        }
                    }
                    else if (line.StartsWith("LIMITS-TASKS"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        string KeyWord = item[0];
                        string Min = item[1];
                        string Max = item[2];
                        if (!Int32.TryParse(Min, out Tasks_MIN) || !Int32.TryParse(Max, out Tasks_MAX))
                        {
                            errorList.Add("Error:TASKS number must be integer.");
                            valid = false;
                        }
                        else
                        {
                            if (Tasks_MAX < Tasks_MIN || Tasks_MIN < 1 || Tasks_MAX < 1)
                            {
                                errorList.Add("Error: LIMITS-TASKS Order Error.");
                                valid = false;
                            }
                        }
                    }
                    else if (line.StartsWith("LIMITS-PROCESSORS"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        string KeyWord = item[0];
                        string Min = item[1];
                        string Max = item[2];
                        if (!Int32.TryParse(Min, out Process_MIN) || !Int32.TryParse(Max, out Process_MAX))
                        {
                            errorList.Add("Error:Processor must be integer.");
                            valid = false;
                        }
                        else
                        {
                            if (Process_MAX < Process_MIN || Process_MIN < 1 || Process_MAX < 1)
                            {
                                errorList.Add("Error: PROCESSORS Order Error");
                                valid = false;
                            }
                        }
                    }
                    else if (line.StartsWith("LIMITS-RAM"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        string KeyWord = item[0];
                        string Min = item[1];
                        string Max = item[2];
                        if (!Int32.TryParse(Min, out Ram_MIN) || !Int32.TryParse(Max, out Ram_MAX))
                        {
                            errorList.Add("Error:RAM must be integer.");
                            valid = false;
                        }
                        else
                        {
                            if (Ram_MAX < Process_MIN || Ram_MIN < 1 || Ram_MAX < 1)
                            {
                                errorList.Add("Error: RAM Order Error");
                                valid = false;
                            }
                        }
                    }
                    else if (line.StartsWith("LIMITS-PROCESSOR-FREQUENCIES"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        string KeyWord = item[0];
                        string Min = item[1];
                        string Max = item[2];
                        if (!float.TryParse(Min, out Frequencies_MIN) || !float.TryParse(Max, out Frequencies_MAX))
                        {
                            errorList.Add("Allocation must be an float.");
                            valid = false;
                        }
                        else
                        {
                            if (Frequencies_MAX < Frequencies_MIN || Frequencies_MAX < 1)
                            {
                                errorList.Add("Error: The Max frequency" + Max + " should be larger than the Min frequency" + Min);
                                valid = false;
                            }
                            else if (Frequencies_MIN < 0)
                            {
                                errorList.Add("Error: Processor frequency " + Min + " Order Error.");
                                valid = false;
                            }
                        }
                    }
                    else if (line.StartsWith("PROGRAM-DATA"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        string KeyWord = item[0];
                        string MAXDURATION = item[1];
                        string TASKS = item[2];
                        string PROCESSORS = item[3];
                        TASK = Int32.Parse(TASKS);
                        PROCESSOR = Int32.Parse(PROCESSORS);
                        if (!Double.TryParse(MAXDURATION, out duration))
                        {
                            errorList.Add("Error:" + MAXDURATION + " need is integer.");
                            valid = false;
                        }
                        if (!Int32.TryParse(TASKS, out ProgramTasks))
                        {
                            errorList.Add("Error:" + TASKS + " is not a non-negative integer.");
                            valid = false;
                        }
                        if (!Int32.TryParse(PROCESSORS, out PROCESSOR))
                        {
                            errorList.Add("Error:" + PROCESSORS + " is not a non-negative integer.");
                            valid = false;
                        }
                    }
                    else if (line.StartsWith("REFERENCE-FREQUENCY"))
                    {
                        if (!line.Contains("="))
                        {
                            errorList.Add("Error:equals to is missing after keyword.");
                            valid = false;
                        }
                        else
                        {
                            string[] item = line.Split('=');
                            string KeyWord = item[0];
                            string FREQUENCY = item[1];
                            if (!Double.TryParse(FREQUENCY, out Frequency))
                            {
                                errorList.Add("Error:" + FREQUENCY + " need negative number.");
                                valid = false;
                            }
                        }
                    }
                    else if (line.StartsWith("TASK-RUNTIME-RAM"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        if (item.Length != ((TASK * 2) + 1))
                        {
                            errorList.Add("Error: TASK-RUNTIME-RAM not correct/mismatch");
                        }
                        runTime = new float[TASK, 2];
                        int d = 0;
                        for (int b = 0; b < TASK; b++)
                        {
                            for (int c = 0; c < 2; c++)
                            {
                                runTime[b, c] = float.Parse(item[d+1]);
                                d += 1;
                             }
                        }
                    }
                    else if (line.StartsWith("PROCESSORS-FREQUENCIES-RAM"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        if (item.Length != ((PROCESSOR * 3) + 1))
                        {
                            errorList.Add("Error: PROCESSORS-FREQUENCIES-RAM not correct/mismatch");
                        }
                         Process_ID = new string[PROCESSOR, 2];
                        int c = 0;
                     //   for (int b = 0; b < PROCESSOR; b++)
                     //  {
                            for (int a = 2; a < (item.Length); a += 3)
                            {
                                string KeyWord = c.ToString();
                                string FREQUENCY = item[a];
                                Process_ID[c, 0] = KeyWord;
                                Process_ID[c, 1] = FREQUENCY;
                                c += 1;
                            }
                      // }

                    }
                    else if (line.StartsWith("PROCESSORS-COEFFICIENTS"))
                    {
                        char[] delimiterChar = { '=', ',' };
                        string[] item = line.Split(delimiterChar);
                        for (int x = 2; x < (item.Length - 1); x += 4)
                        {
                            bool result1 = float.TryParse(item[x], out float c0);
                            bool result2 = float.TryParse(item[x + 1], out float c1);
                            bool result3 = float.TryParse(item[x + 2], out float c2);
                            //int c1 = Int32.Parse(item[x + 1]);
                            //int c2 = Int32.Parse(item[x + 2]);
                            if (result1 == false || result2 == false || result3 == false)
                            {
                                errorList.Add("Error: cofficient value not correct");
                            }
                            Coefficient_ID = new double[PROCESSOR*3, 2];
                            int b = 0;
                            //for (int b = 0; b < PROCESSOR; b++)
                            //{
                                for (int a = 2; a < (item.Length); a += 4)
                                {
                                    Coefficient_ID[b, 1] = Double.Parse(item[a]);
                                    Coefficient_ID[b+1, 1] = Double.Parse(item[a+1]);
                                    Coefficient_ID[b+2, 1] = Double.Parse(item[a+2]);
                                    b += 3;
                                }
                          //  }

                        }
                    }
                    else if (line.StartsWith("LOCAL-COMMUNICATION"))
                    {
                        for (int i = 0; i < TASK; i++)
                        {
                            line = FileIn.ReadLine();
                            for (int j = 0; j <TASK; j++)
                            {
                                string str = line.Split(',')[i];
                                if(Int32.Parse(str) != 0 )
                                {
                                    errorList.Add("Error: A task can not send data to itself");
                                }                               
                           }

                        }
                    }
                    else if (line.StartsWith("REMOTE-COMMUNICATION"))
                    {
                        for (int i = 0; i < TASK; i++)
                        {
                            line = FileIn.ReadLine();
                            for (int j = 0; j < TASK; j++)
                            {
                                string str = line.Split(',')[i];
                                if (Int32.Parse(str) != 0)
                                {
                                    errorList.Add("Error: A task can not send data to itself");
                                }
                            }

                        }

                    }
                    else
                    {
                        errorList.Add("Error:" + line.Split(',')[0] + " is not a keyword.");
                        valid = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            FileIn.Close();
            return valid;
        }

        public bool CheckRunTime()
        {
            bool checkAns = true;
            foreach (Allocation temp in TaskHome.task_allocation.List)
            {
                double runTime = TaskHome.task_config.RunTime(temp);
                if (runTime > TaskHome.task_config.Duration())
                {
                    runTime = Math.Round(runTime, 2);
                    TaskHome.task_error.textBoxForm.Text += "Error:the runtime(" + runTime.ToString() + "s) of allocation " + temp.id + " is greater than the expected maximum(3s).\r\n";
                    checkAns = false;
                }
            }
            return checkAns;
        }

        public double Duration()
        {
            return duration;  //3 
        }

        public double CalEnergyPerSecond(double temp)
        {
            double x =  (Coefficient_ID[c_id+2, 1] * temp * temp + Coefficient_ID[c_id+1, 1] * temp + Coefficient_ID[c_id, 1]);
            //c_id += 3;
            return x;
        }

        public double CalTaskEnergy(float taskID, string processID)
        {
            double energy;
            for (int i = 0; i < ProgramTasks; i++)
            {
                for (int j = 0; j < PROCESSOR; j++)
                {
                    if (taskID == runTime[i, 0] && Process_ID[j, 0] == processID)
                    {
                        energy = CalEnergyPerSecond(Double.Parse(Process_ID[j, 1])) * CalTaskRunTime(j, i);//duration;
                        return energy;
                    }
                    else
                        continue;
                }
            }
            return 0;
        }

        public double Energy(Allocation temp)
        {
            double ans = 0;
            for (int i = 0; i < temp.processor; i++)
            {
                for (int j = 0; j < temp.task; j++)
                {
                    if (temp.allocation[i, j] == 1)
                    {
                        //Add the energy of the tasks that are allocated to the processor
                         ans += CalTaskEnergy(runTime[j, 0], Process_ID[i, 0]);                       
                    }
                }
            }
            return ans;
        }

        public double CalTaskRunTime(int i, int j)
        {
            double processFrequency = Double.Parse(Process_ID[i, 1]);
            return 2 * runTime[j, 1] / processFrequency;   

        }

        public double RunTime(Allocation temp)
        {
            double max = 0;
            for (int i = 0; i < temp.processor; i++)
            {
                double time = 0;
                for (int j = 0; j < temp.task; j++)
                {
                    if (temp.allocation[i, j] == 0)
                        continue;
                    else
                    {
                        time += CalTaskRunTime(i, j);
                    }
                }
                if (max < time)
                {
                    max = time;
                }
            }
            return max;
        }
    }

}
