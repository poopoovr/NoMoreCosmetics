using BepInEx;
using UnityEngine;

namespace NoMoreCosmetics
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private float timer = 0f;

        private void Update()
        {
            if (GorillaLocomotion.GTPlayer.Instance == null)
                return;

            timer += Time.deltaTime;
            if (timer < 1f) return;
            timer = 0f;

            foreach (VRRig rig in FindObjectsOfType<VRRig>())
            {
                if (rig == null) continue;

                foreach (Renderer r in rig.GetComponentsInChildren<Renderer>())
                {
                    if (rig.mainSkin != null && r == rig.mainSkin)
                        continue;
                    
                    if (r.gameObject.name.Contains("Text") || r.gameObject.name.Contains("NameTag") || r.GetComponent<TextMesh>() != null || r.gameObject.name.Contains("face"))
                        continue;

                    r.forceRenderingOff = true;
                    r.enabled = false;
                }
            }
        }
    }
}
