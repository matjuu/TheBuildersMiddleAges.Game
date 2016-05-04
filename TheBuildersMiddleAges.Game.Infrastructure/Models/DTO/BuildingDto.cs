using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Infrastructure.Models.DTO
{
    public class BuildingDto
    {
        public int Id { get; set; }
        public string State { get; set; }
        public List<int> AssignedWorkers { get; set; } 
    }
}
