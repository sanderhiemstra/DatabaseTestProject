using DatabaseTestProject.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DatabaseTestProject.Data
{
    public static class QuestionDatabase
    {
        public static SQLiteAsyncConnection db;
        public static async Task Init()
        {
            if (db != null)
                return;

            // Gat an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "QuestionDb.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Question>();

        }

        public static async Task AddQuestionAsync(string questionBody)
        {
            await Init();
            var question = new Question(questionBody);
            await db.InsertAsync(question);
        }

        public static async Task RemoveQuestionAsync(int id)
        {
            await Init();
            await db.DeleteAsync<Question>(id);
        }

        public static async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            await Init();

            var question = await db.Table<Question>().ToListAsync();
            return question;
        }

        public static async Task<Question> GetQuestionAsync(int id)
        {
            await Init();

            var question = db.Table<Question>().Where(i => i.Id == id).FirstOrDefaultAsync();
            return await question;
        }

        public static async Task<Question> SaveQuestionAsync(Question question)
        {
            await Init();

            if(question.Id != 0)
            {
                await db.UpdateAsync(question);
                return question;
            }
            else
            {
                await db.InsertAsync(question);
                return question;
            }
        }

        public static async Task DeleteQuestionAsync(Question question)
        {
            await Init();

            await db.DeleteAsync(question);
        }
    }
}
