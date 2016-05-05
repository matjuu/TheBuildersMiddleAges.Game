using TheBuildersMiddleAges.Game.Core;
using TheBuildersMiddleAges.Game.Infrastructure;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class TakeWorkerAction : ActionBase<TakeCardActionResponse>
    {
        public override TakeCardActionResponse Do(ActionRequest request)
        {
            Game = GameContainer.Instance.GetGame(request.GameGuid);
            Player player = TryGetPlayer(request.PlayerGuid);
            Worker worker = Game.TakeWorker(request.WorkerId);

            player.HireWorker(worker);
            Game.GameClock.Tick();
            int newCard = Game.DrawWorker();

            TakeCardActionResponse response = new TakeCardActionResponse
            {
                Success = true,
                NewCard = newCard
            };

            return response;
        }
    }
}