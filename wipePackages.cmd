@echo off
move /Y packages\repositories.config .\repositories.config.backup
rmdir /S /Q packages
mkdir packages
move /Y repositories.config.backup packages\repositories.config
