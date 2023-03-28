
Requirements
 - .NET Framework 1.1 or above. (I think! ;-) )


Before NT Service install:
 - edit "FileSysWatcher.exe.config" and change the "XPTO" string with your login. The HOMEDIR var should be pointing to your homedir. NOTE: the dir path must end with '\' (reverse slash).


INSTALLING
 - just execute the _InstallWinService.bat script. (Assuming the .NET Framework is installed at "C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\").


UNISTALLING
 - just execute the _UninstallWinService.bat script. (Assuming the .NET Framework is installed at "C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\").


Before NT Service start:
 - edit/remove the files BackInfo.exe, BackInfo.ini, oemsi.bmp, "Start Menu\Programs\Startup\BackInfo.lnk" and "Local Settings\Temp\backinfo.bmp" from your home dir. You can use the files/dirs given, with this release, inside the 4URHomeDir dir.



DISCLAIMER
The author cannot be "found" ... so cannot be present at a "court of law" indicted for damages. ;-)
THIS APPLICATION IS PROVIDED "AS IS", WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED.

LICENSE
Use and abuse it. You may copy/reverse eng./move/delete ... whatever you want.