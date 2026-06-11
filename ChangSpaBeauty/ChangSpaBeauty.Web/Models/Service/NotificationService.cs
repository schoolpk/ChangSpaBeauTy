// Web/Services/NotificationService.cs
using ChangSpaBeauty.Web.Models;
using System.Text.Json;

namespace ChangSpaBeauty.Web.Models.Services;

public class NotificationService
{
    private const string Key = "user_notifications_{0}"; // {0} = userId

    public void AddNotification(ISession session, int userId, Notification notification)
    {
        var key = string.Format(Key, userId);
        var list = GetNotifications(session, userId);
        list.Insert(0, notification); // mới nhất lên đầu
        if (list.Count > 20) list = list.Take(20).ToList(); // giới hạn 20
        session.SetString(key, JsonSerializer.Serialize(list));
    }

    public List<Notification> GetNotifications(ISession session, int userId)
    {
        var key = string.Format(Key, userId);
        var json = session.GetString(key);
        return string.IsNullOrEmpty(json)
            ? new List<Notification>()
            : JsonSerializer.Deserialize<List<Notification>>(json)!;
    }

    public void MarkAllRead(ISession session, int userId)
    {
        var key = string.Format(Key, userId);
        session.Remove(key);
    }
}