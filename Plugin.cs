using BepInEx;
using UnityEngine;

namespace NoMoreCosmetics
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private void Update()
        {
            if (GorillaLocomotion.GTPlayer.Instance == null)
                return;

            foreach (VRRig rig in FindObjectsOfType<VRRig>())
            {
                if (rig == null) continue;

                foreach (Renderer r in rig.GetComponentsInChildren<Renderer>())
                {
                    // Don't disable the main gorilla body!
                    if (rig.mainSkin != null && r == rig.mainSkin)
                        continue;
                    
                    // Don't disable their nametag text
                    if (r.gameObject.name.Contains("Text") || r.gameObject.name.Contains("NameTag") || r.GetComponent<TextMesh>() != null)
                        continue;

                    r.forceRenderingOff = true;
                    r.enabled = false;
                }
            }
        }
    }
}
