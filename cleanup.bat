@echo **************************************
@echo clean folders
@echo **************************************

@FOR /D /R %%c IN (obj bin ClientBin TestResults debug release _UpgradeReport_Files) DO @if exist "%%c" (rd /s /q "%%c" & echo Delete %%c)

@echo **************************************
@echo delete files
@echo **************************************

@for /R %%c IN (*.pdb UpgradeLog.XML *.user *.class *.idb *.csc Thumbs.db *.opt *.positions *.tmp *.suo *.gid *.pyc *.pyo *.vbw *.scc *.oca *.obj *.pch *.ncb *.opt *.plg *.positions *.o *.lo *.la #*# .*~ *~ .#*) DO @if exist "%%c" (del /s /f /a "%%c" & echo Delete %%c)

@pause