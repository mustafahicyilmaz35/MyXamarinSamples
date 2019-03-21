using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamarinSqlitepcl.Models;

namespace XamarinSqlitepcl.DataAccess
{
    public class Database
    {
		//database bağlantısını asenkron olarak oluşturacağız.
		readonly SQLiteAsyncConnection _database;

		//const un içinde database bağlantısını oluşturup, daha sonra o bağlantı nesnesi ile model listesi oluşturuyoruz.
		public Database(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<Person>().Wait();
		}

		//Sorgulanan verilerin listelenmesi işi yapılacak.
		public Task<List<Person>> GetPeopleAsync()
		{
			return _database.Table<Person>().ToListAsync();
		}

		//Veritabanına yeni bir kişi veri ekleyeceğiz.
		public Task<int> SavePersonAsync(Person person)
		{
			if(person.ID!=0)
			{
				return _database.UpdateAsync(person);
			}
			else
			{
				return _database.InsertAsync(person);
			}
			
		}

		public async Task<int> DeleteAsync(Person person)
		{
			return await _database.DeleteAsync(person);
		}



    }
}
