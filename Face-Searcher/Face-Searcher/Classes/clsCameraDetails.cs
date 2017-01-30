using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Face_Searcher.Forms;

namespace Face_Searcher.Classes
{
    class clsCameraCollection
    {
        public List<clsCameraDetails> camList =  new List<clsCameraDetails>();
        public string file = @"C:\CyberExtruder\Aureus\AllSettings.txt";

        /// <summary>
        /// Read all camera files and load them to their respective cameraDetail
        /// </summary>
        public void loadCams()
        {
            //Read from the camera settings file
            string fileContent = Program.readFromFile(this.file);

            if (fileContent.Trim() == "")
            {
                //File not found or empty. Provide dummy data
                fileContent = "1,Local_1,ID_1,RTSP_1," + 
                    Program.defaultAOI.top.ToString() + "," + 
                    Program.defaultAOI.left.ToString() + "," +
                    Program.defaultAOI.height.ToString() + "," +
                    Program.defaultAOI.width.ToString() + "," +
                    Program.defaultAOI.minHead.ToString() + "," +
                    Program.defaultAOI.maxHead.ToString();
            }

            //Load all of these the way that we have to
            List<string> allSettings = new List<string>();
            //These values will be separated by a |
            allSettings = fileContent.Split('|').ToList();

            for (int i = 0; i < allSettings.Count; i++)
            {
                clsCameraDetails CD = new clsCameraDetails();
                CD.loadIndivCam(allSettings[i]);
                camList.Add(CD);
            }
        }

        /// <summary>
        /// Add a new camera to the camera collection
        /// </summary>
        public void newCam()
        {
            int camNum = camList[camList.Count - 1].camNumber + 1;
            clsCameraDetails newCameraDetail = new clsCameraDetails();
            newCameraDetail.camNumber = camNum;
            newCameraDetail.camLocation = "Location_" + camNum.ToString();
            newCameraDetail.camID = "CameraID_" + camNum.ToString();
            newCameraDetail.camRTSP = "RTSP_" + camNum.ToString();
            newCameraDetail.camProcID = 0;
            newCameraDetail.camAOI = Program.defaultAOI.clone();
            newCameraDetail.camControl.loadCamControl(newCameraDetail);

            //Add the camera
            camList.Add(newCameraDetail);
        }

        /// <summary>
        /// If a camera is removed, adjust all the other numbers
        /// </summary>
        public void fixCamNum()
        {
            //Loop through from 1 to camList.count and set the camNumbers
            for(int i = 0; i <= camList.Count - 1; i++)
            {
                //Set the number now
                camList[i].camNumber = i + 1;
            }
        }

        /// <summary>
        /// Loop through camList and write all of the info to a file
        /// </summary>
        public void saveAllCams()
        {
            string fileContent = "";
            string CameraIDFile = "";
            string IPSsFile = "";

            for(int i = 0; i < camList.Count; i++)
            {
                //Load the main info
                camList[i].camLocation = camList[i].camControl.camLocal.Text;
                camList[i].camID = camList[i].camControl.camID.Text;
                camList[i].camRTSP = camList[i].camControl.camRTSP.Text;

                fileContent += camList[i].camNumber.ToString("0") + "," +
                    camList[i].camControl.camLocal.Text + "," +
                    camList[i].camControl.camID.Text + "," +
                    camList[i].camControl.camRTSP.Text + "," +
                    camList[i].camAOI.top + "," +
                    camList[i].camAOI.left + "," +
                    camList[i].camAOI.height + "," +
                    camList[i].camAOI.width + "," +
                    camList[i].camAOI.minHead + "," +
                    camList[i].camAOI.maxHead + "|";

                CameraIDFile += camList[i].camControl.camID.Text + "\r\n";
                IPSsFile += camList[i].camControl.camRTSP.Text + "\r\n";
            }

            //Remove the last | so we do not have a blank cam on load
            fileContent = fileContent.Trim('|');
            CameraIDFile = CameraIDFile.Substring(0, CameraIDFile.Length - 2);
            IPSsFile = IPSsFile.Substring(0, IPSsFile.Length - 2);

            //Save the settings
            Program.writeToFile(this.file, fileContent);
            Program.writeToFile(Program.CameraID, CameraIDFile);
            Program.writeToFile(Program.CameraIDs, CameraIDFile);
            Program.writeToFile(Program.IPSs, IPSsFile);
        }

