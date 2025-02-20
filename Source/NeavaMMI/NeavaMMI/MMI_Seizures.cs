using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace NeavaMMI
{
    public class MMI_Seizures : HediffWithComps
    {
        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostAdd(dinfo);

            if (pawn != null && !pawn.Dead)
            {
                int stunDuration = Rand.RangeInclusive(120, 180);
                pawn.stances.stunner.StunFor(stunDuration, null, true);
            }
        }
    }
}
