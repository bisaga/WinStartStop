# WinStartStop

The application is simple windows service which run startup.bat script file on the windows startup and 
shutdown.bat file on the windows shutdown. 

Sample batch files reside in WinStartStop/BatchFiles folder : 

To install service use install_service.bat or command:
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe" "C:\WinStartStop\WinStartStop.exe"

To uninstall service use uninstall_service.bat or command: 
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe" "C:\WinStartStop\WinStartStop.exe" /u

Startup.bat example batch file starting VirtualBox virtual machine: 
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" startvm "Ubuntu1610Server" --type "headless"

Shutdown.bat example batch file shutdown VirtualBox virtual machine: 
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" "controlvm"  "Ubuntu1610Server" "poweroff"

 

 
