﻿using SportCalendar.DataAccess.Interfaces;
using SportCalendar.Entity;

namespace SportCalendar.DataAccess.Repositories
{
    public class ActivityRepository(string connectionString) : MsSqlRepositoryBase(connectionString), IActivityRepository
    {
        public async Task<IEnumerable<Activity>> GetActivities(CancellationToken cancellationToken)
        {
            var sql = "SELECT * FROM activities";

            return await Database.LoadData<Activity>(sql, null, cancellationToken);
        }

        public async Task<bool> AddActivity(Activity activity)
        {
            var sql = "INSERT INTO activities (ActivityName, ActivityUnitId) " +
                 "SELECT @ActivityName, @ActivityUnitId WHERE NOT EXISTS ( " +
                 "SELECT 1 FROM activities a WHERE a.ActivityName = @ActivityName);";

            return await Database.SaveData(sql, new { activity.ActivityName, activity.ActivityUnitId });
        }
    }
}
