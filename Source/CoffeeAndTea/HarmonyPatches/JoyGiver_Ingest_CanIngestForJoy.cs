using HarmonyLib;
using RimWorld;
using Verse;

namespace CoffeeAndTea.HarmonyPatches;

[HarmonyPatch(typeof(JoyGiver_Ingest), "CanIngestForJoy")]
public class JoyGiver_Ingest_CanIngestForJoy
{
    public static void Postfix(Pawn pawn, Thing t, ref bool __result)
    {
        if (pawn.health.hediffSet.HasHediff(CoffeeAndTeaDefOf.SyrCoffeeHigh) && t.def == CoffeeAndTeaDefOf.SyrTea)
        {
            __result = false;
        }

        if (pawn.health.hediffSet.HasHediff(CoffeeAndTeaDefOf.SyrTeaHigh) && t.def == CoffeeAndTeaDefOf.SyrCoffee)
        {
            __result = false;
        }
    }
}