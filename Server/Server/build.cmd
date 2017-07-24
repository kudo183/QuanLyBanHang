rem install dotnet
rem install npm
rem install gulp:    npm install --global gulp-cli
rem create IIS Application named test (No Managed Code, Identity is current loggin window account for sql access)
rem mapping IIS site "Default Web Site" to publish output folder.

%systemroot%\system32\inetsrv\appcmd stop apppool test
%systemroot%\system32\inetsrv\appcmd stop site "Default Web Site"

rem if only run gulp #publish, the command will break (not continue run dotnet build ...)
cmd /c gulp #publish

dotnet build -c Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

%systemroot%\system32\inetsrv\appcmd start apppool test
%systemroot%\system32\inetsrv\appcmd start site "Default Web Site"