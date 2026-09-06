using System.IO; using Google.Apis.Auth.OAuth2; using Google.Apis.Calendar.v3; using Google.Apis.Calendar.v3.Data; using Google.Apis.Services; using Google.Apis.Util.Store;
namespace LichNhac;
public sealed class GoogleCalendarService
{
 private static readonly string[] Scopes = [CalendarService.Scope.CalendarReadonly];
 public async Task<IList<Event>> SignInAndListAsync() { var path = Path.Combine(AppContext.BaseDirectory, "credentials.json"); if (!File.Exists(path)) throw new FileNotFoundException("Missing credentials.json", path); using var stream = new FileStream(path, FileMode.Open, FileAccess.Read); var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MayNhac", "GoogleToken"))); var service = new CalendarService(new BaseClientService.Initializer { HttpClientInitializer = credential, ApplicationName = "May Nhac" }); var request = service.Events.List("primary"); request.TimeMinDateTimeOffset = DateTimeOffset.Now; request.TimeMaxDateTimeOffset = DateTimeOffset.Now.AddDays(7); request.SingleEvents = true; request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime; request.MaxResults = 20; return (await request.ExecuteAsync()).Items ?? []; }
}
