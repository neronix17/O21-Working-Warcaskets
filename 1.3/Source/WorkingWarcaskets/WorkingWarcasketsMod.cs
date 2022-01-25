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
    public class WorkingWarcasketsMod : Mod
    {
        public static WorkingWarcasketsMod mod;
        public static WorkingWarcasketsSettings settings;

        public WorkingWarcasketsMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<WorkingWarcasketsSettings>();
        }

        public override string SettingsCategory() => "Working Warcaskets";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("Disabled Work Tags");
            listingStandard.Note("This list decides which tags are DISABLED on the warcasket trait, so if it's ticked, it'll be disabled.", GameFont.Tiny);
            listingStandard.GapLine();

            for (int i = 0; i < settings.workTagsSet.Count; i++)
            {
                bool bufferBool = settings.workTagsSet.ElementAt(i).Value;
                listingStandard.CheckboxLabeled(settings.workTagsSet.ElementAt(i).Key.LabelTranslated().CapitalizeFirst(), ref bufferBool);
                settings.workTagsSet[settings.workTagsSet.ElementAt(i).Key] = bufferBool;
            }
            WorkingWarcasketsUtils.SetWarcasketTags(WorkingWarcasketsUtils.GetDisabledTags(settings.workTagsSet));

            listingStandard.AddLabeledSlider("Work Speed Factor: " + settings.workSpeed.ToStringPercent(), ref settings.workSpeed, 0.01f, 2.00f, "Min: 1%", "Max: 200%", 0.01f);
            WorkingWarcasketsUtils.SetWarcasketWorkSpeed(settings.workSpeed);

            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
