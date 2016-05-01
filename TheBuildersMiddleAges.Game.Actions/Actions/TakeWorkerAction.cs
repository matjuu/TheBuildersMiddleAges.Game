using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class TakeWorkerAction : ActionBase<TakeCardActionResponse>
    {
        public TakeWorkerAction(Core.Game game)
        {
            Game = game;
        }

        public override TakeCardActionResponse Do(ActionRequest request)
        {
            Player player = TryGetPlayer(request.PlayerGuid);
            Worker worker = Game.TakeWorker(request.WorkerId);

            player.HireWorker(worker);
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