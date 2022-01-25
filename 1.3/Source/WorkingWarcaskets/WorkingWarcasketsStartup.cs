using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace WorkingWarcaskets
{
    [StaticConstructorOnStartup]
    public static class WorkingWarcasketsStartup
    {
        static WorkingWarcasketsStartup()
        {
            WorkingWarcasketsSettings settings = WorkingWarcasketsMod.settings;

            foreach (WorkTags wtd in Enum.GetValues(typeof(WorkTags)))
            {
                if (wtd != WorkTags.None && !settings.workTagsSet.ContainsKey(wtd))
                {
                    settings.workTagsSet.Add(wtd, DefDatabase<TraitDef>.GetNamed("VFEP_WarcasketTrait").disabledWorkTags.GetAllSelectedItems<WorkTags>().Contains(wtd));
                }
            }

            WorkingWarcasketsUtils.SetWarcasketTags(WorkingWarcasketsUtils.GetDisabledTags(settings.workTagsSet));

            WorkingWarcasketsUtils.SetWarcasketWorkSpeed(settings.workSpeed);
        }
    }
}
