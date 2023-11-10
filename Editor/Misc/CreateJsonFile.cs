#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;
using System.IO;

namespace Aureola
{
    public class CreateJsonFile
    {
        #if UNITY_EDITOR

        [MenuItem("Assets/Create/JSON")]
        public static void CreateFile()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            string filePathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/NewJSONFile.json");

            File.WriteAllText(filePathAndName, "{\n\t\"key\": \"value\"\n}");

            AssetDatabase.Refresh();
            AssetDatabase.ImportAsset(filePathAndName);

            EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(filePathAndName));
        }

        #endif
    }
}
