ARG sdkImageTag=3.5-windowsservercore-ltsc2019
FROM mcr.microsoft.com/dotnet/framework/aspnet:${sdkImageTag}
EXPOSE 80
WORKDIR /inetpub/wwwroot
COPY obj/Docker/publish .