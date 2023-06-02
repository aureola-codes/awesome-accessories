using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Aureola.Storage
{
    public class FilesService
    {
        private string _basePath;

        public FilesService()
        {
            _basePath = Application.persistentDataPath;
        }

        public FilesService(string basePath)
        {
            _basePath = basePath;
        }

        public string LoadText(string filepath)
        {
            if (!File.Exists(PreparePath(filepath))) {
                return null;
            }

            return File.ReadAllText(PreparePath(filepath));
        }

        public byte[] LoadBytes(string filepath)
        {
            if (!File.Exists(PreparePath(filepath))) {
                return null;
            }

            return File.ReadAllBytes(PreparePath(filepath));
        }

        public void Save(string filepath, string contents)
        {
            File.WriteAllText(PreparePath(filepath), contents, Encoding.UTF8);
        }

        public void Save(string filepath, byte[] contents)
        {
            File.WriteAllBytes(PreparePath(filepath), contents);
        }

        public void Delete(string filepath)
        {
            File.Delete(PreparePath(filepath));
        }

        public bool Exists(string filepath)
        {
            return File.Exists(PreparePath(filepath));
        }
        
        public void Copy(string source, string destination)
        {
            File.Copy(PreparePath(source), PreparePath(destination), true);
        }

        public void Move(string source, string destination)
        {
            File.Move(PreparePath(source), PreparePath(destination));
        }

        public bool IsDirectory(string filepath)
        {
            return Directory.Exists(PreparePath(filepath));
        }

        public void CreateDirectory(string directory)
        {
            Directory.CreateDirectory(PreparePath(directory));
        }

        public void DeleteDirectory(string directory)
        {
            Directory.Delete(PreparePath(directory), true);
        }

        public List<string> GetDirectoriesIn(string directory, string pattern = "*.*", bool recursive = false)
        {
            List<string> directories = new List<string>();
            foreach (var dirpath in Directory.GetDirectories(PreparePath(directory), pattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) {
                directories.Add(dirpath);
            }

            return directories;
        }

        public List<string> GetFilesIn(string directory, string pattern = "*.*", bool recursive = false)
        {
            List<string> files = new List<string>();
            foreach (var filepath in Directory.GetFiles(PreparePath(directory), pattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) {
                files.Add(filepath);
            }

            return files;
        }

        private string PreparePath(string path)
        {
            if (!path.StartsWith(_basePath)) {
                path = _basePath + "/" + path;
            }

            return path;
        }
    }
}
