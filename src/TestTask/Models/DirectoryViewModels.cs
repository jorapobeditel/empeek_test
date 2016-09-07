using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class DirectoryViewModels
    {
        public List<string> folders { get; set; }
        public List<string> files { get; set; }
        public List<int> filesInfo { get; set; }
        public string path { get; set; }
        public string parentUrl { get; set; }
    }
}
