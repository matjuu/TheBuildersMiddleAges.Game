using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace TheBuildersMiddleAges.Game.Core
{
    public class Resources
    {
        public int Stone { get; set; }
        public int Wood { get; set; }
        public int Knowledge { get; set; }
        public int Tile { get; set; }

        public void Add(Resources resources)
        {
            Stone += resources.Stone;
            Wood += resources.Wood;
            Knowledge += resources.Knowledge;
            Tile += resources.Tile;
        }
    }
}