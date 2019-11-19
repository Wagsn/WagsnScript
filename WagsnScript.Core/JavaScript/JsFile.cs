using System;
using System.Collections.Generic;
using System.Text;

namespace WagsnScript.JavaScript
{
    /// <summary>
    /// 文件操作
    /// </summary>
    public class JsFile : JsObject
    {
        public string read(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public string load(string uri)
        {
            Uri i = new Uri(uri);
            if(i.Scheme == "file")
            {
                Console.WriteLine("AbsolutePath: " + i.AbsolutePath);
                return System.IO.File.ReadAllText(i.AbsolutePath);
            }
            return $"{i.Scheme}://{i.Authority}/{i.PathAndQuery}";
        }
    }
}
