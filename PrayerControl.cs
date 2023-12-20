using System;
using Microsoft.Maui.Animations;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;

namespace Church_Demo
{
	public class PrayerControl
	{
        private ObservableCollection<Prayer> prayers;
        public ObservableCollection<Prayer> Prayers
        {
            get { return prayers; }
            set
            {
                prayers = value;
            }
        }

        //private ObservableCollection<Prayer> doneprayers;
        //public ObservableCollection<Prayer> DonePrayers
        //{
        //    get { return doneprayers; }
        //    set
        //    {
        //        doneprayers = value;
        //    }
        //}

        //private ObservableCollection<Prayer> nameprayers;
        //public ObservableCollection<Prayer> NamePrayers
        //{
        //    get { return nameprayers; }
        //    set
        //    {
        //        nameprayers = value;
        //    }
        //}
        public PrayerControl()
        {
            //var settings = MongoClientSettings.FromConnectionString("mongodb://RavineRepairCluster:Conman00116@ac-xt6a8is-shard-00-00.4dk2ijk.mongodb.net:27017,ac-xt6a8is-shard-00-01.4dk2ijk.mongodb.net:27017,ac-xt6a8is-shard-00-02.4dk2ijk.mongodb.net:27017/?ssl=true&replicaSet=atlas-onj6td-shard-0&authSource=admin&retryWrites=true&w=majority");
            //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://BeyondUnited:BrigandConnor@prayerrequests.9wr50hy.mongodb.net/?retryWrites=true&w=majority");
            var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("PrayerRequests");
            var collection = database.GetCollection<BsonDocument>("Prayers");
            var cursor = collection.Find(new BsonDocument()).ToCursor();
            Prayers = new ObservableCollection<Prayer>();
            //DonePrayers = new ObservableCollection<Prayer>();
            //NamePrayers = new ObservableCollection<Prayer>();

            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine("FOUND DOCUMENTS");
                BsonElement PrayerContentsSet, NameSet, isAnonymousSet;
                PrayerContentsSet = document.GetElement("PrayerContents");
                NameSet = document.GetElement("Name");
                isAnonymousSet = document.GetElement("isAnonymous");
                if (isAnonymousSet.ToString() == "isAnonymous=True")
                {
                    //Add Anonymous Tickets
                    Prayers.Add(new Prayer()
                    {
                        Name = "Anonymous",
                        PrayerContents = PrayerContentsSet.ToString().Replace("PrayerContents=", ""),
                        PostedName = NameSet.ToString().Replace("Name=", ""),
                    });
                }
                else
                {

                    //Add Tickets
                    Prayers.Add(new Prayer()
                    {
                        Name = NameSet.ToString().Replace("Name=", ""),
                        PrayerContents = PrayerContentsSet.ToString().Replace("PrayerContents=", ""),
                        PostedName = NameSet.ToString().Replace("Name=", ""),
                    });
                }
            }
        }
	}
}

