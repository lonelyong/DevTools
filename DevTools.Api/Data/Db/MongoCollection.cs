using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace DevTools.Api.Data
{
	public class MongoCollection<T>
	{
		private readonly IMongoCollection<T> collection;

		public MongoCollection(MongoClient mongoClient, string collectionName)
		{
			var db = mongoClient.GetDatabase("");
			collection = db.GetCollection<T>(collectionName);
		}
	}
}
