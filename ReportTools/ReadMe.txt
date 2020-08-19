To run test cases using the nunit3-console runner following these steps:

Preconditions
You need Nunit.ConsoleRunner from NuGet
You need ReportUnit
Create a folder in your project called Reporting Tools
Place the Nunit.ConsoleRunner files and ReportingUnit.exe from ReportUnit in the Reporting Tools folder


1. Open a command prompt window
2. Navigate to the Reporting Tools folder and enter the following to execute the test
C:\Users\user name\source\repos\ParaBank\ReportTools>nunit3-console.exe "C:\Users\user name\source\repos\ParaBank\ParaBank\bin\Debug\ParaBank.dll"
3. The previous step will generate a TestResult.xml file which we will convert to html
4. Enter the following in the comand prompt 
C:\Users\user name\source\repos\ParaBank\ReportTools>ReportUnit.exe "TestResult.xml"
5. You will now have a TestResult.html 