using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileSplit
{
    public class FileHelp
    {
        public static void SplitFile(string file_path, uint number_of_bytes)
        {
            var generated_file_names = new List<string>();
            var file_name = Path.GetFileName(file_path);
            var file_hash_name = Hash.Hex64Hash(file_name);

            using (FileStream read = File.OpenRead(file_path))
            {
                var split_number = 1;
                var buffer = new byte[number_of_bytes];
                while (read.Position < read.Length)
                {
                    var count = read.Read(buffer);
                    var numbered_hash = file_hash_name + "_" + split_number.ToString();
                    generated_file_names.Add(numbered_hash);
                    using (FileStream write = File.OpenWrite(numbered_hash))
                    {
                        write.Write(buffer, 0, count);
                    }
                    if (count < buffer.Length)
                    {
                        WriteJSON(file_name, generated_file_names, file_hash_name);
                        return;
                    }
                    buffer = new byte[number_of_bytes];
                    split_number++;
                }
            }
            WriteJSON(file_name, generated_file_names, file_hash_name);

        }
        private static void WriteJSON(string file_name, List<string> hashed_names, string file_hash_name)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<FileSplitJson>(new FileSplitJson
            {
                file_name = file_name,
                concatenate_files = hashed_names
            });
            File.WriteAllText(file_hash_name + ".json", json);
        }

        public static void CombineFile(string path)
        {

            string[] files_in_directory;
            if (path.EndsWith(".json"))
            {
                files_in_directory = Directory.GetFiles(Path.GetDirectoryName(path));
            }
            else
            {
                files_in_directory = Directory.GetFiles(path);
            }

            var json_file = files_in_directory.First(x => x.EndsWith(".json"));


            var data = System.Text.Json.JsonSerializer.Deserialize<FileSplitJson>(
                File.ReadAllText(json_file)
            );
            using (FileStream write = File.OpenWrite(data.file_name))
            {
                foreach (var file in data.concatenate_files)
                {
                    using (FileStream read = File.OpenRead(Path.Combine(Path.GetDirectoryName(path), file)))
                    {
                        read.CopyTo(write);
                    }
                }
            }

        }
    }
}