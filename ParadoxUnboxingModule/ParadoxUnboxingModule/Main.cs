using SDG.Framework.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ParadoxUnboxingModule
{
    public class Main : IModuleNexus
    {
        public static GameObject gameObject;
        public static Main Instance { get; set; }
        public string path = Directory.GetCurrentDirectory() + "/Modules/ParadoxUnboxingModule/Icons/";

        public void initialize()
        {
            Instance = this;

            gameObject = new GameObject("ParadoxUnboxingModule");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<IconManager>();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void shutdown()
        {
            UnityEngine.Object.Destroy(gameObject.GetComponent<IconManager>());
        }
    }
}
