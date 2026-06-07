[Setup]
AppName=Rock Paper Scissors
AppVersion=1.0.1
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
AppId={{dde294c2-8a5e-43e9-805c-54fc8613310c}

[Files]
Source: "bin\Release\net10.0-windows\publish\win-x64\*"; DestDir: "{app}"; Flags: recursesubdirs

[Icons]
Name: "{group}\RockPaperScissors"; Filename: "{app}\RockPaperScissors.exe"
Name: "{commondesktop}\RockPaperScissors"; Filename: "{app}\RockPaperScissors.exe"; Tasks: desktopicon

[Tasks]
Name: desktopicon; Description: "Create a &desktop shortcut"; GroupDescription: "Additional icons:"

[Run]
Filename: "{app}\RockPaperScissors.exe"; Description: "Launch Rock Paper Scissors"; Flags: nowait postinstall skipifsilent
