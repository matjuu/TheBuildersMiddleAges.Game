using System;
using System.Collections.Generic;
using TheBuildersMiddleAges.Game.Core;
using TheBuildersMiddleAges.Game.Infrastructure.Models.DTO;

namespace TheBuildersMiddleAges.Game.Utils.Mappers
{
    public class GameStateMapper
    {
        public GameDto Map(Core.Game game)
        {
            List<int> workers = new List<int>();
            List<int> buildings = new List<int>();
            List<PlayerDto> playersDtos = new List<PlayerDto>();

            foreach (var worker in game.GameBoard.Workers)
            {
                workers.Add(worker.Id);
            }
            foreach (var building in game.GameBoard.Buildings)
            {
                buildings.Add(building.Id);
            }

            GameBoardDto gameBoardDto = new GameBoardDto
            {
                Buildings = buildings,
                Workers = workers,
                TopBuilding = game.GameBoard.TopBuilding.Id,
                TopWorker = game.GameBoard.TopWorker.Id
            };

            foreach (var player in game.Players)
            {
                List<WorkerDto> playerWorkers = new List<WorkerDto>();
                List<BuildingDto> playerBuildings = new List<BuildingDto>();
                foreach (var worker in player.Value.Workers)
                {
                    var state = Enum.GetName(typeof(WorkerState), worker.State);
                    WorkerDto workerDto = new WorkerDto
                    {
                        Id = worker.Id,
                        State = state
                    };
                    playerWorkers.Add(workerDto);
                }
                foreach (var building in player.Value.Buildings)
                {
                    List<int> assignedWorkers = new List<int>();
                    foreach (var assignedWorker in building.AssignedWorkers)
                    {
                        assignedWorkers.Add(assignedWorker.Id);
                    }
                    var state = Enum.GetName(typeof(BuildingState), building.State);
                    BuildingDto buildingDto = new BuildingDto
                    {
                        Id = building.Id,
                        State = state,
                        AssignedWorkers = assignedWorkers
                    };
                    playerBuildings.Add(buildingDto);
                }
                PlayerDto playerDto = new PlayerDto
                {
                    Guid = player.Key,
                    Buildings = playerBuildings,
                    Workers = playerWorkers,
                    VictoryPoints = player.Value.VictoryPoints,
                    PlayerCoins = player.Value.Coins
                };
                playersDtos.Add(playerDto);
            }
            var gameState = Enum.GetName(typeof(GameState), game.State);
            
            GameDto gameDto = new GameDto
            {
                Players = playersDtos,
                GameBoard = gameBoardDto,
                State = gameState,
                ActingPlayer = game.GameClock.ActingPlayerGuid,
                RemainingActions = game.GameClock.RemainingActions
            };

            return gameDto;
        }
    }
}
