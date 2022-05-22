using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnukhinPr15.Models
{
    class TimeDataBase
    {
        readonly SQLiteAsyncConnection database;

        public TimeDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Time>().Wait();
        }

        public Task<List<Time>> GetTimesAsync()
        {
            //Get all notes.
            return database.Table<Time>().ToListAsync();
        }

        public Task<Time> GetTimeAsync(int id)
        {
            // Get a specific note.
            return database.Table<Time>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTimeAsync(Time note)
        {
            if (note.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteTimeAsync(Time note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }
    }
}
