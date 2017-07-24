rem install dotnet
rem install npm
rem install gulp:    npm install --global gulp-cli

%systemroot%\system32\inetsrv\appcmd stop apppool test
%systemroot%\system32\inetsrv\appcmd stop site "Default Web Site"

cmd /c gulp #publish

dotnet build -c Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

%systemroot%\system32\inetsrv\appcmd start apppool test
%systemroot%\system32\inetsrv\appcmd start site "Default Web Site"