using System.Collections.Generic;

namespace DataBaseLayer
{
    public interface IDataBase
    {
        void AddNewField(string field);
        void AddNewOrg(string org);
        void AddNewWell(string well);
        void DeleteFieldsByOrg(char org);
        string DeleteNthField(int n);
        string DeleteNthOrg(int n);
        void DeleteNthWell(int n);
        void DeleteWellsByField(string f);
        void DeleteWellsByOrg(char org);
        List<string> GetAllFields();
        List<string> GetAllOrg();
        List<string> GetAllWells();
        List<string> GetFieldsByOrg(char Org);
        string GetNthField(int id);
        string GetNthOrg(int id);
        string GetNthWell(int id);
        List<string> GetWellsByField(string f);
        List<string> GetWellsByOrg(char Org);
        List<string> GetWellsByOrgAndField(char org, string f);
        int LengthOfFileField();
        int LengthOfFileOrg();
        int LengthOfFileWell();
        bool IsValidUser(string username, string password);
        bool IsAuthorisedUser(string username,string role);
    }
}