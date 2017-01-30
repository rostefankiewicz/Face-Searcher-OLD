using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Face_Searcher.Classes;
using Face_Searcher.Forms;
using System.Diagnostics;
using System.Text;

namespace Face_Searcher
{
    static class Program
    {
        //Delcare all global variables
        internal static clsDefaultAOI defaultAOI = new clsDefaultAOI();

        //Keep the camera collections that we use else where here as well
        internal static clsCameraCollection tempCamCollection = new clsCameraCollection();
        internal static clsCameraCollection camCollection = new clsCameraCollection();

        //Keep track of all the forms so I can access them from here.
        internal static MainPage MP;
        internal static EmailSetup email;
        internal static NiFi nifi;
        internal static Camera camera;
        internal static AOI aoi;
        internal static License license;
        internal static About about;

        //The following variables are used to keep track of what is running throughout the system
        internal static int CamPreProcID = 0;
        internal static bool nifiRunning = false;
        internal static bool blnShowStream = false;

        //These are files that we will be using
        internal static string ATIPS = @"C:\CyberExtruder\Aureus\ATIPS.txt"; //This is where Aureus_Traacking reads from
        internal static string IPSs = @"C:\CyberExtruder\Aureus\IPSs.txt"; //This is where Aureus_Helper reads from
        internal static string CameraID = @"C:\CyberExtruder\Aureus\CameraID.txt"; //Make sure to write all 
        internal static string CameraIDs = @"C:\CyberExtruder\Aureus\CameraIDs.txt"; //Make sure to write all 
        internal static string AOI = @"C:\CyberExtruder\Aureus\AOI.txt"; //File to append all running Camera AOI settings to
        internal static string defaultAOIFile = @"C:\CyberExtruder\Aureus\DefaultAOI.txt"; //This is where the default AOI settings are saved
        internal static string contentSettingsFile = @"C:\CyberExtruder\Aureus\ControlSettings.txt"; //Content settings file used on cam startup

        //Misc dictionaries that are needed
        internal static Dictionary<string, string> AOIContent = new Dictionary<string, string>();
        internal static Dictionary<string, System.Threading.Thread> threadList = new Dictionary<string, System.Threading.Thread>();

        //Variables that control the email settings
        internal static string emailSettings = @"C:\CyberExtruder\Aureus\Emails.txt"; //The file where the email settings are saved.
        internal static string fromEmail = "Facesearchtech@gmail.com"; //Only holds one value
        internal static List<string> toEmails = new List<string>(); //List of email addresses that we will send errors to

        //Executables and things to run
        internal static string AureusTracking = @"C:\CyberExtruder\Aureus\x64\Release\Aureus_Tracking.exe";
        internal static string videoPlayer = @"C:\CyberExtruder\AureusVideoStreamPlayer\AureusVideoStreamPlayer.exe";
        internal static string videoPlayerDocumentation = @"C:\CyberExtruder\AureusVideoStreamPlayer\README_How_to_use_AureusVideoStreamPlayer.PDF";
        internal static string setupDoc = @"C:\CyberExtruder\Aureus\FaceSearcher_User_Manual.pdf";
        internal static string eluaDoc = @"C:\CyberExtruder\Aureus\FaceSearcher_EULA.pdf";

        //End User License Agreenment
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            //Start the loading process
            loadAll();

            //Start the forms
            MP = new Forms.MainPage();
            Application.Run(MP);
        }

        /// <summary>
        /// Static makes this a global function
        /// </summary>
        internal static void loadAll()
        {
            //First load the default AOI settings
            defaultAOI.loadDefaults("");

            //Load all of the camer details
            camCollection.loadCams();
            //Now load the camCollection as a clone of the main one so we do not have to read from the file a second time.
            tempCamCollection = camCollection.clone();

            //Load the email settings
            loadEmailSettings();
        }

        /// <summary>
        /// Load the emails from the file
        /// </summary>
        internal static void loadEmailSettings()
        {
            string fileContent = readFromFile(emailSettings);
            //Split the fileContent and add it to our list
            toEmails = fileContent.Split(',').ToList();
            if (toEmails.Count <= 0)
            {
                //Did not have any emails to load. Use this by default
                toEmails.Add("Facesearchtech@gmail.com");
            }
           
        }

        //=================================== ALL OF THE GLOBAL FUNCTIONS WILL BE BELOW HERE ===================================

        /// <summary>
        ///Take the fileContent and write it to the target file
        /// </summary>
        internal static void writeToFile(string filePath, string fileContent)
        {
            try
            {
                //This will automatically overwrite the file's content, not appen to it.
                Encoding utf8WithoutBom = new UTF8Encoding(false);
                File.WriteAllText(filePath, fileContent, utf8WithoutBom);
            }
            catch
            {
                //Do nothing. Just need the catch for the program to work
            }
        }

