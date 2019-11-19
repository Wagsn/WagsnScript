using System;
using System.Linq;

namespace WagsnScript
{
    public class Runtime
    {
        public static void Init(string[] args)
        {
            // 解析参数
            // -
            Console.WriteLine($"command arguments: '{string.Join("','", args)}'");
            Console.WriteLine($"run dic: {AppContext.BaseDirectory}");
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "run":
                        if (args.Length > 1)
                        {
                            var arg = args[1];
                            if(arg == "js")
                            {
                                if(args.Length > 2)
                                {
                                    var code = args[2];
                                    using (JavaScriptEngineSwitcher.Core.IJsEngine engine = JavaScript.JsEngine.CreateEngine())
                                    {
                                        Console.WriteLine($"out:{"".PadRight(40, '-')}");
                                        engine.Execute(code);
                                        Console.WriteLine($"out:{"".PadRight(40, '-')}");
                                    }
                                }
                            }
                            var path = System.IO.Path.GetFullPath(arg);
                            Console.WriteLine($"source code file: {path}");
                            if (System.IO.File.Exists(path))
                            {
                                var sourceCode = System.IO.File.ReadAllText(path);
                                Console.WriteLine($"src:{"".PadRight(40, '-')}");
                                Console.WriteLine(sourceCode);
                                Console.WriteLine($"src:{"".PadRight(40, '-')}");
                                if (System.IO.Path.HasExtension(".ws"))
                                {
                                    ILexer lexer = new Lexer();
                                }
                                if (System.IO.Path.HasExtension(".js"))
                                {
                                    using (JavaScriptEngineSwitcher.Core.IJsEngine engine = JavaScript.JsEngine.CreateEngine())
                                    {
                                        Console.WriteLine($"out:{"".PadRight(40, '-')}");
                                        // 执行JS脚本文件
                                        engine.ExecuteFile(path);
                                        //engine.Execute("var a=1+3;if(1)a=5;TestA.Name=a");
                                        Console.WriteLine($"out:{"".PadRight(40, '-')}");
                                    }
                                }
                                #region << 动态编译C#代码 >>
                                // if (System.IO.Path.HasExtension(".cs"))
                                // {
                                //     CSharpCodeProvider provider = new CSharpCodeProvider();
                                //     ICodeCompiler compiler = provider.CreateCompiler();
                                //     CompilerParameters parameters = new CompilerParameters();
                                //     parameters.ReferencedAssemblies.Add("System.dll");
                                //     parameters.GenerateExecutable = false;
                                //     parameters.GenerateInMemory = true;
                                //     CompilerResults cr = compiler.CompileAssemblyFromSource(parameters, sourceCode);
                                //     if(cr.Errors.HasErrors){
                                //         Console.WriteLine("编译错误：");
                                //         Console.WriteLine(string.Join(Environment.NewLine
                                //             , cr.Errors.Cast<CompilerError>()
                                //                 .Select(err => err.ErrorText)));
                                //     } 
                                //     else {
                                //         Assembly assembly = cr.CompiledAssembly;
                                //         var type = assembly.GetType("Program");
                                //         // type.InvokeMember()
                                //     }
                                // }
                                #endregion

                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}