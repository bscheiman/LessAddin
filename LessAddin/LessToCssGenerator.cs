using MonoDevelop.Ide.CustomTools;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using System.IO;
using dotless.Core;

namespace LessAddin {
	public class LessToCssGenerator : ISingleFileCustomTool {
		public IAsyncOperation Generate(IProgressMonitor monitor, ProjectFile file, SingleFileCustomToolResult result) {
			return new ThreadAsyncOperation(() => {
				var dest = file.FilePath.ChangeExtension(".css");
				var src = File.ReadAllText(file.FilePath);

				result.GeneratedFilePath = dest;
				File.WriteAllText(dest, Less.Parse(src));
			}, result);
		}
	}
}

