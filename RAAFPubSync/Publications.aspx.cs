using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RAAFPubSync
{
    public partial class Publications : System.Web.UI.Page
    {
        readonly string _pubParentDirectoryPath = System.Configuration.ConfigurationManager.AppSettings["PubParentDirectoryPath"];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRemoteFile("http://www.raafais.gov.au/Pdf/", "AIPAB_", "_web.pdf", "AIPAB");
            GetRemoteFile("http://www.raafais.gov.au/pdf/", "FIHA_", "_web.pdf", "FIHA");
            GetRemoteFile("http://www.raafais.gov.au/pdf/", "GPA_", "_web.pdf", "GPA");
        }

        public void GetAIPAB_Click(object sender, EventArgs e)
        {
            GetRemoteFile("http://www.raafais.gov.au/Pdf/", "AIPAB_", "_web.pdf", "AIPAB");
        }

        public void GetFIHA_Click(object sender, EventArgs e)
        {
            GetRemoteFile("http://www.raafais.gov.au/pdf/", "FIHA_", "_web.pdf", "FIHA");
        }

        public void GetGPA_Click(object sender, EventArgs e)
        {
            GetRemoteFile("http://www.raafais.gov.au/pdf/", "GPA_", "_web.pdf", "GPA");
        }


        private void GetRemoteFile(string filePath, string fileNameStart, string fileNameEnd, string fileDestFolderName)
        {
            statusMessage.Text += "Download Started <br />";

            foreach (DateTime day in EachDay(DateTime.Now.AddMonths(-1), DateTime.Now))
            {
                string fileName = fileNameStart + day.ToString("ddMMMyy") + fileNameEnd;

                if (CheckFileExists((filePath + fileName)))
                {
                    //create inner dest directory if doesn't exist
                    DirectoryInfo dir = new DirectoryInfo(_pubParentDirectoryPath + fileDestFolderName);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }                    

                    WebClient client = new WebClient();                    
                    client.DownloadFile((filePath + fileName), _pubParentDirectoryPath + fileDestFolderName + @"\" + fileName);
                    statusMessage.Text += "Download Completed from " + filePath + fileName + "<br />";
                    break;
                    
                }
                else
                {
                    statusMessage.Text += "Unable to download - file not found: " + filePath + fileName + "<br />";
                }
            }
        }


        public IEnumerable<DateTime> EachDay(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day; //this is in standard DateTime format 
        }

        public bool CheckFileExists(string filePath)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(filePath);

            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}