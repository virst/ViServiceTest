# ViServiceTest

[Основано на](https://learn.microsoft.com/ru-ru/dotnet/core/extensions/windows-service "Создание службы Windows с использованием BackgroundService")

### Важно!
> Вместо этого для публикации можно скомпилировать файл *.dll вместо *.exe и тогда при установке опубликованного приложения в диспетчере управления службами Windows этот файл DLL и управление установкой передается интерфейсу командной строки .NET. Дополнительные сведения см. в справочнике по команде dotnet интерфейса командной строки .NET.

### PowerShell
	sc.exe create ".NET Joke Service" binpath="C:\Path\To\dotnet.exe C:\Path\To\App.WindowsService.dll" 

[Дополнительно](https://learn.microsoft.com/ru-ru/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-6.0&tabs=visual-studio "Размещение ASP.NET Core в службе Windows")