using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Wrapper
{
	class Program
	{
		static readonly string ModID = "example";

		static void Main(string[] args)
		{
			var launcherArgs = args.ToList();
			var templateDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))));
			var launcherPath = templateDir + "\\engine\\";

			if (!launcherArgs.Any(x => x.StartsWith("Engine.LaunchPath=", StringComparison.Ordinal)))
				launcherArgs.Add("Engine.LaunchPath='" + launcherPath + "'");

			if (!launcherArgs.Any(x => x.StartsWith("Engine.ModSearchPaths=", StringComparison.Ordinal)))
				launcherArgs.Add("Engine.ModSearchPaths='" + templateDir + "\\mods','" + templateDir + "\\engine\\mods'");

			if (!launcherArgs.Any(x => x.StartsWith("Game.Mod=", StringComparison.Ordinal)))
				launcherArgs.Add("Game.Mod=" + ModID);

			Directory.SetCurrentDirectory(launcherPath);
			Environment.CurrentDirectory = launcherPath;
			Console.WriteLine(Directory.GetCurrentDirectory());
			Console.WriteLine(Environment.CurrentDirectory);
			OpenRA.Program.Main(launcherArgs.ToArray());
			/*
			launcherArgs.Add("Engine.LaunchDebugger");
			var psi = new ProcessStartInfo(launcherPath + "OpenRA.Game.exe", string.Join(" ", launcherArgs));
			// psi.UseShellExecute = false;
			// psi.RedirectStandardOutput = true;
			var p = Process.Start(psi);
			Console.ReadKey(true);
			*/
		}
	}
}
