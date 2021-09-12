using HarmonyLib;
using System.Reflection;

namespace InfinitePlanetResources
{
    [HarmonyPatch(typeof(SpaceDestination), "Replenish")]
    public class SpaceDestination_Replenish_Patch : SpaceDestination
    {
        public SpaceDestination_Replenish_Patch(int id, string type, int distance) : base(id, type, distance)
        {
        }

        public static void Postfix(SpaceDestination __instance)
        {
            FieldInfo availableMass_Field = __instance.GetType().GetField("availableMass", BindingFlags.NonPublic | BindingFlags.Instance);
            if (availableMass_Field != null) availableMass_Field.SetValue(__instance, (float)__instance.GetDestinationType().maxiumMass);
        }
     }
    
}