        /// <summary>
        /// Make an exact replica of the live cam list
        /// </summary>
        /// <returns></returns>
        public List<clsCameraDetails> copyCamList()
        {
            List<clsCameraDetails> tempList = new List<clsCameraDetails>();

            for (int i = 0; i < this.camList.Count; i++)
            {
                tempList.Add(camList[i].clone());
            }

            return tempList;
        }

        /// <summary>
        /// Dispose all of the old controls and initialize new ones
        /// </summary>
        public void refreshControls()
        {
            for (int i = 0; i < this.camList.Count; i++)
            {
                camList[i].refreshControl();
            }
        }

        /// <summary>
        /// Create a clone of the main camera collection
        /// </summary>
        /// <returns></returns>
        public clsCameraCollection clone()
        {
            clsCameraCollection CC = new clsCameraCollection();
            CC.camList = this.copyCamList();
            return CC;
        }
    }

    class clsCameraDetails
    {
        //All camera variables start with 'cam'
        public int camNumber = 0;
        public string camLocation = "";
        public string camID = "";
        public string camRTSP = "";
        public int camProcID = 0;
        public clsDefaultAOI camAOI = new clsDefaultAOI();
        public clsCameraControls camControl = new clsCameraControls();
        
        /// <summary>
        /// Take a camera string and create a new camera from it
        /// </summary>
        /// <param name="camInfo"></param>
        public void loadIndivCam(string camInfo)
        {
            //1,Ft Washington,Test Cam,http:/admin:betrayed1@192.168.1.119:80/video.cgi,0.625,0.5,1,1,0.222,0.123
            try
            {
                //Load all of the normal settings
                string[] cam;
                cam = camInfo.Split(',');

                //Start loading the camera information
                this.camNumber = Program.parseInt(cam[0]);
                this.camLocation = cam[1];
                this.camID = cam[2];
                this.camRTSP = cam[3];
                this.camProcID = 0;

                //Load all of the AOI settings for this camera
                this.camAOI.top = cam[4];
                this.camAOI.left = cam[5];
                this.camAOI.height = cam[6];
                this.camAOI.width = cam[7];
                this.camAOI.minHead = cam[8];
                this.camAOI.maxHead = cam[9];

                //Pass in the current object and add the controls to it
                this.camControl.loadCamControl(this);
            }
            catch
            {
                //Do nothing
            }
        }

        /// <summary>
        /// dispose the old controls and create new ones
        /// </summary>
        public void refreshControl()
        {
            this.camControl = new clsCameraControls();
            this.camControl.loadCamControl(this);
        }

        /// <summary>
        /// Create a clone of the main camera
        /// </summary>
        /// <returns></returns>
        public clsCameraDetails clone()
        {
            clsCameraDetails CD = new clsCameraDetails();
            CD.camNumber = this.camNumber;
            CD.camLocation = this.camLocation;
            CD.camID = this.camID;
            CD.camRTSP = this.camRTSP;
            CD.camProcID = this.camProcID;
            
            CD.camAOI.top = this.camAOI.top;
            CD.camAOI.left = this.camAOI.left;
            CD.camAOI.height = this.camAOI.height;
            CD.camAOI.width = this.camAOI.width;
            CD.camAOI.minHead = this.camAOI.minHead;
            CD.camAOI.maxHead = this.camAOI.maxHead;

            CD.camControl.loadCamControl(CD);
            CD.camControl.procID = this.camProcID;

            return CD;
        }
    }
}
