
@Echo off
csc /t:winexe /out:Stickynote.exe  /R:Microsoft.Win32.Interop.DLL;System.DLL;System.WinForms.DLL;System.Drawing.DLL;System.IO.DLL;System.Data.dll /res:stickynote.sticky.resources sticky.cs 
