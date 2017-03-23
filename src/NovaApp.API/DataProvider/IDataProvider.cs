using System.Collections.Generic;
using NovaApp.API.DataObjects;
using NovaApp.API.DataObjects.PlayerObjects;

namespace NovaApp.API.DataProvider
{
    public interface IDataProvider
    {
        List<TransactionDataObject> GetTransactions();
        List<TransactionDataObject> GetTransactionByUserId(int userId);
        TransactionDataObject GetTransactionById(int id);
        TransactionDataObject AddTransaction(TransactionDataObject transaction);

        List<ExtendedPlayerDataObject> GetPlayers();
        ExtendedPlayerDataObject GetPlayerByEmailOrNull(string email);
        ExtendedPlayerDataObject GetPlayerByFbIdOrNull(string fbId);
        ExtendedPlayerDataObject GetPlayerByVkIdOrNull(string vkId);
        ExtendedPlayerDataObject GetPlayerByGoogleIdOrNull(string googleId);
        ExtendedPlayerDataObject GetPlayerById(int id);
        List<ExtendedPlayerDataObject> GetPlayerByClubId(int id);
        ExtendedPlayerDataObject AddPlayer(ExtendedPlayerDataObject player);
        ExtendedPlayerDataObject PatchPlayer(int playerId, ExtendedPlayerDataObject player);
        ExtendedPlayerDataObject PutPlayer(int playerId, ExtendedPlayerDataObject player);
        void DeletePlayer(int playerId);


        List<ClubDataObject> GetClubs();
        ClubDataObject GetClubById(int id);
        ClubDataObject AddClub(ClubDataObject club);
    }
}