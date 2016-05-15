using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Resources
    {
        private int Stone { get; set; }
        private int Wood { get; set; }
        private int Knowledge { get; set; }
        private int Tile { get; set; }

        public Resources(int stone, int wood, int knowledge, int tile)
        {
            Stone = stone;
            Wood = wood;
            Knowledge = knowledge;
            Tile = tile;
        }

        public static Resources operator - (Resources from, Resources what)
        {
            from.Knowledge -= what.Knowledge;
            from.Stone -= what.Stone;
            from.Wood -= what.Wood;
            from.Tile -= what.Tile;

            return from;
        }

        public bool NothingLeft()
        {
            bool result = 
                   Stone <= 0 
                && Wood <= 0 
                && Knowledge <= 0
                && Tile <= 0;

            return result;
        }
    }
}