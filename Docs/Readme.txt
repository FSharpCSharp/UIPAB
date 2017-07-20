User Interface Process Application Block, version 2.0
----------------------------------------------------------

Requirements
------------
- Microsoft(R) .NET Framework version 1.1
- Microsoft Visual Studio(R) 2003 development system
- Microsoft SQL Server(TM) 2000 or Microsoft SQL Server 2000 Desktop Engine (MSDE 2000)
- Internet Information Services version 5.0 or later


Installation
-------------

****** If you plan to install the databases used by the QuickStarts, you must first modify the InstallDB.cmd and 
       UninstallDB.cmd files located in the <installation location>\User Interface Process 2.0\Scripts\ folder so that 
       the script is configured to use the database server that you want the databases installed on. To modify the files, 
       replace the [SERVERNAME] element with the name of the database server you want to work with.

Install the UIP QuickStarts in one of the following ways:

 - Run the InstallDemos.vbs installation script located in the <installation location>\User Interface Process 2.0\Scripts\ 
   folder. 

	-or-

 – Click Start, then click All Programs, then click Microsoft Application Blocks for .NET, then click User Interface 
   Process 2.0, and then click Install QuickStarts.

This does the following:

1. Creates the following virtual directories in the locations identified below:

   - virtual directory  = UIPStoreWebUI_CS
     local path         = <installation location>\QuickStarts\cs\Store\WebUI 

   - virtual directory  = UIPStoreWebUI_VB
     local path         = <installation location>\QuickStarts\VB\Store\WebUI 
 	
2. Creates the UIPState and UIPStore databases. The script connects to the local SqlServer instance with a trusted 
   connection, and drops the database if it already exists. The SQLServer State Persistence provider uses the UIPState 
   database, and the Store Application uses the UIPStore database.

3. Creates the registry key for the SecureSqlServerPersistState or SecureIsolatedStoragePersistence provider 
   implementations. The secure persistence providers use this key to encrypt state data.


Uninstallation
---------------

Uninstall the UIP QuickStarts in one of the following ways:

 - Run the UnInstallDemos.vbs uninstallation script located in the <installation location>\User Interface Process 2.0\Scripts 
   folder.

   -or-

 - Click Start, then click All Programs, then click Microsoft Application Blocks for .NET, then click User Interface 
   Process 2.0, and then click Uninstall QuickStarts.

This does the following:

1.  Removes the Store sample virtual directories.
2.  Optional - Removes the databases.
3.  Optional - Removes the registry key.

 
QuickStarts (located in the <installation location>\QuickStarts\<language> directory)
---------------------------------------------------------------
– AdvancedHostDemo QuickStart: Demonstrates the use of user controls and transitioning between user controls in a 
  Windows Forms application. It also demonstrates floating windows and the extensible configuration schema 
  functionality by adding custom attributes to the <views> section of the configuration file.

– InsuranceClientManagement QuickStart: Demonstrates some of the new functionality that has been added to UIP. 
  Specifically, it demonstrates the shared transitions functionality and handling navigation events in a Windows Forms 
  application. 

– InsurancePurchaseWizard QuickStart: Demonstrates the wizard functionality for UIP in a Windows Forms application. 

– NoNavGraph QuickStart: Demonstrates how you can use the open navigator in a Windows Forms application. This style of 
  navigation allows you to make transitions without having to specify a navigator in the configuration file.

– MultiNavGraph QuickStart: Demonstrates how to chain and nest tasks with multiple graph navigators in a Windows Forms 
  application.

– Store QuickStart: Demonstrates multiple aspects of the UIP Application Block for Windows-based applications and 
  Web applications including user controls and shared transitions. This QuickStart also demonstrates how to prevent 
  random navigation in Web applications. This is accomplished by setting the allowBackButton attribute to false in the 
  application configuration file. When this functionality is disabled, it prevents the user from transitioning back to 
  the previous view by using the Back button. It also prevents users from navigating to views by typing the URL for a 
  particular view.


Troubleshooting and Known Issues
---------------------------------

1. MSDE SQL server instance name issue: If the SQL server instance name for your MSDE is [MachineName\VSDOTNET], 
   you will need to set the connectionString / Server attribute when you run the Store or NoNavGraph QuickStarts that use 
   the UIPStore or run the QuickStarts that use the SqlServerPersistState or SecureSqlServerPersistState providers. 
   The connectionString attribute provides connection information for the SQL Server database and is specified in 
   the <statePersistenceProvider> element of the <objectTypes> section in the configuration file. The connectionString / Server
   attribute must be set to "[MachineName\VSDOTNET]". 
 
2. Issue with Back button functionality: If the Back button attribute in the configuration file is set to false, the 
   random navigation and Back button functionality is disabled. However, if the browser has a non-UIP Web page set as 
   the previous page in its history and the user selects the back button, IIS will load the previous page. This scenario 
   is beyond the scope of the UIP Application Block and should be handled by your application.

3. MSDE issue when using the Store Web application: By default, MSDE sets the authentication mode to Windows 
   authentication mode. Therefore, when you run the Web application version of the Store QuickStart and attempt to 
   login, even though the configuration information is correct, the Quickstart will throw the following error: 
   "Login failed for user 'UIP'. Reason: Not associated with trusted SQL Server connection." To resolve this issue, 
   you will need to change the authentication mode from Windows authentication to Mixed mode authentication. To do this, 
   you will need to change the registry key LoginMode value from 1 to 2 in the following location:

        My Computer\HEKY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\VSDOTNET\MSSQLServer


