# ViServiceTest

[�������� ��](https://learn.microsoft.com/ru-ru/dotnet/core/extensions/windows-service "�������� ������ Windows � �������������� BackgroundService")

### �����!
> ������ ����� ��� ���������� ����� �������������� ���� *.dll ������ *.exe � ����� ��� ��������� ��������������� ���������� � ���������� ���������� �������� Windows ���� ���� DLL � ���������� ���������� ���������� ���������� ��������� ������ .NET. �������������� �������� ��. � ����������� �� ������� dotnet ���������� ��������� ������ .NET.

### PowerShell
	sc.exe create ".NET Joke Service" binpath="C:\Path\To\dotnet.exe C:\Path\To\App.WindowsService.dll" 

[�������������](https://learn.microsoft.com/ru-ru/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-6.0&tabs=visual-studio "���������� ASP.NET Core � ������ Windows")