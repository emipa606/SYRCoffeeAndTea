using HarmonyLib;
using RimWorld;
using Verse;

namespace CoffeeAndTea.HarmonyPatches;

[HarmonyPatch(typeof(DrugPolicyDatabase), "GenerateStartingDrugPolicies")]
public class DrugPolicyDatabase_GenerateStartingDrugPolicies
{
    public static void Postfix(DrugPolicyDatabase __instance)
    {
        var taggedString = "SocialDrugs".Translate();
        var drugPolicy = __instance.AllPolicies.FirstOrDefault(dp => dp.label == taggedString);
        if (drugPolicy == null)
        {
            return;
        }

        drugPolicy[CoffeeAndTeaDefOf.SyrCoffee].allowedForJoy = true;
        drugPolicy[CoffeeAndTeaDefOf.SyrTea].allowedForJoy = true;
        drugPolicy[CoffeeAndTeaDefOf.SyrHotChocolate].allowedForJoy = true;
    }
}