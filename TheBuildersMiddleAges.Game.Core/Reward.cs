namespace TheBuildersMiddleAges.Game.Core
{
    public class Reward
    {
        public int Coins { get; set; }
        public int VictoryPoints { get; set; }

        public Reward(int victoryPoints, int coins)
        {
            Coins = coins;
            VictoryPoints = victoryPoints;
        }
    }
}