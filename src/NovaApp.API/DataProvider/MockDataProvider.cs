using System;
using System.Collections.Generic;
using System.Linq;
using NovaApp.API.DataObjects;
using NovaApp.API.DataObjects.PlayerObjects;

namespace NovaApp.API.DataProvider
{
    public class MockDataProvider : IDataProvider
    {
        private readonly List<ExtendedPlayerDataObject> _listOfPlayers = new List<ExtendedPlayerDataObject>
        {
            new ExtendedPlayerDataObject{Id = 1, FirstName = "Dmytro", LastName = "Babych", NickName = "d.babych", AvatarFilename = "", ClubId = 1, BirthDate = "1983-01-08", FeePayed = "0"},
            new ExtendedPlayerDataObject{Id = 2, FirstName = "Anna", LastName = "Slienzak", NickName = "Анечка", AvatarFilename = "", ClubId = 2, BirthDate = "1989-11-19", FeePayed = "1"},
            new ExtendedPlayerDataObject{Id = 3, FirstName = "Dmytro", LastName = "Strelchyn", NickName = "Стрела", AvatarFilename = "", ClubId = 1, BirthDate = "", FeePayed = "1"},
            new ExtendedPlayerDataObject{Id = 4, FirstName = "Galina", LastName = "Marchenko", NickName = "Галя", AvatarFilename = "", ClubId = 2, BirthDate = "", FeePayed = "1"},
            new ExtendedPlayerDataObject{Id = 5, FirstName = "Asya", LastName = "Dzyubenka", NickName = "", AvatarFilename = "", ClubId = 2, BirthDate = "", FeePayed = "0"},
            new ExtendedPlayerDataObject{Id = 6, FirstName = "Oleksandr", LastName = "Stakhovsky", NickName = "", AvatarFilename = "", ClubId = 3, BirthDate = "", FeePayed = "1"},
            new ExtendedPlayerDataObject{Id = 7, FirstName = "Ден", LastName = "Жарков", NickName = "", AvatarFilename = "", ClubId = 4, BirthDate = "", FeePayed = "0"},
            new ExtendedPlayerDataObject{Id = 8, FirstName = "Алексей", LastName = "Стабровский", NickName = "Лешечка", AvatarFilename = "", ClubId = 5, BirthDate = "", FeePayed = "0"},
            new ExtendedPlayerDataObject{Id = 9, FirstName = "Влад", LastName = "Паневник", NickName = "", AvatarFilename = "", ClubId = 4, BirthDate = "", FeePayed = "0"},
        };

        private readonly List<ClubDataObject> _listOfClubs = new List<ClubDataObject>
        {
            new ClubDataObject{Id = 0, Name = "Без клуба", Country = "Украина", PlayersNum = 0, FeePayedNum = 0},
            new ClubDataObject{Id = 1, Name = "Nova", City = "Киев", Country = "Украина", PlayersNum = 2, FeePayedNum = 1},
            new ClubDataObject{Id = 2, Name = "Gamble", City = "Киев", Country = "Украина", PlayersNum = 3, FeePayedNum = 2},
            new ClubDataObject{Id = 3, Name = "Gigolo", City = "Киев", Country = "Украина", PlayersNum = 1, FeePayedNum = 1},
            new ClubDataObject{Id = 4, Name = "Impuls", City = "Ивано-Франковск", Country = "Украина", PlayersNum = 2, FeePayedNum = 0},
            new ClubDataObject{Id = 5, Name = "WildWest", City = "Львов", Country = "Украина", PlayersNum = 1, FeePayedNum = 0},
        };

        private readonly List<TransactionDataObject> _listOfTransactions = new List<TransactionDataObject>
        {
            new TransactionDataObject{ Id = 1, PlayerId = 1, Sum = 100, IsFee = "1", FeeYear = "2015", Comment = "", Time = "2016-12-27 17:21:40"},
            new TransactionDataObject{ Id = 2, PlayerId = 1, Sum = 100, IsFee = "1", FeeYear = "2016", Comment = "", Time = "2016-12-27 17:21:42"},
            new TransactionDataObject{ Id = 3, PlayerId = 2, Sum = 100, IsFee = "1", FeeYear = "2017", Comment = "", Time = "2016-12-27 17:21:45"},
            new TransactionDataObject{ Id = 4, PlayerId = 1, Sum = 25.1, IsFee = "0", FeeYear = "", Comment = "На Микстовую Сборную", Time = "2016-12-27 17:22:15"},
            new TransactionDataObject{ Id = 5, PlayerId = 3, Sum = 100, IsFee = "1", FeeYear = "2017", Comment = "", Time = "2016-12-27 17:28:36"},
            new TransactionDataObject{ Id = 6, PlayerId = 4, Sum = 100, IsFee = "1", FeeYear = "2017", Comment = "", Time = "2017-01-19 17:04:35"},
            new TransactionDataObject{ Id = 7, PlayerId = 5, Sum = 100, IsFee = "1", FeeYear = "2016", Comment = "", Time = "2017-01-19 17:04:55"},
            new TransactionDataObject{ Id = 8, PlayerId = 4, Sum = 50, IsFee = "0", FeeYear = "", Comment = "На Микстовую Сборную", Time = "2017-01-19 17:05:16"},
            new TransactionDataObject{ Id = 9, PlayerId = 6, Sum = 100, IsFee = "1", FeeYear = "2017", Comment = "", Time = "2017-01-19 17:07:23"},
        };

        public List<ExtendedPlayerDataObject> GetPlayers()
        {
            return _listOfPlayers;
        }

