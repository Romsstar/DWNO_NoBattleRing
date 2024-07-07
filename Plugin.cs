using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;


namespace NoBatttleRing;

[BepInPlugin(GUID, PluginName, PluginVersion)]
[BepInProcess("Digimon World Next Order.exe")]
public class Plugin : BasePlugin
{
    internal const string GUID = "Romsstar.DWNO.NoRing";
    internal const string PluginName = "NoBattleRing";
    internal const string PluginVersion = "1.0";

    public override void Load()
    {
        Awake();
    }

    public void Awake()
    {
        Harmony harmony = new Harmony("Patches");
        harmony.PatchAll();
    }



    [HarmonyPatch(typeof(MainGameManager), "Start")]
    public static class MainGameManagerPatch
    {

        [HarmonyPatch(typeof(MainGameManager), "Start")]
        public static bool Prefix(MainGameManager __instance)
        {
            // Disable the battleArea projector by setting it to null before the method executes
            __instance.m_battleArea = null;
            return true;
        }
    }
}
        
