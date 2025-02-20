using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    internal class NeavaMMI_GameComponent : GameComponent
    {
        public static void InitOnLoad()
        {
            foreach (var injuryHediff in DefDatabase<InjuryHediffDef>.AllDefs) 
            {
                if (injuryHediff.applyTag != null)
                {
                    foreach (var tag in injuryHediff.applyTag)
                    {
                        if (!bodyPartTags.ContainsKey(tag))
                        {
                            bodyPartTags[tag] = new List<InjuryHediffDef>();
                        }

                        bodyPartTags[tag].Add(injuryHediff);
                    }
                }

                if (injuryHediff.applyGroup != null)
                {
                    foreach (var group in injuryHediff.applyGroup)
                    {
                        if (!bodyPartGroup.ContainsKey(group))
                        {
                            bodyPartGroup[group] = new List<InjuryHediffDef>();
                        }

                        bodyPartGroup[group].Add(injuryHediff);
                    }
                }
            }

            ModUtils.Msg("Loaded injuries");
        }

        public NeavaMMI_GameComponent(Game game)
        {
            InitOnLoad();
        }

        private static Dictionary<Pawn, Dictionary<BodyPartDef, BodyPartRecord>> bodyPartCache = new Dictionary<Pawn, Dictionary<BodyPartDef, BodyPartRecord>>();

        public static BodyPartRecord GetBodyPart(Pawn pawn, BodyPartDef partDef)
        {
            if (pawn == null || pawn.health == null || partDef == null)
                return null;

            if (!bodyPartCache.TryGetValue(pawn, out var partDict))
            {
                partDict = pawn.health.hediffSet.GetNotMissingParts()
                    .GroupBy(part => part.def)
                    .ToDictionary(group => group.Key, group => group.First());

                bodyPartCache[pawn] = partDict;
            }

            return partDict.TryGetValue(partDef, out var bodyPart) ? bodyPart : null;
        }

        public static void InvalidateCache(Pawn pawn)
        {
            if (pawn != null && bodyPartCache.ContainsKey(pawn))
            {
                bodyPartCache.Remove(pawn);
            }
        }

        public static Dictionary<BodyPartTagDef, List<InjuryHediffDef>> bodyPartTags = new Dictionary<BodyPartTagDef, List<InjuryHediffDef>>();

        public static Dictionary<BodyPartGroupDef, List<InjuryHediffDef>> bodyPartGroup = new Dictionary<BodyPartGroupDef, List<InjuryHediffDef>>();

        public static HashSet<IInjuryEffect> dummyIInjuryEffect = new HashSet<IInjuryEffect>();

    }

}
