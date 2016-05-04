using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Infrastructure.Models.DTO
{
    public class GameBoardDto
    {
        public List<int> Workers { get; set; }
        public List<int> Buildings { get; set; }
        public int TopWorker { get; set; }
        public int TopBuilding { get; set; }
    }
}
