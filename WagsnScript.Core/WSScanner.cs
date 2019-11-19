using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WagsnScript
{
    /// <summary>
    /// 自定义的扫描器
    /// </summary>
    public class WSScanner : IScanner
    {
        public string Name { get; set; } = "WSScanner";

        /// <summary>
        /// 利用正则表达式生成预处理数据
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string[] Scanning(string source)
        {
            var strs = new List<string>();
            // 扫描优先级（注释>字符串字面量>标识符>数值字面量>边界符）（暂时只做变量定义表达式（VariableDeclaration:"<id_name>[:<id_name>]:=<num_expr>;"）与数值四则运算表达式（BinaryExpression: "<id|num><[+|-|*|/]><id|num>"））
            Regex regex = new Regex(TotalReg);  // ({CommentPattern})|({StringPattern})|({IdentifierPattern})|({NumericPattern})|({PunctuatorPattern})
            var matches = regex.Matches(source);
            string matchedstr = "";
            foreach (Match match in matches)
            {
                strs.Add(match.Value);
                matchedstr += match.Value;
            }
            if (source.Length != matchedstr.Length)
            {
                //Console.WriteLine($"Lexemes:\r\n{JsonUtil.ToJson(strs)}");
                throw new Exception($"词法分析器-预处理失败\r\nsource.Length: {source.Length}, matchedstr.Length: {matchedstr.Length}\r\nInput:\r\n{source}\r\nReverse:\r\n{matchedstr}");
            }
            return strs.ToArray();
        }

        /// <summary>
        /// 总表达式 字符串字面量-注释-空格-数值字面量-符号-标识符
        /// </summary>
        public static readonly string TotalReg = @"('.*?')|(/\*(.|\n)*?\*/)|(//.*[\n$])|(\s+)|((?=\s|\b)(\d+)(\.\d+)?(?=\s|\b))|((:=)|(=>)|[<>\+\-\*/=\{\}\(\)\[\];:,\.])|([a-zA-Z][a-zA-Z0-9]*)";
    }
}
