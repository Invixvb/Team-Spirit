using System.Collections.Generic;
using ScriptableObjects;

namespace Configs
{
    public class PublicConfig
    {
        public readonly List<SO_Theme> ThemeList = new();

        public int ThemeSelectedIndex;

        public int LevelSetting;
    }
}
