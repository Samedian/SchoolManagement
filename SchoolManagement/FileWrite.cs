using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementPresentationLayer
{
    public class FileWrite : IFileWrite
    {
        /// <summary>
        /// this function is used to write data to file log
        /// </summary>
        /// <param name="message"></param>
        public void WriteData(string message)
        {
            string path = @"C:\Users\Samarth\source\repos\SchoolManagement\SchoolLog";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(message);

                }
            }
        }
    }
}
