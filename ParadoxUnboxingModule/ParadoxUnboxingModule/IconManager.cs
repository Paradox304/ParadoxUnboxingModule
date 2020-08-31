using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ParadoxUnboxingModule
{
    public class IconManager : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this);
            Player.onPlayerCreated += (p) => LoadItems();
        }

        public void LoadItems()
        {
            var assets = Assets.find(EAssetType.ITEM).Cast<ItemAsset>().ToList();

            foreach (ItemAsset asset in assets)
            {
                var ready = new ItemIconReady((icon) =>
                {
                    AddUnturnedIcon(asset.id, icon.EncodeToPNG());
                });
                ItemTool.getIcon(asset.id, 0, asset.quality, asset.getState(), asset, null, string.Empty, string.Empty, asset.size_x * 250, asset.size_y * 250, false, true, ready);
            }
        }

        public void AddUnturnedIcon(ushort id, byte[] icon)
        {
            if (File.Exists(Main.Instance.path + $"{id}.png"))
                File.Delete(Main.Instance.path + $"{id}.png");
            File.WriteAllBytes(Main.Instance.path + $"{id}.png", icon);
        }
    }
}
