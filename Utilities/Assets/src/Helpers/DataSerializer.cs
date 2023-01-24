using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using HelperPSR.Singletons;
using Unity.VisualScripting;
using UnityEngine;


namespace HelperPSR.DataSerializers
{
[XmlRoot("Data")]
public class DataSerializer : GenericSingleton<DataSerializer>
{
 [SerializeField] public string path;
 private string filePath;
 Encoding encoding= Encoding.UTF8;
 private const string xmlExtension = ".xml";

 public void SaveDataOnMainDirectory<T>(T data)
 {
  path = Application.persistentDataPath;
  SaveData<T>( data);
 }

 private void SaveData<T>(T data)
 {
  StreamWriter streamWriter = new StreamWriter(Path.Combine(path, typeof(T).Name) + xmlExtension, false, encoding);
  XmlSerializer dataSerializer = new XmlSerializer(typeof(T));
  dataSerializer.Serialize(streamWriter, data);
  Debug.Log("Save"+typeof(T).Name);
 }

 public T LoadDataFromDirectory<T>()
 {
  path = Application.persistentDataPath;
  return LoadData<T>();
 }

 private T LoadData<T>()
 {
  filePath = Path.Combine(path, typeof(T).Name + xmlExtension);
  if (File.Exists(filePath))
  {
   FileStream fileStream = new FileStream(filePath, FileMode.Open);
   XmlSerializer dataSerializer = new XmlSerializer(typeof(T));
   T data = (T)dataSerializer.Deserialize(fileStream);
   fileStream.Close();
   Debug.Log(typeof(T).Name+"Data loaded");
  }
  Debug.Log("path not exists");
  return default;
 }
}
}
