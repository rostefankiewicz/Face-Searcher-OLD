using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Searcher.Classes
{
    public class clsDefaultAOI
    {
        //These are the variables that will be used throughout the program
        public string top = "0.500";
        public string left = "0.500";
        public string height = "0.500";
        public string width = "0.500";
        public string minHead = "0.500";
        public string maxHead = "0.500";

        /// <summary>
        /// Create a clone of the class values so that we do not alter the default settings
        /// </summary>
        /// <returns></returns>
        public clsDefaultAOI clone()
        {
            clsDefaultAOI defaultClone = new clsDefaultAOI();
            defaultClone.top = top;
            defaultClone.left = left;
            defaultClone.height = height;
            defaultClone.width = width;
            defaultClone.minHead = minHead;
            defaultClone.maxHead = maxHead;

            //return the result
            return defaultClone;
        }

        /// <summary>
        /// Read from the file and load all of the default AOI settings
        /// </summary>
        public void loadDefaults(string content)
        {
            string fileContent = "";
            //read the settings file
            if (content.Trim() == "")
            {
                fileContent = Program.readFromFile(Program.defaultAOIFile);
            }
            else
            {
                //Content has a value. Use that
                fileContent = content;
            }
            fileContent = fileContent.Replace("\r\n", ",");
            List<string> settings;
            settings = fileContent.Split(',').ToList();

            while (settings.Count < 6)
            {
                settings.Add("0.500");
            }

            //top
            this.top = settings[0];
            //left
            this.left = settings[1];
            //height
            this.height = settings[2];
            //width
            this.width = settings[3];
            //minHead
            this.minHead = settings[4];
            //maxHead
            this.maxHead = settings[5];
        }

        /// <summary>
        /// When the user hits save, trigger a function to save all of the settings to a file
        /// </summary>
        public void saveSettings()
        {
            //fill in once the write file function is made
            string fileContent = "";
            fileContent = top + "\r\n" + 
                left + "\r\n" + 
                height + "\r\n" + 
                width + "\r\n" + 
                minHead + "\r\n" + 
                maxHead;

            //Now write to the file
            Program.writeToFile(Program.defaultAOIFile, fileContent);
        }
    }
}
