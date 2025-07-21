using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace CoffeeAndTea.HarmonyPatches;

[HarmonyPatch(typeof(JoyGiver_TakeDrug), "BestIngestItem")]
public class JoyGiver_TakeDrug_BestIngestItem
{
    public static void Postfix(Pawn pawn, ref Thing __result)
    {
        var num = Rand.ValueSeeded(pawn.thingIDNumber ^ 0x7D);
        switch (num)
        {
            case < 0.2f:
                return;
            case < 0.6f when __result != null && __result.def == CoffeeAndTeaDefOf.SyrTea:
            {
                var thing = GenClosest.ClosestThing_Global_Reachable(pawn.Position, pawn.Map,
                    pawn.Map.listerThings.ThingsOfDef(CoffeeAndTeaDefOf.SyrCoffee), PathEndMode.OnCell,
                    TraverseParms.For(pawn), 9999f, predicate);
                if (thing != null)
                {
                    __result = thing;
                }

                break;
            }
            case >= 0.6f when __result != null && __result.def == CoffeeAndTeaDefOf.SyrCoffee:
            {
                var thing2 = GenClosest.ClosestThing_Global_Reachable(pawn.Position, pawn.Map,
                    pawn.Map.listerThings.ThingsOfDef(CoffeeAndTeaDefOf.SyrTea), PathEndMode.OnCell,
                    TraverseParms.For(pawn), 9999f, predicate);
                if (thing2 != null)
                {
                    __result = thing2;
                }

                break;
            }
        }

        return;

        bool predicate(Thing t)
        {
            return canIngestForJoy(pawn, t);
        }
    }

    private static bool canIngestForJoy(Pawn pawn, Thing t)
    {
        if (!t.def.IsIngestible || t.def.ingestible.joyKind == null || t.def.ingestible.joy <= 0f || !pawn.WillEat(t))
        {
            return false;
        }

        if (t.Spawned)
        {
            if (!pawn.CanReserve(t))
            {
                return false;
            }

            if (t.IsForbidden(pawn))
            {
                return false;
            }

            if (!t.IsSociallyProper(pawn))
            {
                return false;
            }

            if (!t.IsPoliticallyProper(pawn))
            {
                return false;
            }
        }

        if (t.def.IsDrug && pawn.drugs != null && !pawn.drugs.CurrentPolicy[t.def].allowedForJoy &&
            pawn.story != null && pawn.story.traits.DegreeOfTrait(TraitDefOf.DrugDesire) <= 0)
        {
            return pawn.InMentalState;
        }

        return true;
    }
}