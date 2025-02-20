using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    public interface IInjuryEffect
    {
        void ApplyEffect(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn, DamageWorker.DamageResult result, ref HashSet<IInjuryEffect> injuries2);
    }
}
