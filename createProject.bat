::set A=%~dp0
::set P=%A:\=/%UnityProject
cd %~dp0
md UnityProject
"%UNITYPATH5%" -createProject UnityProject
pause 