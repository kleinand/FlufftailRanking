using FluffTailRanking.BusinessLayer.BusinessObjects;
using System;
using System.Collections.Generic;

namespace FluffTailRanking.BusinessLayer.Persistence
{     
    /// <summary>
    /// Zusammenfassungsbeschreibung für Class1
    /// </summary>
    public interface IPersistenceManager
    {
	    List<Player> GetAllPlayers();
        List<Team> GetAllTeams();
        List<Game> GetAllGames();

        Player GetPlayerById(int uid);

        int GetWinsOfPlayer(Player player);
        int GetWinsOfTeam(Team team);

        int SavePlayer(Player player);
        int SaveTeam(Team team);
        int SaveGame(Game game);
    }

}