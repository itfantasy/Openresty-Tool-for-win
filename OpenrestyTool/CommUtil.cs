using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data;

public class CommUtil {

    /// <summary>
    /// C#对象根据属性名获取值
    /// </summary>
    /// <param name="csObj"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    public static object GetPropertyValue(object csObj, string property)
    {
        PropertyInfo pinfo = csObj.GetType().GetProperty(property);
        if (pinfo == null) return null;
        return pinfo.GetValue(csObj, null);
    }

    /// <summary>
    /// C#对象根据属性名赋值
    /// </summary>
    /// <param name="csObj"></param>
    /// <param name="property"></param>
    /// <param name="value"></param>
    public static void SetPropertyValue(object csObj, string property, object value)
    {
        if (value == null) return;
        PropertyInfo pinfo = csObj.GetType().GetProperty(property);
        if (pinfo != null)
        {
            if (pinfo.PropertyType == typeof(string))
            {
                pinfo.SetValue(csObj, value.ToString(), null);
            }
            else if (pinfo.PropertyType == typeof(float))
            {
                pinfo.SetValue(csObj, float.Parse(value.ToString()), null);
            }
            else if (pinfo.PropertyType == typeof(double))
            {
                pinfo.SetValue(csObj, double.Parse(value.ToString()), null);
            }
            else if (pinfo.PropertyType == typeof(int))
            {
                pinfo.SetValue(csObj, int.Parse(value.ToString()), null);
            }
            else if (pinfo.PropertyType == typeof(long))
            {
                pinfo.SetValue(csObj, long.Parse(value.ToString()), null);
            }
            else
            {
                csObj.GetType().GetProperty(property).SetValue(csObj, value, null);
            }
        }
    }

    /// <summary>
    /// C#获取对象全部属性名
    /// </summary>
    /// <param name="csObj"></param>
    /// <returns></returns>
    public static List<string> GetProperties(object csObj)
    {
        List<string> properties = new List<string>();
        foreach (PropertyInfo pinfo in csObj.GetType().GetProperties())
        {
            properties.Add(pinfo.Name);
        }
        return properties;
    }

    public static void LoadObject(object surObj, object desObj)
    {
        foreach (PropertyInfo pinfo in desObj.GetType().GetProperties())
        {
            SetPropertyValue(desObj, pinfo.Name, GetPropertyValue(surObj, pinfo.Name));
        }
    }

    public static T CloneObject<T>(T obj) where T : new()
    {
        T desObj = new T();
        foreach (PropertyInfo pinfo in desObj.GetType().GetProperties())
        {
            SetPropertyValue(desObj, pinfo.Name, GetPropertyValue(obj, pinfo.Name));
        }
        return desObj;
    }

    /// <summary>
    /// 字符串转字节
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static byte[] Str2Bytes(string str)
    {
        return System.Text.Encoding.UTF8.GetBytes(str);
    }
    /// <summary>
    /// 字节转字符串
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string Bytes2Str(byte[] bytes)
    {
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    /// C#通过反射机制初始化特定类型对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jObj"></param>
    /// <returns></returns>
    public static T LoadClass<T>(DataRow row) where T : new()
    {
        return LoadObject(row, new T());
    }

    /// <summary>
    /// C#通过属性表反射原理从JObject加载实例对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jObj"></param>
    /// <param name="csObj"></param>
    /// <returns></returns>
    public static T LoadObject<T>(DataRow row, T csObj)
    {
        foreach (DataColumn key in row.Table.Columns)
        {
            SetPropertyValue(csObj, key.ToString(), row[key].ToString());
        }
        return csObj;
    }
}

