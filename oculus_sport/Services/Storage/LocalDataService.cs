using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oculus_sport.Services.Storage
{
    public class LocalDataService : IDatabaseService
    {
        public Task<T> GetItemAsync<T>(string id) where T : class
        {
            // Implementation for getting an item from SQLite
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetItemsAsync<T>() where T : class
        {
            // Implementation for getting items from SQLite
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync<T>(T item)
        {
            // Implementation for adding an item to SQLite
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync<T>(T item)
        {
            // Implementation for updating an item in SQLite
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync<T>(string id)
        {
            // Implementation for deleting an item from SQLite
            throw new NotImplementedException();
        }
    }
}
