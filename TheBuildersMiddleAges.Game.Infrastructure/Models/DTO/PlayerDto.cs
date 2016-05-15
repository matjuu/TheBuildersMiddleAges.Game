using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Infrastructure.Models.DTO
{
    public class PlayerDto
    {
        public Guid Guid { get; set; }
        public List<WorkerDto> Workers { get; set; }
        public List<BuildingDto> Buildings { get; set; }
        public int VictoryPoints { get; set; }
        public int PlayerCoins { get; set; }
    }
}
