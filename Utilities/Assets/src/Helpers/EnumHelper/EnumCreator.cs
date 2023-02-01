#if UNITY_EDITOR
using System;
using UnityEditor;
using System.IO;
using UnityEngine;

namespace HelperPSR.Enums
{
    /*
    public class EnumCreator : EditorWindow
    {
        private bool currentIsValid;


        [MenuItem("Enum Creator")]
        public static void Init()
        {
            
        }

        private void OnGUI()
        {
            currentIsValid = EnumsDataSO.current != null;
            if (currentIsValid) GUI.enabled = false;
            else GUI.enabled = true;
            string enumDataSOPath = "";
            enumDataSOPath = GUILayout.TextField(enumDataSOPath);

            if (GUILayout.Button("Create Enums Data SO"))
            {
                var enumsDataSo = CreateInstance<EnumsDataSO>();
               
                AssetDatabase.CreateAsset(enumsDataSo, Application.dataPath+enumDataSOPath+"EnumsDataSO.cs");
                // create enums le script 
                EnumsDataSO.current = enumsDataSo;
                AssetDatabase.Refresh();
            }

            if (currentIsValid) GUI.enabled = true;
            else GUI.enabled = false;
            string enumsPath = ""; 
      
        
            if (GUILayout.Button("Update Enums"))
            {
                using (StreamWriter streamWriter = new StreamWriter(enumsPath))
                {
                    streamWriter.WriteLine("namespace HelperPSR.Enums");
                    streamWriter.WriteLine("{");
                    streamWriter.WriteLine("public static class Enums");
                    streamWriter.WriteLine("{");
                foreach (EnumData enumData in EnumsDataSO.current.enumsData)
                {
               
                    streamWriter.WriteLine("public enum " + enumData.enumName);
                    streamWriter.WriteLine("{");
                    for (int i = 0; i < enumData.enumValues.Length; i++)
                    {
                        streamWriter.WriteLine("\t" +enumData.enumValues[i] + ",");
                    }
                    streamWriter.WriteLine("}");
                }
                streamWriter.WriteLine("}");
                streamWriter.WriteLine("}");
                }
                AssetDatabase.Refresh();
            }
        }
    }
    */
}
#endif
