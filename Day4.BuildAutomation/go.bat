@echo off
rem @svn update>nul
rem @svn info | tools\svn-revision\svn-revision>revision
@for /f " delims==" %%i in (revision) do set /A build= %%i
rem @del revision
@msbuild tertigo.targets /nologo /fl  /p:buildNumber=%build%
@time /t 