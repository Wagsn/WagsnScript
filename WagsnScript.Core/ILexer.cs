using System;
using System.Collections.Generic;
using System.Text;

namespace WagsnScript
{
    /// <summary>
    /// 词法分析器接口
    /// </summary>
    public interface ILexer
    {
        /// <summary>
        /// 词法分析器名称（唯一）
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 词法分析
        /// </summary>
        /// <param name="lexemes">词素集</param>
        /// <returns>单词集</returns>
        IEnumerable<Token> Lexing(string[] lexemes);
    }
}