        /// <summary>
        ///Read all of the text from the given file
        /// </summary>
        internal static string readFromFile(string filePath)
        {
            string strReturn = "";
            try
            {
                //First, check if the file exists or not
                if (File.Exists(filePath))
                {
                    //File does exists, read it
                    strReturn = File.ReadAllText(filePath);
                }else
                {
                    //File does not exists, Return blank
                    strReturn = "";
                }
            }
            catch
            {
                //Something caused an error. Return blank
                strReturn = "";
            }
            return strReturn;
        }

        /// <summary>
        /// Run the given executable and return its output. This should only be for programs that have short outputs. not streams
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal static string runEXEWithOP(string filePath)
        {
            string strReturn = "";
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = filePath;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                //* Read the output (or the error)
                strReturn = proc.StandardOutput.ReadToEnd();
            }
            catch
            {
                //Something failed
                strReturn = "";
            }
            return strReturn;
        }

        /// <summary>
        /// Start a process that we can set and forget. All we need is the processID
        /// </summary>
        /// <param name="filePath">What is the process to start</param>
        /// <returns>Process ID</returns>
        internal static int startBackgroundProc(string filePath, string workingDir, bool blnHide, bool blnWaitForExit, bool blnStartCam = false, bool blnCreateWindow = false)
        {
            int procID = 0;
            try
            {
                //Set all of the variables needed to start the background process
                Process proc = new Process();
                proc.StartInfo.FileName = filePath;
                proc.StartInfo.UseShellExecute = false;
                //Only run in background if requested to do so
                if (blnHide)
                {
                    //Make sure to hide the window
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.CreateNoWindow = true;
                }
                else
                {
                    //Do not hide the window
                    proc.StartInfo.RedirectStandardOutput = false;
                    proc.StartInfo.CreateNoWindow = false;
                }

                if (workingDir.Trim() != "")
                {
                    //Add the working directory
                    //This needs to be done for bat files apparently
                    proc.StartInfo.WorkingDirectory = workingDir;
                }

                //Start the process
                proc.Start();
                //Get the process ID to return
                procID = proc.Id;

                if (blnWaitForExit)
                {
                    //Make sure that we wait for an exit before continuing
                    proc.WaitForExit();
                }

                if (blnStartCam)
                {
                    StreamReader SR = proc.StandardOutput;

                    if (blnCreateWindow)
                    {
                        //CameraStream cs = new CameraStream();
                        //cs.SR = SR;
                        //cs.Show();
                        //cs.startStream();
                    }else
                    {
                        bool exit = false;
                        bool failed = false;
                        string currLine = "START";
                        while (!exit)
                        {
                            currLine = SR.ReadLine().ToUpper();
                            //Check for a failure
                            if (currLine == null) { exit = true; failed = true; continue; }
                            if (currLine.Contains("TERMINATION")) { exit = true; failed = true; continue; }
                            if (currLine.Contains("TERMINATED")) { exit = true; failed = true; continue; }
                            if (currLine.Contains("FAILED")) { exit = true; failed = true; continue; }
                            //Check for a success
                            if (currLine.Contains("FRAME")) { exit = true; continue; }
                        }

                        if (failed)
                        {
                            procID = 0;
                            MessageBox.Show("Your Camera has failed to start", "Failure", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch
            {
                procID = 0;
                if (blnStartCam)
                {
                    MessageBox.Show("Your Camera has failed to start", "Failure", MessageBoxButtons.OK);
                }
            }
            return procID;
        }

        /// <summary>
        /// Check if the given process is running
        /// </summary>
        /// <param name="procID">processID of the process in question</param>
        /// <returns>true if still running, false if not</returns>
        internal static bool checkProcStatusByID(int procID)
        {
            bool blnReturn = false;
            try
            {
                Process proc = Process.GetProcessById(procID);
                if (proc.Id != 0)
                {
                    blnReturn = true;
                }else
                {
                    blnReturn = false;
                }
            }catch
            {
                //Something failed while getting the process. Return false
                blnReturn = false;
            }
            return blnReturn;
        }

        /// <summary>
        /// Get the process by the given ID and kill it
        /// </summary>
        /// <param name="procID">processID of the process in question</param>
        /// <returns>true if killed, false if other</returns>
        internal static void killProcByID(int procID)
        {
            try
            {
                Process proc = Process.GetProcessById(procID);
                proc.Kill();
            }catch
            {
                //nothing
            }
        }

        /// <summary>
        /// Safely parse a string into a double
        /// </summary>
        /// <param name="input">string to be parsed</param>
        /// <returns>The double gotten from the string</returns>
        internal static double parseDouble(string input)
        {
            double dblReturn = 0;
            try
            {
                double x = 0;
                if (double.TryParse(input, out x))
                {
                    //This can be converted, so do so
                    dblReturn = double.Parse(input);
                }
                else
                {
                    //Cannot convert to double
                    dblReturn = 0;
                }
            }
            catch
            {
                //Failed
                dblReturn = 0;
            }
            //Return
            return dblReturn;
        }

        /// <summary>
        /// Safely parse a string into a integer
        /// </summary>
        /// <param name="input">string to be parsed</param>
        /// <returns>The integer gotten from the string</returns>
        internal static int parseInt(string input)
        {
            int intReturn = 0;
            try
            {
                int x = 0;
                if (int.TryParse(input, out x))
                {
                    //This can be converted, so do so
                    intReturn = int.Parse(input);
                }
                else
                {
                    //Cannot convert to double
                    intReturn = 0;
                }
            }
            catch
            {
                //Failed
                intReturn = 0;
            }
            //Return
            return intReturn;
        }

        /// <summary>
        /// Take all values from the AOIContent dictionary and write them to a file
        /// </summary>
        internal static void saveAllAOI()
        {
            try
            {
                string fileContent = "";
                for (int i = 0; i < AOIContent.Count; i++)
                {
                    //Get the value and append it to the fileContent
                    fileContent += AOIContent.Values.ElementAt(i);
                    if (i != AOIContent.Count - 1)
                    {
                        //If this is not the last value, append a break line
                        fileContent += "\r\n";
                    }
                }

                if (fileContent.Trim() != "")
                {
                    //If our value is not blank, then write it to the file. Otherwise, there is no need to waste time
                    writeToFile(AOI, fileContent);
                }
            }
            catch
            {
                //Do nothing
            }
        }

        /// <summary>
        /// Save all of the email settings
        /// </summary>
        internal static void saveEmail()
        {
            string fileContent = "";
            //Append all of the to emails
            for (int i=0; i < toEmails.Count; i++)
            {
                fileContent += toEmails[i].Trim() + ",";
            }
            //Get rid of the last comma
            fileContent = fileContent.Trim(',');
            //Write to file
            writeToFile(emailSettings, fileContent);
        }

        /// <summary>
        /// Take the nessecary steps before exiting the application
        /// </summary>
        internal static void exitApp()
        {
            //Kill all threads so the program closes properly
            foreach (KeyValuePair<string, System.Threading.Thread> entry in threadList)
            {
                entry.Value.Abort();
            }

            //Kill all procs by their IDs
            if (CamPreProcID != 0) { killProcByID(CamPreProcID); }
            //Loop through the camera collection
            int tempProcID = 0;
            for (int i = 0; i < tempCamCollection.camList.Count; i++)
            {
                //Check the outer most procID
                tempProcID = tempCamCollection.camList[i].camProcID;
                if (tempProcID != 0)
                {
                    killProcByID(tempProcID);
                }

                //Check the inner most procID
                tempProcID = tempCamCollection.camList[i].camControl.procID;
                if (tempProcID != 0)
                {
                    killProcByID(tempProcID);
                }
            }

            //Finally exit the app
            Application.Exit();
        }

        /// <summary>
        /// If a camera fails, Send an email to to proper people
        /// </summary>
        /// <param name="RTSP"></param>
        internal static void sendEmail(string RTSP)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                for (int i = 0; i < toEmails.Count; i++)
                {
                    //Check for invalid emails
                    if (!toEmails[i].Contains("@")) { continue; }
                    //Add the valid emails to the list to send to
                    message.To.Add(toEmails[i].Trim());
                }
                message.Subject = "Camera Failure";
                message.From = new System.Net.Mail.MailAddress(fromEmail.ToLower());
                message.Body = "The stream has been interrupted or terminated for camera " + RTSP + ".";
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(fromEmail.ToLower(), "betrayed1");
                smtp.Send(message);
            }
            catch (Exception x)
            {
                MessageBox.Show("Email failed to send.\r\n" + x.ToString(), "Failed", MessageBoxButtons.OK);
            }
        }
        
        /// <summary>
        /// When we start a camera, update the parent ProcID here
        /// </summary>
        /// <param name="RTSP"></param>
        /// <param name="Location"></param>
        /// <param name="CamID"></param>
        /// <param name="procID"></param>
        internal static void updateProcIdByValues(string RTSP, string Location, string CamID, int procID, bool updateMainCol = false, bool reloadControls = false)
        {
            for (int i = 0; i < tempCamCollection.camList.Count; i++)
            {
                if (tempCamCollection.camList[i].camLocation == Location && tempCamCollection.camList[i].camID == CamID && tempCamCollection.camList[i].camRTSP == RTSP)
                {
                    //Update the parent ProcID
                    tempCamCollection.camList[i].camProcID = procID;
                    tempCamCollection.camList[i].camControl.procID = procID;
                }
            }
            if (updateMainCol)
            {
                for (int i = 0; i < camCollection.camList.Count; i++)
                {
                    if (camCollection.camList[i].camLocation == Location && camCollection.camList[i].camID == CamID && camCollection.camList[i].camRTSP == RTSP)
                    {
                        camCollection.camList[i].camProcID = 0;
                        camCollection.camList[i].camControl.procID = 0;
                    }
                }
            }

            //Reload the camera controls if possible
            try
            {
                if (reloadControls)
                {
                    camera.DoSomething();
                }
            }
            catch
            {

            }
        }
    }
}
