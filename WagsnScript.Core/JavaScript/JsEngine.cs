using System;
using System.Collections.Generic;
using System.Text;

namespace WagsnScript.JavaScript
{
    public class JsEngine
    {
        public static JavaScriptEngineSwitcher.Core.IJsEngine CreateEngine()
        {
            var engineSwitcher = JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current;
            engineSwitcher.EngineFactories.Add(new JavaScriptEngineSwitcher.ChakraCore.ChakraCoreJsEngineFactory());
            engineSwitcher.DefaultEngineName = JavaScriptEngineSwitcher.ChakraCore.ChakraCoreJsEngine.EngineName;
            JavaScriptEngineSwitcher.Core.IJsEngine engine = JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current.CreateDefaultEngine();
            // C#中设置JS变量值
            engine.SetVariableValue("pi", 3.1415926);
            // C#向JS注入类型
            //engine.EmbedHostType("Console", typeof(JsConsole));
            // C#向JS注入对象
            engine.EmbedHostObject("console", new JsConsole());
            engine.EmbedHostObject("math", new JsMath());
            engine.EmbedHostObject("file", new JsFile());
            //engine.EmbedHostObject("File", typeof(JsFile));
            engine.SetVariableValue("jsEngineVersion", engine.Version);
            engine.Execute("function version(){ \r\n    return jsEngineVersion; \r\n}");
            engine.Execute("function print(arg){ \r\n    console.log(arg); \r\n}");
            return engine;
        }
    }
}
