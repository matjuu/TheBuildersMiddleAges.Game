using TheBuildersMiddleAges.Game.Core;

namespace TheBuildersMiddleAges.Game.Actions.Actions
{
    public class TakeWorkerCardAction : CardAction
    {
        public TakeWorkerCardAction(Core.Game game)
        {
            Game = game;
        }

        public override ActionResponse Do(ActionRequest request)
        {
            Player player = TryGetPlayer(request.PlayerGuid);
            Worker worker = Game.TakeWorker(request.WorkerId);

            player.HireWorker(worker);
            int newCard = Game.DrawWorker();

            ActionResponse response = new ActionResponse
            {
                Success = true,
                NewCard = newCard
            };

            return response;
        }
    }
}