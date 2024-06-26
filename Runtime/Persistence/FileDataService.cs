// using System;
// using System.Collections.Generic;
// using System.IO;
// using UnityEngine;
//
// namespace Persistence {
//     public class FileDataService<T> : IDataService<T> where T : IData{
//         ISerializer serializer;
//         string dataPath;
//         string fileExtension;
//
//         public FileDataService(ISerializer serializer) {
//             this.dataPath = Application.persistentDataPath;
//             this.fileExtension = "json";
//             this.serializer = serializer;
//         }
//
//         string GetPathToFile(string fileName) {
//             return Path.Combine(dataPath, string.Concat(fileName, ".", fileExtension));
//         }
//         
//         public void Save(T data, bool overwrite = true) {
//             string fileLocation = GetPathToFile(data.Name);
//
//             if (!overwrite && File.Exists(fileLocation)) {
//                 throw new IOException($"The file '{data.Name}.{fileExtension}' already exists and cannot be overwritten.");
//             }
//
//             File.WriteAllText(fileLocation, serializer.Serialize(data));
//         }
//
//         public T Load(string name) {
//             string fileLocation = GetPathToFile(name);
//
//             if (!File.Exists(fileLocation)) {
//                 throw new ArgumentException($"No persisted GameData with name '{name}'");
//             }
//
//             return serializer.Deserialize<T>(File.ReadAllText(fileLocation));
//         }
//
//         public void Delete(string name) {
//             string fileLocation = GetPathToFile(name);
//
//             if (File.Exists(fileLocation)) {
//                 File.Delete(fileLocation);
//             }
//         }
//
//         public void DeleteAll() {
//             foreach (string filePath in Directory.GetFiles(dataPath)) {
//                 File.Delete(filePath);
//             }
//         }
//
//         public IEnumerable<string> ListSaves() {
//             foreach (string path in Directory.EnumerateFiles(dataPath)) {
//                 if (Path.GetExtension(path) == fileExtension) {
//                     yield return Path.GetFileNameWithoutExtension(path);
//                 }
//             }
//         }
//     }
// }