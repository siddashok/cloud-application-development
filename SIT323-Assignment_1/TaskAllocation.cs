using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SIT323_Assignment
{
    public class TaskAllocation
    {
        public List<Allocation> List = new List<Allocation>();
        public List<string> ID = new List<string>();
        public List<string> errorList = new List<string>();

        private bool allocationCalculateOnce;
        private bool valid;
        public int _processorNum = 0;
        public int _taskNum = 0;
        public int _allocationNum = 0;
        private string cffPath = "";
        public bool lostCFFName = false;

        public string GetCffPath()
        {
            return cffPath;
        }

        public bool IsValid(string path)
        {
            allocationCalculateOnce = false;
            StreamReader fileIn = new StreamReader(path);
            valid = true;
            //read every line in the TAN file
            while (!fileIn.EndOfStream)
            {
                try
                {
                    String line = fileIn.ReadLine();
                    //discard comment
                    if (line.StartsWith("//"))
                    {
                        continue;
                    }
                    if (line.Length == 0)
                    {
                        continue;
                    }
                    //Match keyword and find error
                    if (line.StartsWith("CONFIG-FILE") || line.Contains("\""))
                    {
                        string[] item = line.Split('=');
                        string KeyWord = item[0];
                        string Addr = item[1];
                        Addr = Addr.Trim(new char[] { '"' });
                        //find the CFF file path
                        if (Addr.Contains("\\"))
                        {
                            cffPath = Path.GetDirectoryName(path) + @"\" + Addr;
                            lostCFFName = true;
                        }
                        else
                        {
                            cffPath = Path.GetDirectoryName(path) + @"\" + Addr;
                        }
                        if (!line.Contains("CONFIG-FILE"))
                        {
                            errorList.Add("Error: " + KeyWord);
                            valid = false;
                        }
                    }                 
                    else if (line.Contains("ALLOCATIONS-DATA"))
                    {
                        char[] delimiterChar = { '=',',' };
                        string[] item = line.Split(delimiterChar);
                        string KeyWord = item[0];
                        string AllocationNum = item[1];
                        string TaskNum = item[2];
                        string ProcessorNum = item[3];
                        if (!Int32.TryParse(AllocationNum, out _allocationNum))
                        {
                            errorList.Add("Error:The ALLOCATIONS Numbers must be Integer.");
                            valid = false;
                        }
                        if (!Int32.TryParse(TaskNum, out _taskNum))
                        {
                            errorList.Add("Error:The TASKS Numbers must be Integer.");
                            valid = false;
                        }
                        if (!Int32.TryParse(ProcessorNum, out _processorNum))
                        {
                            errorList.Add("Error:The PROCESSOR Numbers must be Integer.");
                            valid = false;
                        }
                    }
                    else if (line.Contains("ALLOCATION-ID"))
                    {
                        string[] item = line.Split('=');
                        string KeyWord = item[0];
                        string  ALLOCATION_ID = item[1];
                        bool result_string = Int32.TryParse(ALLOCATION_ID, out int r);
                        if (ID.Contains(ALLOCATION_ID))
                        {
                            errorList.Add("Error: The ALLOCATION-ID must be Unique.");
                            valid = false;
                        }
                        else if(result_string == false)
                        {
                            errorList.Add("Error: The ALLOCATION-ID must be integer.");
                            valid = false;
                        }
                        else
                        {
                            ID.Add(ALLOCATION_ID);
                        }
                        
                        _allocationNum++;

                        Allocation Temp = new Allocation(_processorNum, _taskNum)
                        {
                            id = ALLOCATION_ID
                        };

                        for (int i = 0; i < _processorNum; i++)
                        {
                            line = fileIn.ReadLine();

                            for (int j = 0; j < _taskNum; j++)
                            {
                                string str = line.Split(',')[j];
                                Temp.SetAllocation(i, j, str);
                            }
                        }

                        if (!Temp.Check())
                        {
                            foreach (string s in Temp.errorList)
                            {
                                errorList.Add(s);
                            }
                            valid = false;
                        }

                        List.Add(Temp);
                    }
                    else
                    {
                        string[] item = line.Split(',');
                        string KeyWord = item[0];
                        valid = false;
                        errorList.Add("Error:" + KeyWord + " is incorrect.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            fileIn.Close();
            return valid;
        }
        public bool ReturnCheckTimes()
        {
            return allocationCalculateOnce;
        }

    }
}
