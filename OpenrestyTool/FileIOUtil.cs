using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class FileIOUtil
{

    /// <summary>
    /// 计算内存数据MD5值
    /// </summary>
    /// <returns>MD5值</returns>
    /// <param name="buffer">内存数据</param>
    public static string MD5(byte[] buffer)
    {
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] retVal = md5.ComputeHash(buffer);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < retVal.Length; i++)
        {
            sb.Append(retVal[i].ToString("x2"));
        }
        return sb.ToString();
    }

    /// <summary>
    /// 获得某路径下的所有文件信息
    /// </summary>
    /// <param name="dir">文件路径</param>
    /// <returns>文件名称列表</returns>
    public static List<FileInfo> GetFileInfos(string dir)
    {
        if (dir.Trim() == "" || !Directory.Exists(dir))
        {
            return null;
        }
        List<FileInfo> fileInfoList = new List<FileInfo>();
        DirectoryInfo dirInfo = new DirectoryInfo(dir);
        FileInfo[] fileInfos = dirInfo.GetFiles();
        if (fileInfos != null && fileInfos.Length > 0)
        {
            foreach (FileInfo fileInfo in fileInfos)
            {
                fileInfoList.Add(fileInfo);
            }
        }
        return fileInfoList;
    }

    /// <summary>
    /// 获得某路径下所有的子路径
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static List<string> GetSubDirectory(string dir)
    {
        if (dir.Trim() == "" || !Directory.Exists(dir))
        {
            return null;
        }
        List<string> dirList = new List<string>();
        DirectoryInfo dirInfo = new DirectoryInfo(dir);
        DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
        if (dirInfos != null && dirInfos.Length > 0)
        {
            foreach (DirectoryInfo childDirInfo in dirInfos)
            {
                dirList.Add(childDirInfo.Name);
            }
        }
        return dirList;
    }

    /// <summary>
    /// 检测文件是否存在
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool FileExists(string path)
    {
        return File.Exists(path);
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="content">内容</param>
    public static void CreateFile(string path, byte[] content, int offset, int count)
    {
        string dir = GetDirectoryByPath(path);
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        FileStream fs = new FileStream(path, FileMode.Create);
        fs.Write(content, offset, count);
        fs.Flush();
        fs.Close();
    }
    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="content">内容</param>
    public static void CreateFile(string path, byte[] content)
    {
        CreateFile(path, content, 0, content.Length);
    }
    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="content">内容</param>
    public static void CreateFile(string path, string content)
    {
        byte[] contentBytes = CommUtil.Str2Bytes(content);
        CreateFile(path, contentBytes);
    }

    /// <summary>
    /// 读取文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static byte[] ReadFileRaw(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        byte[] content = new byte[fs.Length];
        fs.Read(content, 0, (int)fs.Length);
        fs.Close();
        return content;
    }
    /// <summary>
    /// 读取文件字符串
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string ReadFile(string path)
    {
        byte[] contentBytes = ReadFileRaw(path);
        return CommUtil.Bytes2Str(contentBytes);
    }
    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="path">路径</param>
    public static void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static string GetDirectoryByPath(string path)
    {
        string[] temps = path.Split('\\');
        string dir = "";
        for (int i = 0; i < temps.Length - 1; i++)
        {
            dir += temps[i] + "\\";
        }
        return dir;
    }

    public static string GetFileNameByPath(string path)
    {
        string[] temps = path.Split('\\');
        return temps[temps.Length - 1];
    }

    public static void CopyFile(string surPath, string desPath)
    {
        if (File.Exists(surPath))
        {
            File.Copy(surPath, desPath);
        }
    }

}
