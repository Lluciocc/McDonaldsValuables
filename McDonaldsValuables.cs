using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Unity.VisualScripting;
using UnityEngine;

namespace McDonaldsValuables;

[BepInPlugin("Lluciocc.McDonaldsValuables", "McDonaldsValuables", "1.0.2")]
public class McDonaldsValuables : BaseUnityPlugin
{
    internal static McDonaldsValuables Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony? Harmony { get; set; }
    internal HappyMeal? HappyMealInstance { get; private set; }
    internal IceCream? CreamInstance { get; private set; }

    private void Awake()
    {
        Instance = this;

        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;

        HappyMealInstance = this.gameObject.AddComponent<HappyMeal>();
        HappyMealInstance.Debug = true;

        CreamInstance = this.gameObject.AddComponent<IceCream>();

        Patch();
        Banner();

        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
    }

    internal void Patch()
    {
        Harmony ??= new Harmony(Info.Metadata.GUID);
        Harmony.PatchAll();
    }

    internal void Unpatch()
    {
        Harmony?.UnpatchSelf();
    }

    private void Banner()
    {
        Logger.LogInfo("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%%%%%#%%%%%%%%%%#%%%%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%%#+===+#%%%%#+====#%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%#==#%#==#%%#==*%#+=*%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%#=-*%%%*==##==+%%%#==*%%%%%%%%");
        Logger.LogInfo("%%%%%%%#+-+#%%%%=-=+-=#%%%%+-=#%%%%%%%");
        Logger.LogInfo("%%%%%%%*=-+%%%%%+=--=+%%%%%*=-+%%%%%%%");
        Logger.LogInfo("%%%%%%#+-=+%%%%%#=--=+%%%%%#+-+#%%%%%%");
        Logger.LogInfo("%%%%%%#=-=#%%%%%%=--=#%%%%%%+-=*%%%%%%");
        Logger.LogInfo("%%%%%%*=-+#%%%%%%+--=#%%%%%%+--+#%%%%%");
        Logger.LogInfo("%%%%%%*--+%%%%%%%+=-=%%%%%%%+--+#%%%%%");
        Logger.LogInfo("%%%%%#*--+%%%%%%%+=-=%%%%%%%+=-+#%%%%%");
        Logger.LogInfo("%%%%%#*--+%%%%%%%+=-=%%%%%%%+=-=#%%%%%");
        Logger.LogInfo("%%%%%#*==*%%%%%%%%%%%%%%%%%%*+=+#%%%%%");
        Logger.LogInfo("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        Logger.LogInfo("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        Logger.LogInfo("by @Lluciocc # McDonaldsValuables");
    }
}