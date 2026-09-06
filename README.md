# May Nhac

A friendly Windows calendar reminder app with a personal character icon, built with WPF and .NET 8.

## Features

- Upcoming calendar view
- Custom reminder characters
- Sound toggle
- Test reminder action
- Google Calendar OAuth sign-in and read-only event sync

## Run

```powershell
dotnet run --project .\LichNhac.csproj
```

## Download for Windows

Download `MayNhac.exe` from the latest GitHub Release and run it directly. The release is self-contained for Windows x64 and does not require a separate .NET installation.

## Google Calendar setup

1. Enable the Google Calendar API in Google Cloud Console.
2. Create an OAuth Client ID for a Desktop app.
3. Download the JSON file and rename it to `credentials.json`.
4. Place it next to `MayNhac.exe`.
5. Click `Đăng nhập Google Calendar` and approve read-only calendar access.

The app stores the OAuth token under the local application data folder and reads the primary calendar for the next seven days. The public release does not include any private Google credential.
