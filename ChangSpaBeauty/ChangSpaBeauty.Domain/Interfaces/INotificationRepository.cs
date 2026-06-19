
using ChangSpaBeauty.Domain.Entities;

namespace ChangSpaBeauty.Domain.Interfaces;

public interface INotificationRepository
{
    Task AddAsync(Notification notification);
    Task<List<Notification>> GetByUserAsync(int userId);
    Task MarkAllReadAsync(int userId);
    Task<int> GetUnreadCountAsync(int userId);
}