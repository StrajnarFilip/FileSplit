using System.Collections.Generic;
namespace FileSplit
{
    public class FileSplitJson
    {
        public string file_name { get; set; }
        public List<string> concatenate_files { get; set; }
    }
}