using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer
{
    public class TextFileDB : IDataBase
    {
        const string OrgFilePath = "C:\\Users\\SNangia\\source\\repos\\DirectoryBrowser\\Org.txt";
        const string FieldFilePath = "C:\\Users\\SNangia\\source\\repos\\DirectoryBrowser\\Fields.txt";
        const string WellFilePath = "C:\\Users\\SNangia\\source\\repos\\DirectoryBrowser\\Well.txt";
        const string UserInfoPath = "C:\\Users\\SNangia\\source\\repos\\DirectoryBrowser\\UserInfo.txt";

        public List<string> GetAllOrg()
        {
            List<string> ret = new List<string>();
            string line;
            StreamReader sr = new StreamReader(OrgFilePath);
            line = sr.ReadLine();
            while(line != null)
            {
                ret.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return ret;
        }

        public string GetNthOrg(int id)
        {
            string line,ret ="";
            int line_no = 1;
            StreamReader sr = new StreamReader(OrgFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line_no == id)
                {
                    ret = line;
                    break;
                }
                line = sr.ReadLine();
                line_no++;
            }
            sr.Close();
            return ret;
        }

        public string DeleteNthOrg(int n)
        {
            string orgData = "";
            List<string> ret = new List<string>();
            string line;
            int line_no = 1;
            StreamReader sr = new StreamReader(OrgFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line_no != n)
                {
                    ret.Add(line);
                }
                else
                {
                    orgData = line;
                }
                line = sr.ReadLine();
                line_no++;
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(OrgFilePath);
            foreach (string item in ret)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            return orgData;
        }

        public void AddNewOrg(string org)
        {
            StreamWriter sw = File.AppendText(OrgFilePath);
            sw.WriteLine(org);
            sw.Close();
        }

        public int LengthOfFileOrg()
        {
            List<string> ret = new List<string>();
            string line;
            StreamReader sr = new StreamReader(OrgFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                ret.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return ret.Count;
        }



        

        public List<string> GetAllFields()
        {
            List<string> ret = new List<string>();
            string line;
            StreamReader sr = new StreamReader(FieldFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                ret.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return ret;
        }

        public string GetNthField(int id)
        {
            string line, ret = "";
            int line_no = 1;
            StreamReader sr = new StreamReader(FieldFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line_no == id)
                {
                    ret = line;
                    break;
                }
                line = sr.ReadLine();
                line_no++;
            }
            sr.Close();
            return ret;
        }

        public List<string> GetFieldsByOrg(char Org)
        {
            List<string> ret = new List<string>();
            string line;
            Org = Char.ToUpper(Org);
            StreamReader sr = new StreamReader(FieldFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line[0] == Org)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return ret;
        }

        public string DeleteNthField(int n)
        {
            string fName = "";
            List<string> ret = new List<string>();
            string line;
            int line_no = 1;
            StreamReader sr = new StreamReader(FieldFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line_no != n)
                {
                    ret.Add(line);
                }
                else
                {
                    fName += line[2] + line[3];
                }
                line = sr.ReadLine();
                line_no++;
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(FieldFilePath);
            foreach (string item in ret)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            return fName;
        }

        public void DeleteFieldsByOrg(char org)
        {
            List<string> ret = new List<string>();
            string line;
            org = char.ToUpper(org);
            StreamReader sr = new StreamReader(FieldFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line[0] != org)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(FieldFilePath);
            foreach (string item in ret)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        public void AddNewField(string field)
        {
            StreamWriter sw = File.AppendText(FieldFilePath);
            sw.WriteLine(field);
            sw.Close();
        }

        public int LengthOfFileField()
        {
            List<string> ret = new List<string>();
            string line;
            StreamReader sr = new StreamReader(FieldFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                ret.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return ret.Count;
        }






        public List<string> GetAllWells()
        {
            List<string> ret = new List<string>();
            string line;
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                ret.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return ret;
        }
        
        public string GetNthWell(int id)
        {
            string line, ret = "";
            int line_no = 1;
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line_no == id)
                {
                    ret = line;
                    break;
                }
                line = sr.ReadLine();
                line_no++;
            }
            sr.Close();
            return ret;
        }

        public List<string> GetWellsByOrg(char Org)
        {
            List<string> ret = new List<string>();
            string line;
            Org = Char.ToLower(Org);
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line[0] == Org)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return ret;
        }

        public List<string> GetWellsByField(string f)
        {
            List<string> ret = new List<string>();
            string line;
            f = f.ToLower();
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line.Contains(f) && line.IndexOf(f) == 2)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return ret;
        }

        public List<string> GetWellsByOrgAndField(char org, string f)
        {
            List<string> ret = new List<string>();
            string line;
            f = f.ToLower();
            org = char.ToLower(org);
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line[0] == org && line.Contains(f) && line.IndexOf(f) == 2)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return ret;
        }
        
        public void DeleteNthWell(int n)
        {
            List<string> ret = new List<string>();
            string line;
            int line_no = 1;
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line_no != n)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
                line_no++;
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(WellFilePath);
            foreach (string item in ret)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        public void AddNewWell(string well)
        {
            StreamWriter sw = File.AppendText(WellFilePath);
            sw.WriteLine(well);
            sw.Close();
        }
        
        public int LengthOfFileWell()
        {
            List<string> ret = new List<string>();
            string line;
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                ret.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return ret.Count;
        }

        public void DeleteWellsByField(string f)
        {
            List<string> ret = new List<string>();
            string line;
            f = f.ToLower();
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (!line.Contains(f) && line.IndexOf(f) != 2)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(WellFilePath);
            foreach (string item in ret)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        public void DeleteWellsByOrg(char org)
        {
            List<string> ret = new List<string>();
            string line;
            org = char.ToLower(org);
            StreamReader sr = new StreamReader(WellFilePath);
            line = sr.ReadLine();
            while (line != null)
            {
                if (line[0] != org)
                {
                    ret.Add(line);
                }
                line = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(WellFilePath);
            foreach (string item in ret)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        public bool IsValidUser(string username, string password)
        {
            StreamReader sr = new StreamReader(UserInfoPath);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] splitArray = line.Split('|');
                if (splitArray[0].ToLower().Equals(username.ToLower()) && splitArray[1].ToLower().Equals(password.ToLower()))
                {
                    sr.Close();
                    return true;
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return false;
        }

        public bool IsAuthorisedUser(string username, string role)
        {
            StreamReader sr = new StreamReader(UserInfoPath);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] splitArray = line.Split('|');
                if (splitArray[0].Equals(username) && CheckAuth(role.ToUpper(), splitArray[2]))
                {
                    sr.Close();
                    return true;
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return false;
        }

        private static bool CheckAuth(string role, string splitArray)
        {
            //return splitArray[2].Equals(role);
            string[] authHeader = role.Split(',');
            foreach (var item in authHeader)
            {
                if (splitArray.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
