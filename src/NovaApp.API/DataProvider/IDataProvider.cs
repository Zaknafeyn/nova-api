using System.Collections.Generic;
using NovaApp.API.DataObjects;

namespace NovaApp.API.DataProvider
{
    public interface IDataProvider
    {
        List<TransactionDataObject> GetTransactions();
        List<TransactionDataObject> GetTransactionByUserId(int userId);
        TransactionDataObject GetTransactionById(int id);

        List<PlayerDataObject> GetPlayers();
        PlayerDataObject GetPlayerById(int id);
        List<PlayerDataObject> GetPlayerByClubId(int id);

        List<ClubDataObject> GetClubs();
        ClubDataObject GetClubById(int id);
    }
}