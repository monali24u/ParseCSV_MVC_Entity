using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ParsingLibrary
{
    //Class to handle parsing of file
    public class Parser
    {
        //Parse given csv file to a list
        public List<string> ParseFile(HttpPostedFileBase uploadedFile)
        {
            List<string> nlist = new List<string>();
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {

                if (uploadedFile.FileName.EndsWith(".csv"))
                {
                    string path = @"D:\ForMonali\Monali_WebApp\MyUserDataApp\";
                    string filePath = path + Path.GetFileName(uploadedFile.FileName);
                    string csvData = System.IO.File.ReadAllText(filePath);
                    string[] result;

                    //Execute a loop over the rows.
                    foreach (string row in csvData.Split('\n'))
                    {
                        result = row.Split(',');

                        if (!string.IsNullOrEmpty(row))
                        {
                            if (result[0].Contains("Email Address"))
                            {
                                continue;
                            }
                            nlist.Add(result[0]);
                            nlist.Add(result[1]);
                            nlist.Add(result[2]);
                        }
                    }
                }
            }
            return nlist;
        }
    }
}
