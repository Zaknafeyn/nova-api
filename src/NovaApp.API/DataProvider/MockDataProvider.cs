using System.Collections.Generic;
using System.Linq;
using NovaApp.API.DataObjects;

namespace NovaApp.API.DataProvider
{
    public class MockDataProvider : IDataProvider
    {
        public List<PlayerDataObject> GetPlayers()
        {
            var data = new List<PlayerDataObject>
            {
                new PlayerDataObject{Id = 1, FirstName = "Dmytro", LastName = "Babych", NickName = "d.babych", AvatarFilename = "", ClubId = 1, BirthDate = "1983-01-08", FeePayed = "0"},
                new PlayerDataObject{Id = 2, FirstName = "Anna", LastName = "Slienzak", NickName = "Анечка", AvatarFilename = "", ClubId = 2, BirthDate = "1989-11-19", FeePayed = "1"},
                new PlayerDataObject{Id = 3, FirstName = "Dmytro", LastName = "Strelchyn", NickName = "Стрела", AvatarFilename = "", ClubId = 1, BirthDate = "", FeePayed = "1"},
                new PlayerDataObject{Id = 4, FirstName = "Galina", LastName = "Marchenko", NickName = "Галя", AvatarFilename = "", ClubId = 2, BirthDate = "", FeePayed = "1"},
                new PlayerDataObject{Id = 5, FirstName = "Asya", LastName = "Dzyubenka", NickName = "", AvatarFilename = "", ClubId = 2, BirthDate = "", FeePayed = "0"},
                new PlayerDataObject{Id = 6, FirstName = "Oleksandr", LastName = "Stakhovsky", NickName = "", AvatarFilename = "", ClubId = 3, BirthDate = "", FeePayed = "1"},
                new PlayerDataObject{Id = 7, FirstName = "Ден", LastName = "Жарков", NickName = "", AvatarFilename = "", ClubId = 4, BirthDate = "", FeePayed = "0"},
                new PlayerDataObject{Id = 8, FirstName = "Алексей", LastName = "Стабровский", NickName = "Лешечка", AvatarFilename = "", ClubId = 5, BirthDate = "", FeePayed = "0"},
                new PlayerDataObject{Id = 9, FirstName = "Влад", LastName = "Паневник", NickName = "", AvatarFilename = "", ClubId = 4, BirthDate = "", FeePayed = "0"},
            };

            return data;
        }

        public PlayerDataObject GetPlayerById(int id)
        {
            var players = GetPlayers();
            var player = players.FirstOrDefault(x => x.Id == id);

            return player;
        }

        public List<PlayerDataObject> GetPlayerByClubId(int id)
        {
            var allPlayers = GetPlayers();
            var clubPlayers = allPlayers.Where(x => x.ClubId == id).ToList();

            return clubPlayers;
        }

        public List<ClubDataObject> GetClubs()
        {
            var data = new List<ClubDataObject>
            {
                new ClubDataObject{Id = 1, Name = "Nova", City = "Киев", Country = "Украина", PlayersNum = "3", FeePayedNum = "2"},
                new ClubDataObject{Id = 2, Name = "Gamble", City = "Киев", Country = "Украина", PlayersNum = "2", FeePayedNum = "1"},
                new ClubDataObject{Id = 3, Name = "Gigolo", City = "Киев", Country = "Украина", PlayersNum = "1", FeePayedNum = "1"},
                new ClubDataObject{Id = 4, Name = "Impuls", City = "Киев", Country = "Украина", PlayersNum = "2", FeePayedNum = "0"},
                new ClubDataObject{Id = 5, Name = "WildWest", City = "Киев", Country = "Украина", PlayersNum = "1", FeePayedNum = "0"},
            };

            return data;
        }

        public ClubDataObject GetClubById(int id)
        {
            var clubs = GetClubs();
            var club = clubs.FirstOrDefault(x => x.Id == id);

            return club;
        }
    }
}