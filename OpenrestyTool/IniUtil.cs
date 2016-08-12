using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

public class IniUtil
{
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    private static string iniPath;

    public static bool Reset(string path)
    {
        if (File.Exists(path))
        {
            iniPath = path;
            return true;
        }
        return false;
    }

    public static void Set(string Section, string Key, string Value)
    {
        WritePrivateProfileString(Section, Key, Value, iniPath);
    }

    public static string Get(string Section, string Key)
    {
        StringBuilder temp = new StringBuilder(500);
        int i = GetPrivateProfileString(Section, Key, "", temp, 500, iniPath);
        return temp.ToString();
    } 
}

