using DataStorage;

namespace Board
{
    public class ElementDistributor
    {
         /// <summary>
         /// Set the initial distribution of elements depending on the mode
         /// </summary>
         public void SetupInitialDistribution()
         {
             if (GameManager.Mode == GameManager.CatanMode.Basic)
                 SetupBasicDistribution();
             else if (GameManager.Mode == GameManager.CatanMode.Advanced)
                 SetupAdvancedDistribution();
         }
         
         private void SetupBasicDistribution()
         {
             //Destiny: Set initial distribution of elements belonging to red player if there is four players
             if (GameManager.PlayersNumber == 4)
             {
                GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Red)].properties.AddBuilding(8, false, true);
                GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Red)].properties.AddBuilding(28, false, true);
                GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Red)].properties.AddPath(13);
                GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Red)].properties.AddPath(41);
             }
             
             //Destiny: Set initial distribution of elements belonging to yellow player
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Yellow)].properties.AddBuilding(14, false, true);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Yellow)].properties.AddBuilding(40, false, true);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Yellow)].properties.AddPath(15);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Yellow)].properties.AddPath(58);
         
             //Destiny: Set initial distribution of elements belonging to white player
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.White)].properties.AddBuilding(17, false, true);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.White)].properties.AddBuilding(31, false, true);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.White)].properties.AddPath(25);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.White)].properties.AddPath(37);
         
             //Destiny: Set initial distribution of elements belonging to blue player
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Blue)].properties.AddBuilding(39, false, true);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Blue)].properties.AddBuilding(41, false, true);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Blue)].properties.AddPath(56);
             GameManager.Players[GameManager.GetPlayerIdByColor(Player.Player.Color.Blue)].properties.AddPath(52);
         }
          
         private void SetupAdvancedDistribution()
         {
         
         }
    }
}