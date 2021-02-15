using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

// Compiler Imports
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace Mono.ScriptingEngine
{
	public class ScriptEngine
	{
		static private CSharpCodeProvider CProvider;
		static private CompilerParameters CParameters;
		static private CompilerResults CResults;
		static private Assembly CompiledAssembly;
		static private Type TokenType;
		static private MethodInfo methodInfo;
		static private object Instance;
		static public void Initialize()
		{
			CProvider = new CSharpCodeProvider();
			CParameters = new CompilerParameters();
			CParameters.GenerateExecutable = false;
			CParameters.GenerateInMemory = true;
		}
		static public bool ExecuteScript(string source)
		{
			try
			{
				// Compile & Error Check
				CResults = CProvider.CompileAssemblyFromSource(CParameters, source);
				if (CResults.Errors.HasErrors) return false;
				CompiledAssembly = CResults.CompiledAssembly;

				// Execute Script
				TokenType = CompiledAssembly.GetType("MonoBehaviour");
				Instance = Activator.CreateInstance(TokenType);
				methodInfo = TokenType.GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
				if (methodInfo == null) return false;
				object result = methodInfo.Invoke(Instance, null);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
