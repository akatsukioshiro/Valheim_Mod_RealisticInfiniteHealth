using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ValheimModifications
{
    [BepInPlugin("comoratehiruki.InfiniteHealth", "Infinite Health", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class InfiniteHealth : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("comoratehiruki.InfiniteHealth");
        


        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Character), nameof(Character.SetHealth))]
        class Health_Patch
        {
            static void Prefix(ref float health, Character __instance)
            {
                if (health <= 0f && __instance.IsPlayer())
                {
                    Debug.Log($"Current Health: {health}");
                    health = 25f;
                    Debug.Log($"Modified Base Health: {health}");
                }
            }
        }
    }
}