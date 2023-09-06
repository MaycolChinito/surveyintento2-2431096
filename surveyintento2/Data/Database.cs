using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using surveyintento2.Models;

namespace surveyintento2.Data
{
    public class Database
    {
        SQLiteAsyncConnection basededatos;
        public Database() 
        {

        }
        async Task Init()
        {
            if (basededatos is not null)
                return;

            basededatos = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.flags);
            var result = await basededatos.CreateTableAsync<Survey>();
        }

        public async Task<List<Survey>> GetSurveysAsync()
        {
            await Init();
            return await basededatos.Table<Survey>().ToListAsync();
        }
        public async Task<Survey>GetSurveyAsync(int id)
        {
            await Init();
            return await basededatos.Table<Survey>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public async Task<int> SaveSurveysAsync(Survey survey)
        {
            await Init();
            if (survey.ID != 0)
            {
                return await basededatos.UpdateAsync(survey);
            }
            else
            {
                return await basededatos.InsertAsync(survey);
            }
        }
            public async Task<int> DeleteSurveyAsync(Survey survey) 
            {
            await Init();
            return await basededatos.DeleteAsync(survey);
            }
        
    }
}
