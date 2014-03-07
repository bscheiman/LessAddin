using System;
using System.IO;
using MonoDevelop.Core;
using MonoDevelop.Ide.CustomTools;
using MonoDevelop.Projects;
using dotless.Core;

namespace LessAddin {
	public class LessToCssGenerator : ISingleFileCustomTool {
		public IAsyncOperation Generate(IProgressMonitor monitor, ProjectFile file, SingleFileCustomToolResult result) {
			return new ThreadAsyncOperation(() => {
				var dest = file.FilePath.ChangeExtension(".css");
				var src = File.ReadAllText(file.FilePath);
				var css = Less.Parse(src);
				var now = DateTime.Now;

				result.GeneratedFilePath = dest;

				File.WriteAllText(dest, string.Format("/* Generated on: {0} @ {1} */{2}{2}{3}", now.ToLongDateString(), now.ToLongTimeString(), Environment.NewLine, css));
			}, result);
		}
	}
}

