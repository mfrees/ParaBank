@echo off

::change directory command

cd /d C:\Users\Michael Rees\source\repos\ParaBank\ReportTools

::start a program, command or batch script

start nunit3-console.exe "C:\Users\Michael Rees\source\repos\ParaBank\ParaBank\bin\Debug\ParaBank.dll"

start ReportUnit.exe  "TestResult.xml"