        public ExtendedPlayerDataObject GetPlayerById(int id)
        {
            var players = GetPlayers();
            var player = players.FirstOrDefault(x => x.Id == id);

            return player;
        }

        public List<ExtendedPlayerDataObject> GetPlayerByClubId(int id)
        {
            if (id == 0)
            {
                // players without a club
                var playerwWithoutClub = _listOfPlayers.Where(x => !x.ClubId.HasValue).ToList();
                return playerwWithoutClub;
            }

            var allPlayers = GetPlayers();
            var clubPlayers = allPlayers.Where(x => x.ClubId == id).ToList();

            return clubPlayers;
        }

        public List<ClubDataObject> GetClubs()
        {
            return _listOfClubs;
        }

        public ClubDataObject GetClubById(int id)
        {
            var clubs = GetClubs();
            var club = clubs.FirstOrDefault(x => x.Id == id);

            return club;
        }

        public List<TransactionDataObject> GetTransactions()
        {
            return _listOfTransactions;
        }

        public List<TransactionDataObject> GetTransactionByUserId(int userId)
        {
            var transactions = GetTransactions();
            var userTransactions = transactions.Where(x => x.PlayerId == userId).ToList();
            return userTransactions;
        }

        public TransactionDataObject GetTransactionById(int id)
        {
            var transactions = GetTransactions();
            var transaction = transactions.FirstOrDefault(x => x.Id == id);

            return transaction;
        }

        public TransactionDataObject AddTransaction(TransactionDataObject transaction)
        {
            var maxId = _listOfTransactions.Max(x => x.Id);
            transaction.Id = maxId + 1;

            transaction.Time = DateTime.Now.ToString("u");

            _listOfTransactions.Add(transaction);

            return transaction;
        }

        public ExtendedPlayerDataObject AddPlayer(ExtendedPlayerDataObject player)
        {
            var maxId = _listOfPlayers.Max(x => x.Id);
            player.Id = maxId + 1;

            _listOfPlayers.Add(player);

            var club = _listOfClubs.FirstOrDefault(x => x.Id == player.ClubId);
            if (club != null)
            {
                club.PlayersNum++;
                if (player.FeePayed == "1")
                {
                    club.FeePayedNum++;
                }

                return player;
            }

            return player;
        }

        public ClubDataObject AddClub(ClubDataObject club)
        {
            var maxId = _listOfClubs.Max(x => x.Id);
            club.Id = maxId + 1;

            _listOfClubs.Add(club);

            return club;
        }

        public ExtendedPlayerDataObject PatchPlayer(int playerId, ExtendedPlayerDataObject player)
        {
            var originalPlayer = _listOfPlayers.FirstOrDefault(x => x.Id == playerId);
            if (originalPlayer == null)
                return null;

            if (!string.IsNullOrEmpty(player.AvatarFilename))
                originalPlayer.AvatarFilename = player.AvatarFilename;

            if (!string.IsNullOrEmpty(player.BirthDate))
                originalPlayer.BirthDate = player.BirthDate;

            if (player.ClubId != originalPlayer.ClubId)
                originalPlayer.Id = playerId;

            if (!string.IsNullOrEmpty(player.FeePayed))
                originalPlayer.FeePayed = player.FeePayed;

            if (!string.IsNullOrEmpty(player.FirstName))
                originalPlayer.FirstName = player.FirstName;

            if (!string.IsNullOrEmpty(player.LastName))
                originalPlayer.LastName = player.LastName;

            if (!string.IsNullOrEmpty(player.NickName))
                originalPlayer.NickName = player.NickName;

            // extended values

            if (!string.IsNullOrEmpty(player.Email))
                originalPlayer.Email = player.Email;

            if (!string.IsNullOrEmpty(player.FacebookAccessToken))
                originalPlayer.FacebookAccessToken = player.FacebookAccessToken;

            if (!string.IsNullOrEmpty(player.FacebookUserId))
                originalPlayer.FacebookUserId = player.FacebookUserId;

            if (!string.IsNullOrEmpty(player.GoogleIdToken))
                originalPlayer.GoogleIdToken = player.GoogleIdToken;

            if (!string.IsNullOrEmpty(player.Password))
                originalPlayer.Password = player.Password;

            if (!player.FacebookExpiresIn.HasValue)
                originalPlayer.FacebookExpiresIn = player.FacebookExpiresIn;

            return originalPlayer;
        }

        public ExtendedPlayerDataObject PutPlayer(int playerId, ExtendedPlayerDataObject player)
        {
            var originalPlayer = _listOfPlayers.FirstOrDefault(x => x.Id == playerId);
            if (originalPlayer == null)
                return null;

            originalPlayer.AvatarFilename = player.AvatarFilename;

            originalPlayer.BirthDate = player.BirthDate;

            originalPlayer.ClubId = player.ClubId;

            originalPlayer.FeePayed = player.FeePayed;

            originalPlayer.FirstName = player.FirstName;

            originalPlayer.LastName = player.LastName;

            originalPlayer.NickName = player.NickName;

            // extendede values

            originalPlayer.Email = player.Email;

            originalPlayer.FacebookAccessToken = player.FacebookAccessToken;

            originalPlayer.FacebookUserId = player.FacebookUserId;

            originalPlayer.GoogleIdToken = player.GoogleIdToken;

            originalPlayer.Password = player.Password;

            originalPlayer.FacebookExpiresIn = player.FacebookExpiresIn;

            return originalPlayer;
        }

        public void DeletePlayer(int playerId)
        {
            var player = _listOfPlayers.FirstOrDefault(x => x.Id == playerId);
            if (player == null)
                return;

            _listOfPlayers.Remove(player);
        }
    }
}