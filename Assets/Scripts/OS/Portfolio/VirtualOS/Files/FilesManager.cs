using System;
using System.Collections.Generic;
using System.IO;
using OS.Utilities;
using UnityEngine;
using Zenject;

namespace OS.Portfolio.VirtualOS.Files  
{
    public class FilesManager : IFilesManager
    {
        public FilesData LoadedFiles { get; private set; }
        
        [Inject] private readonly SignalBus _signalBus;

        public bool LoadFromProfile(FilesProfile profile)
        {
            LoadedFiles = null;
            
            if (profile == null || profile.FilesData == null || profile.FilesData.Files.IsNullOrEmpty())
            {
                return false;
            }
            
            LoadedFiles = profile.FilesData;

            return true;
        }

        public bool LoadFromFile(string filePath)
        {
            LoadedFiles = null;
            
            if (!File.Exists(filePath) || Path.GetExtension(filePath) != FilesManagerConfig.FILES_DATA_EXTENSION)
            {
                return false;
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(json))
            {
                return false;
            }

            try
            {
                LoadedFiles = JsonUtility.FromJson<FilesData>(json);
            }
            catch(Exception exception)
            {
                Debug.LogException(exception);
            }

            return LoadedFiles != null;
        }

        public bool SaveToFile(string filePath, FilesData filesData)
        {
            if (string.IsNullOrEmpty(filePath) || filesData == null)
            {
                return false;
            }

            TextWriter writer = null;

            try
            {
                string json = JsonUtility.ToJson(filesData);
                
                writer = new StreamWriter(filePath, false);
                writer.Write(json);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
                
                return false;
            }
            finally
            {
                writer?.Close();
            }

            return true;
        }
    }
}
