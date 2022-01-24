using LogYourself.Models;
using SQLite;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;

using LogYourself.Models.Base;
using System.Linq;

namespace LogYourself.Services
{
    public class LocalSqlDatabaseService : IDatabaseService
    {
        public const string DatabaseFilename = "UserLogs.db3";

        private const SQLiteOpenFlags _openFlags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string FilePath
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        private SQLiteAsyncConnection _database;
        private static bool _initialized;

        public LocalSqlDatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        public async Task InitializeAsync(string restorePath = "")
        {
            _database = new SQLiteAsyncConnection(string.IsNullOrEmpty(restorePath) ?
                FilePath : restorePath, _openFlags);

            Type[] tables = new Type[]
            {
                typeof(MoodModel),
                typeof(MealModel),
                typeof(SleepModel),
                typeof(SubstanceModel),
                typeof(ActivityModel),
                typeof(SocializationModel)
            };

            if (!_initialized)
            {
                _ = await _database.CreateTablesAsync(CreateFlags.None, tables).ConfigureAwait(false);
                _initialized = true;
            }
        }

        public async Task BackupAsync(string destination) => await _database.BackupAsync(destination);

        public async Task RestoreBackupAsync(string backupPath)
        {
            await _database.CloseAsync();
            await InitializeAsync(backupPath);
        }

        public Task ClearSpecificDatabase(ModelType modelType)
        {
            switch (modelType)
            {
                case ModelType.Activity:
                    return _database.DeleteAllAsync<ActivityModel>();
                case ModelType.Meal:
                    return _database.DeleteAllAsync<MealModel>();
                case ModelType.Mood:
                    return _database.DeleteAllAsync<MoodModel>();
                case ModelType.Substance:
                    return _database.DeleteAllAsync<SubstanceModel>();
                case ModelType.Sleep:
                    return _database.DeleteAllAsync<SleepModel>();
                case ModelType.Socialization:
                    return _database.DeleteAllAsync<SocializationModel>();
                default:
                    throw new ArgumentException("Model type does not exist in db");
            };
        }
        public Task<int> AddOrModifyModelAsync(IModel model)
        {
            try
            {
                if (model.ID != 0)
                    return _database.UpdateAsync(model);
                else
                    return _database.InsertAsync(model);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
        }
        public Task DeleteLog(IModel model) => _database.DeleteAsync(model);
        public Task<List<MoodModel>> GetMoodsAsync() => _database.Table<MoodModel>().ToListAsync();
        public async Task<List<MoodModel>> GetMoodsAsync(DateTime startDate, DateTime endDate)
        {
            List<MoodModel> moods = await GetMoodsAsync();
            IEnumerable<MoodModel> sortedMoods = moods.Where(x => DateInRange(startDate, endDate, x.RegisteredTime));
            sortedMoods.ToList().Sort((t1, t2) => DateTime.Compare(t1.RegisteredTime, t2.RegisteredTime));
            return sortedMoods.ToList();
        }

        public Task<List<MealModel>> GetMealsAsync() => _database.Table<MealModel>().ToListAsync();
        public async Task<List<MealModel>> GetMealsAsync(DateTime startDate, DateTime endDate)
        {
            List<MealModel> meals = await GetMealsAsync();
            IEnumerable<MealModel> sortedMeals = meals.Where(x => DateInRange(startDate, endDate, x.RegisteredTime));
            sortedMeals.ToList().Sort((t1, t2) => DateTime.Compare(t1.RegisteredTime, t2.RegisteredTime));
            return sortedMeals.ToList();
        }

        public Task<List<SleepModel>> GetSleepsAsync() => _database.Table<SleepModel>().ToListAsync();
        public async Task<List<SleepModel>> GetSleepsAsync(DateTime startDate, DateTime endDate)
        {
            List<SleepModel> sleeps = await GetSleepsAsync();
            IEnumerable<SleepModel> sortedSleeps = sleeps.Where(x => DateInRange(startDate, endDate, x.RegisteredTime));
            sortedSleeps.ToList().Sort((t1, t2) => DateTime.Compare(t1.RegisteredTime, t2.RegisteredTime));
            return sortedSleeps.ToList();
        }

        public Task<List<SubstanceModel>> GetSubstancesAsync() => _database.Table<SubstanceModel>().ToListAsync();
        public async Task<List<SubstanceModel>> GetSubstancesAsync(DateTime startDate, DateTime endDate)
        {
            List<SubstanceModel> substances = await GetSubstancesAsync();
            IEnumerable<SubstanceModel> sortedSubstances = substances.Where(x => DateInRange(startDate, endDate, x.RegisteredTime));
            sortedSubstances.ToList().Sort((t1, t2) => DateTime.Compare(t1.RegisteredTime, t2.RegisteredTime));
            return sortedSubstances.ToList();
        }

        public Task<List<ActivityModel>> GetActivitiesAsync() => _database.Table<ActivityModel>().ToListAsync();
        public async Task<List<ActivityModel>> GetActivitiesAsync(DateTime startDate, DateTime endDate)
        {
            List<ActivityModel> activities = await GetActivitiesAsync();
            IEnumerable<ActivityModel> sortedActivities = activities.Where(x => DateInRange(startDate, endDate, x.RegisteredTime));
            sortedActivities.ToList().Sort((t1, t2) => DateTime.Compare(t1.RegisteredTime, t2.RegisteredTime));
            return sortedActivities.ToList();
        }

        public Task<List<SocializationModel>> GetSocialsAsync() => _database.Table<SocializationModel>().ToListAsync();
        public async Task<List<SocializationModel>> GetSocialsAsync(DateTime startDate, DateTime endDate)
        {
            List<SocializationModel> socials = await GetSocialsAsync();
            IEnumerable<SocializationModel> sortedSocials = socials.Where(x => DateInRange(startDate, endDate, x.RegisteredTime));
            sortedSocials.ToList().Sort((t1, t2) => DateTime.Compare(t1.RegisteredTime, t2.RegisteredTime));
            return sortedSocials.ToList();
        }

        private bool DateInRange(DateTime startDate, DateTime endDate, DateTime checkDate) =>
            (checkDate.Date >= startDate.Date && checkDate.Date <= endDate.Date);

    }
}