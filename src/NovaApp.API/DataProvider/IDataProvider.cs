using System.Collections.Generic;
using NovaApp.API.DataObjects;

namespace NovaApp.API.DataProvider
{
    public interface IDataProvider
    {
        List<PlayerDataObject> GetPlayers();
        PlayerDataObject GetPlayerById(int id);
        List<PlayerDataObject> GetPlayerByClubId(int id);
        List<ClubDataObject> GetClubs();
        ClubDataObject GetClubById(int id);
    }
}