# WinStartStop

The application is simple windows service which run startup.bat script file on the windows startup and 
shutdown.bat file on the windows shutdown. 

## Install service 
- create C:\WinStartStop folder
- copy WinStartStop.exe to the folder 
- add BAT files from /WinStartStop/BatchFiles folder 
- install service with install script
- change username/password on the installed service
- prepare your commands in startup.bat and shutdown.bat
- test if everythings runs with start/stop service directly from Windows Services form

## Authenticate service with your user
After installing service go to Windows Services, search for a "Windows Startup Shutdown Service" and change user in which service runs. 
Use your own username/password, you will probably wont to execute something what you usually run after login to your machine. 
Which user is proper for your use case depend from what do you wan't to do in startup/shutdown script.
 

## Batch files reside in WinStartStop/BatchFiles folder : 

To install service use install_service.bat or command:
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe" "C:\WinStartStop\WinStartStop.exe"

To uninstall service use uninstall_service.bat or command: 
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe" "C:\WinStartStop\WinStartStop.exe" /u

## Batch files
Startup.bat example batch file starting VirtualBox virtual machine: 
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" startvm "Ubuntu1610Server" --type "headless"

Shutdown.bat example batch file shutdown VirtualBox virtual machine: 

"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" "controlvm"  "Ubuntu1610Server" "poweroff"

*** VM shutdown this way DOESNT WORK !!!! ***
Virtual Box claim that user who start VMs is allowed to manage them (as shutdown for example) 
Even if I start service as "my user" with full admin rights, on the shutdown event VBoxManage.exe doesn't find active headless virtual machine. 
Seems like a bug to me ? 

 

 
