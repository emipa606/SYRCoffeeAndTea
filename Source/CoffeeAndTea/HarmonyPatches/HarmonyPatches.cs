using System.Reflection;
using HarmonyLib;
using Verse;

namespace CoffeeAndTea.HarmonyPatches;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("Syrchalis.Rimworld.CoffeeAndTea").PatchAll(Assembly.GetExecutingAssembly());
    }
}