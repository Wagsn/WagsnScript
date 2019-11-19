﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WagsnScript
{
    /// <summary>
    /// 词法分析器(Lexical analyzer)
    /// </summary>
    public class Lexer : ILexer
    {
        /// <summary>
        /// Lexing Lexical(词汇)
        /// </summary>
        /// <param name="source">源代码字符串</param>
        /// <returns>记号流</returns>
        public static List<Token> Lexing(string source)
        {
            return Lexing(Scanning(source));
        }

        /// <summary>
        /// 词法分析
        /// 通过预处理数据输出记号流
        /// 评估器（Evaluator）
        /// 评估器有时会抑制语素，被抑制的语素（例如空白语素和注释语素）随后不会被送入语法分析器。
        /// </summary>
        /// <param name="lexemes">预处理数据</param>
        /// <returns></returns>
        public static List<Token> Lexing(string[] lexemes)
        {
            var tokens = new List<Token>();
            // 行列的改变和\n有关
            var currRow = 0;
            var currCol = 0;
            var currPos = 0;
            Regex IdentifierRegex = new Regex($"({IdReg})");
            Regex NumericRegex = new Regex($"({NumReg})");
            Regex PunctuatorRegex = new Regex($"({PunReg})");
            Regex StringRegex = new Regex($"({StrReg})");
            Regex CommentRegex = new Regex($"({ComReg})");
            Regex WhiteSpaceRegex = new Regex($"(^{WSReg}$)");
            foreach (var lexeme in lexemes)
            {
                // 注释 注释语素
                if (CommentRegex.IsMatch(lexeme))
                {
                    var token = new Token
                    {
                        Type = "Comment",
                        Kind = "CMT",
                        Value = lexeme
                    };
                    token.Loc = new Location
                    {
                        Start = new Position
                        {
                            Line = currRow,
                            Column = currCol
                        },
                        Range = new Range
                        {
                            Start = currPos,
                            End = currPos + lexeme.Length
                        }
                    };
                    // 计算换行数
                    var nlc = Regex.Matches(lexeme, "\n|$").Count;
                    // 没有换行
                    if (nlc == 0)
                    {
                        token.Loc.End = new Position
                        {
                            Line = currRow,
                            Column = currCol + lexeme.Length
                        };
                        currCol += lexeme.Length;
                    }
                    // 有换行
                    else
                    {
                        // 计算末尾行列号
                        currCol = lexeme.Length - (lexeme.LastIndexOf('\n') + 1);
                        currRow += nlc;
                        token.Loc.End = new Position
                        {
                            Line = currRow,
                            Column = currCol
                        };
                    }
                    currPos += lexeme.Length;
                    tokens.Add(token);
                }
                else
                // 空格 空白语素
                if (WhiteSpaceRegex.IsMatch(lexeme))
                {
                    var token = new Token
                    {
                        Type = "WhiteSpace",
                        Kind = "WS",
                        Value = lexeme,
                        Loc = new Location
                        {
                            Start = new Position
                            {
                                Line = currRow,
                                Column = currCol,
                            },
                            Range = new Range
                            {
                                Start = currPos,
                                End = currPos + lexeme.Length
                            }
                        }
                    };
                    // 计算换行数
                    var nlc = Regex.Matches(lexeme, "\n|$").Count;
                    // 没有换行
                    if (nlc == 0)
                    {
                        token.Loc.End = new Position
                        {
                            Line = currRow,
                            Column = currCol + lexeme.Length
                        };
                        currCol += lexeme.Length;
                    }
                    // 有换行
                    else
                    {
                        // 计算末尾行列号
                        currCol = lexeme.Length - (lexeme.LastIndexOf('\n') + 1);
                        currRow += nlc;
                        token.Loc.End = new Position
                        {
                            Line = currRow,
                            Column = currCol
                        };
                    }
                    currPos += lexeme.Length;
                    tokens.Add(token);

                }
                else
                // 字符串字面量
                if (StringRegex.IsMatch(lexeme))
                {
                    tokens.Add(new Token
                    {
                        // 字符串字面量
                        Type = "String",
                        Kind = "STR",
                        Value = lexeme,
                        Loc = new Location
                        {
                            Start = new Position
                            {
                                Line = currRow,
                                Column = currCol
                            },
                            End = new Position
                            {
                                Line = currRow,
                                Column = currCol + lexeme.Length
                            },
                            Range = new Range
                            {
                                Start = currPos,
                                End = currPos + lexeme.Length
                            }
                        }
                    });
                    currCol += lexeme.Length;
                    currPos += lexeme.Length;
                }
                // 标识符
                else if (IdentifierRegex.IsMatch(lexeme))
                {
                    tokens.Add(new Token
                    {
                        // 标识符
                        Type = "Identifier",
                        Value = lexeme,
                        Kind = "ID",
                        Loc = new Location
                        {
                            Start = new Position
                            {
                                Line = currRow,
                                Column = currCol
                            },
                            End = new Position
                            {
                                Line = currRow,
                                Column = currCol + lexeme.Length
                            },
                            Range = new Range
                            {
                                Start = currPos,
                                End = currPos + lexeme.Length
                            }
                        }
                    });
                    currPos += lexeme.Length;
                    currCol += lexeme.Length;
                }
                // 数值字面量
                else if (NumericRegex.IsMatch(lexeme))
                {
                    tokens.Add(new Token
                    {
                        // 数值字面量
                        Type = "Numeric",
                        Kind = "NUM",
                        Value = lexeme,
                        Loc = new Location
                        {
                            Start = new Position
                            {
                                Line = currRow,
                                Column = currCol
                            },
                            End = new Position
                            {
                                Line = currRow,
                                Column = currCol + lexeme.Length
                            },
                            Range = new Range
                            {
                                Start = currPos,
                                End = currPos + lexeme.Length
                            }
                        }
                    });
                    currPos += lexeme.Length;
                    currCol += lexeme.Length;
                }
                // 符号
                else if (PunctuatorRegex.IsMatch(lexeme))
                {
                    var token = new Token
                    {
                        // 符号
                        Type = "Punctuator",
                        Value = lexeme,
                        Loc = new Location
                        {
                            Start = new Position
                            {
                                Line = currRow,
                                Column = currCol
                            },
                            End = new Position
                            {
                                Line = currRow,
                                Column = currCol + lexeme.Length
                            },
                            Range = new Range
                            {
                                Start = currPos,
                                End = currPos + lexeme.Length
                            }
                        }
                    };
                    switch (lexeme)
                    {
                        case "(":
                            token.Kind = "LP";
                            break;
                        case ")":
                            token.Kind = "RP";
                            break;
                        case ";":  // semicolon
                            token.Kind = "SEM";
                            break;
                        default:
                            token.Kind = "UNK"; // Unknown
                            break;
                    }
                    // 符号
                    tokens.Add(token);
                    currPos += lexeme.Length;
                    currCol += lexeme.Length;
                }
            }
            //Console.WriteLine($"Tokens:\r\n{JsonUtil.ToJson(tokens)}");
            //Console.WriteLine($"Tokens:\r\n{JsonUtil.ToJson(tokens.Select(t => new { t.Type, t.Value }))}");  //$"(type: {t.Type}, value: {t.Value})"
            return tokens;
        }

        /// <summary>
        /// 利用正则表达式生成预处理数据
        /// Tokenization
        /// </summary>
        /// <param name="source">源代码</param>
        /// <returns></returns>
        public static string[] Scanning(string source)
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

        IEnumerable<Token> ILexer.Lexing(string[] lexemes)
        {
            return Lexer.Lexing(lexemes);
        }

        /// <summary>
        /// 总表达式 字符串字面量-注释-空格-数值字面量-符号-标识符
        /// </summary>
        public static readonly string TotalReg = @"('.*?')|(/\*(.|\n)*?\*/)|(//.*[\n$])|(\s+)|((?=\s|\b)(\d+)(\.\d+)?(?=\s|\b))|((:=)|(=>)|[<>\+\-\*/=\{\}\(\)\[\];:,\.])|([a-zA-Z][a-zA-Z0-9]*)";

        /// <summary>
        /// 英文字符表达式
        /// </summary>
        public static readonly string LetterReg = @"[a-zA-Z]";

        /// <summary>
        /// 数字字符表达式
        /// </summary>
        public static readonly string DigitReg = @"[0-9]";  // \d

        /// <summary>
        /// 符号表达式（边界符与运算符）Punctuator
        /// </summary>
        public static readonly string PunReg = @"(:=)|(=>)|[<>\+\-\*/=\{\}\(\)\[\];:,\.]";

        ///// <summary>
        ///// 符号表达式（边界符与运算符）
        ///// </summary>
        //private static readonly Regex PunctuatorRegex = new Regex($"({PunctuatorPattern})");

        /// <summary>
        /// 数字表达式(非负浮点数)NumericPattern
        /// </summary>
        public static readonly string NumReg = $@"(?=\s|\b)(\d+)(\.\d+)?(?=\s|\b)";

        /// <summary>
        /// 标识表达式 ({LetterRegex}|_)(_|{DigitRegex}|{LetterRegex})*
        /// IdentifierPattern
        /// </summary>
        public static readonly string IdReg = $@"(?<=\s|\b)({LetterReg}|_)(_|{DigitReg}|{LetterReg})*(?=\s|\b)";

        /// <summary>
        /// 字符串字面量StringPattern
        /// </summary>
        public static readonly string StrReg = $@"'.*?'";

        /// <summary> 
        /// 单行注释 这里没有过滤掉字符串字面量
        /// </summary>
        public static readonly string ComReg = $@"(/\*(.|\n)*?\*/)|(//.*[\n$])";

        /// <summary>
        /// 空格
        /// </summary>
        public static readonly string WSReg = $@"\s+";

        public string Name { get; set; } = "WSLexer";
    }
}
