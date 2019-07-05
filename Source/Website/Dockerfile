ARG sdkImageTag=3.5-windowsservercore-ltsc2019
FROM mcr.microsoft.com/dotnet/framework/aspnet:${sdkImageTag}

WORKDIR /
RUN powershell Invoke-WebRequest https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile \Windows\nuget.exe; \
    \Windows\nuget.exe install WebConfigTransformRunner -Version 1.0.0.1
RUN powershell $PSVersionTable.PSVersion
EXPOSE 80

COPY TransformScripts/Set-WebConfigSettings.ps1 ./Set-WebConfigSettings.ps1
COPY TransformScripts/Startup.ps1 ./Startup.ps1

WORKDIR /inetpub/wwwroot
COPY obj/Docker/publish .

ENTRYPOINT ["powershell.exe", "c:\\Startup.ps1"]