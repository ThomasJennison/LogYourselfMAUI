using LogYourself.Models;
using LogYourself.Models.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogYourself.Services
{
    public interface IDatabaseService
    {
        Task InitializeAsync(string restorePath = "");
        Task ClearSpecificDatabase(ModelType type);
        Task<int> AddOrModifyModelAsync(IModel model);
        Task DeleteLog(IModel model);
        Task BackupAsync(string backupPath);
        Task RestoreBackupAsync(string backupPath);

        Task<List<MoodModel>> GetMoodsAsync();
        Task<List<MoodModel>> GetMoodsAsync(DateTime startDate, DateTime endDate);

        Task<List<MealModel>> GetMealsAsync();
        Task<List<MealModel>> GetMealsAsync(DateTime startDate, DateTime endDate);

        Task<List<SleepModel>> GetSleepsAsync();
        Task<List<SleepModel>> GetSleepsAsync(DateTime startDate, DateTime endDate);

        Task<List<SubstanceModel>> GetSubstancesAsync();
        Task<List<SubstanceModel>> GetSubstancesAsync(DateTime startDate, DateTime endDate);

        Task<List<ActivityModel>> GetActivitiesAsync();
        Task<List<ActivityModel>> GetActivitiesAsync(DateTime startDate, DateTime endDate);

        Task<List<SocializationModel>> GetSocialsAsync();
        Task<List<SocializationModel>> GetSocialsAsync(DateTime startDate, DateTime endDate);
    }
}
