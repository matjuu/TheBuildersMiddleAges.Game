using System;
using System.Collections.Generic;

namespace TheBuildersMiddleAges.Game.Infrastructure.Models.DTO
{
    public class GameDto
    {
        public List<PlayerDto> Players { get; set; }
        public GameBoardDto GameBoard { get; set; }
        public string State { get; set; }
        public Guid ActingPlayer { get; set; }
    }
}
