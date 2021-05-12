using System.Collections.Generic;

namespace OS.Portfolio.VirtualOS.Files
{
	public interface IFilesManager
	{
		public FilesData LoadedFiles { get; }
		
		public bool LoadFromProfile(FilesProfile profile);
		public bool LoadFromFile(string filePath);
		public bool SaveToFile(string filePath, FilesData filesData);
	}
}
