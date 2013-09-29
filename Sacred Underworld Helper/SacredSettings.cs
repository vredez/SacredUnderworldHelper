using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sacred_Underworld_Helper
{
    struct SacredSettings
    {
        public bool
            AutoSave,
            AutoTrackEnemy,
            ChatAlpha,
            CombineSlots,
            DefaultSkills,
            ExploreMap,
            FirstLogin,
            FontAA,
            FontFilter,
            FontPages,
            ForceBlackShadow,
            FSAAFilter,
            Fullscreen,
            GFX32,
            GFXLimit128,
            Log,
            Logging,
            NetLog,
            PickupAnimation,
            PickupAuto,
            ScreenQuake,
            ShowMovies,
            ShowPotions,
            ShowEnemyInfo,
            TaskbarIcons,
            UniqueColor,
            Violence;

        public int
            AutoSaveDelay,
            ChatDelay,
            ChatLines,
            DetailLevel,
            MinimapAlpha,
            MusicVolume,
            NightDarkness,
            SFXVolume,
            VoiceVolume,
            WarningLevel;


        public static SacredSettings FromFile(string file)
        {
            SacredSettings result = new SacredSettings();

            string[] cfg = File.ReadAllLines(file);
        
            foreach (string line in cfg)
            {
                string[] pair = line.Split(new char[] { ':' }, 2);

                if (pair.Length != 2)
                    continue;

                pair[0] = pair[0].Trim();

                if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {
                    int value;
                    if (!int.TryParse(pair[1], out value))
                        continue;
                    result.AutoSave = value != 0;
                }
                else if (pair[0].Equals("AUTOSAVEDELAY", StringComparison.InvariantCultureIgnoreCase))
                {
                    int value;
                    if (!int.TryParse(pair[1], out value))
                        continue;
                    result.AutoSaveDelay = value;
                }
                else if (pair[0].Equals("AUTOTRACKENEMY", StringComparison.InvariantCultureIgnoreCase))
                {
                    int value;
                    if (!int.TryParse(pair[1], out value))
                        continue;
                    result.AutoTrackEnemy = value != 0;
                }
                else if (pair[0].Equals("CHAT_ALPHA", StringComparison.InvariantCultureIgnoreCase))
                {
                    int value;
                    if (!int.TryParse(pair[1], out value))
                        continue;
                    result.ChatAlpha = value != 0;
                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
                else if (pair[0].Equals("AUTOSAVE", StringComparison.InvariantCultureIgnoreCase))
                {

                }
            }

            return result;
        }

    }
}
