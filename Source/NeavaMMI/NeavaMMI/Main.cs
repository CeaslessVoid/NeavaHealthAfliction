using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            Main.HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

        }

        public static Harmony HarmonyInstance = new Harmony("Neava.HealthAfflictions.Base");


        public static bool IsCEActive()
        {
            return ModLister.HasActiveModWithName("Combat Extended");
        }

    }
}
