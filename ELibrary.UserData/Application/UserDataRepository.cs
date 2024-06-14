using Ardalis.Result;
using ELibrary.UserData.DataContext;
using ELibrary.UserData.DataContext.Entities;

namespace ELibrary.UserData.Application
{
	public class UserDataRepository
	{
		private readonly UserDataDbContext _dbContext;
        public UserDataRepository(UserDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<DataContext.Entities.UserData>> GetAsync(string userId)
        {
            var data = await _dbContext.UserData.FindAsync(userId);
            if (data is null)
            {
                return Result.NotFound($"Не найдено данных по пользователю {userId}");
            }
            return Result.Success(data);
        }
    }
}
