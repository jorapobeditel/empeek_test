using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TestTask.Models
{
    public class DirectoryModels
    {
        public DirectoryNode GetDirNodeByPath(string path)
        {
            if (Directory.Exists(path))
            {
                return new DirectoryNode(path);
            }
            else return null;
        }
        public List<int> CalculateFilesSize(DirectoryNode node, List<int> sizes)
        {
            const double val = 0.000001;
            foreach (var item in node.Files)
            {
                if (item.Length * val <= 10)
                {
                    sizes[0]++;
                }
                else if (item.Length * val <= 50)
                {
                    sizes[1]++;
                }
                else if (item.Length * val >= 100)
                {
                    sizes[2]++;
                }
            }
            if (node.ChildrenFolders.Count != 0)
            {
                foreach (var item in node.ChildrenFolders)
                {
                    CalculateFilesSize(item, sizes);
                }
            }
            return sizes;
        }
        public DirectoryViewModels FillDirViewModel(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryViewModels model = new DirectoryViewModels();
                DirectoryNode node = GetDirNodeByPath(path);
                model.files = (from files in node.Files select files.Name).ToList();
                model.folders = (from folders in node.ChildrenFolders select folders.Name).ToList();  
                model.path = node.Path;
                model.parentUrl = new DirectoryInfo(path).Parent.FullName;
                model.filesInfo = CalculateFilesSize(node, new List<int>() { 0, 0, 0 });
                return model;
            }
            else return null;
        }
    }
    public class DirectoryNode
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public ICollection<FileInfo> Files { get; set; }
        public DirectoryNode Parent { get; set; }
        public ICollection<DirectoryNode> ChildrenFolders { get; set; }
        public DirectoryNode(string path)
        {
            Path = path;
            Name = new DirectoryInfo(path).Name;
            ChildrenFolders = FillNode(this);
            string[] files = Directory.GetFiles(path);
            Files = (from filesinfo in files select new FileInfo(filesinfo)).ToList();
        }
        private List<DirectoryNode> FillNode(DirectoryNode parent)
        {
            List<DirectoryNode> dirNodes = new List<DirectoryNode>();
            if (Directory.Exists(parent.Path))
            {
                string[] folders = Directory.GetDirectories(parent.Path);
                foreach (string folder in folders)
                {
                    try
                    {
                        DirectoryNode childNode = new DirectoryNode(folder) { Parent = parent };
                        dirNodes.Add(childNode);
                    }
                    catch
                    {
                        //haven't access to this folder
                    }

                }
            }

            return dirNodes;
        }
    }

}
