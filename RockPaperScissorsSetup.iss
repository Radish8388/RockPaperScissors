[Setup]
AppName=Rock Paper Scissors
AppVersion=1.0
DefaultDirName={autopf}\Radish\RockPaperScissors
DefaultGroupName=Radish
SetupIconFile=paper.ico
UninstallDisplayIcon={app}\RockPaperScissors.exe
LicenseFile=LICENSE.txt
OutputBaseFilename=RockPaperScissorsSetup
ArchitecturesInstallIn64BitMode=x64compatible
ArchitecturesAllowed=x64compatible
AppPublisher=Radish
AppPublisherURL=https://radish-vert.vercel.app

[Files]
Source: "bin\Release\net10.0-windows\publish\win-x64\*"; DestDir: "{app}"; Flags: recursesubdirs

[Icons]
Name: "{group}\RockPaperScissors"; Filename: "{app}\RockPaperScissors.exe"
Name: "{commondesktop}\RockPaperScissors"; Filename: "{app}\RockPaperScissors.exe"; Tasks: desktopicon

[Tasks]
Name: desktopicon; Description: "Create a &desktop shortcut"; GroupDescription: "Additional icons:"

[Run]
Filename: "{app}\RockPaperScissors.exe"; Description: "Launch Rock Paper Scissors"; Flags: nowait postinstall skipifsilent
