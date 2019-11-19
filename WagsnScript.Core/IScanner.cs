using System;
using System.Collections.Generic;
using System.Text;

namespace WagsnScript
{
    /// <summary>
    /// 扫描器（将源代码分析成词素）
    /// </summary>
    public interface IScanner
    {
        string Name { get; set; }
        /// <summary>
        /// 词素分析
        /// 不同的扫描器可以采取不同的方式来从源代码中抽取词素
        /// </summary>
        /// <param name="source">源代码</param>
        /// <returns>词素集</returns>
        string[] Scanning(string source);
    }
}
