using System.IO;
using UnityEngine;

namespace LostMythToolsPackage.Editor
{
#if UNITY_EDITOR
    public abstract class CustomSettings<Tdata, Tself> where Tdata : class, new() where Tself : CustomSettings<Tdata, Tself>
    {
        private static string _path;
        protected static string path
        {
            get
            {
                if (_path == null || _path == "")
                    _path = ($"ProjectSettings/{typeof(Tself).Name}.json");

                return _path;
            }
        }

        private static Tdata _data;
        protected static Tdata Data
        {
            get
            {
                if (_data != null)
                    return _data;

                if (File.Exists(path))
                {
                    Load();
                }
                else
                {
                    _data = new Tdata();
                    Save();
                }

                return _data;
            }

            set { _data = value; }
        }

        public static void Save()
        {
            if (_data == null) return;

            string json = JsonUtility.ToJson(_data);
            File.WriteAllText(path, json);
        }

        public static void Load()
        {
            if (!File.Exists(path)) return;

            string json = File.ReadAllText(path);
            _data = JsonUtility.FromJson<Tdata>(json);
        }
    }
#endif
}
