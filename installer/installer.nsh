!macro customInstall
  DetailPrint "CH341 sürücüsü kuruluyor..."
  nsExec::ExecToLog '"$INSTDIR\\CH341\\SETUP.EXE" /silent'
!macroend
