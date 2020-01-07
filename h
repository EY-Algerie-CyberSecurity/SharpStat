[33mcommit 3ca678bbe67d59abc5f49e487cc55870d564bae1[m[33m ([m[1;36mHEAD -> [m[1;32mmehdi_DEV[m[33m, [m[1;31morigin/mehdi_DEV[m[33m, [m[1;31morigin/master[m[33m, [m[1;31morigin/HEAD[m[33m, [m[1;31mmas/mehdi_DEV[m[33m, [m[1;32mmaster[m[33m)[m
Author: Mehdi Kerkar <31926014+mehdikerkar@users.noreply.github.com>
Date:   Tue Jan 7 09:34:07 2020 +0000

    Update README.md
    
    A few change on it.
    - command "netstat -ano"
    - OnDev

[1mdiff --git a/README.md b/README.md[m
[1mindex b59e5f7..2872a78 100644[m
[1m--- a/README.md[m
[1m+++ b/README.md[m
[36m@@ -1,10 +1,10 @@[m
 # SharpStat[m
 [m
[31m-C# utility that uses WMI to run "cmd.exe /c netstat -n", save the output to a file, then use SMB to read and delete the file remotely[m
[32m+[m[32mC# utility that uses WMI to run "cmd.exe /c netstat -ano", save the output to a file, then use SMB to read and delete the file remotely[m
 [m
 ## Description[m
 [m
[31m-This script will attempt to connect to all the supplied computers and use WMI to execute `cmd.exe /c netstat -n > <file>`. The file the output is saved to is specified by '-file'. Once the netstat command is running, the output is read via remote SMB call and then deleted.[m
[32m+[m[32mThis script will attempt to connect to all the supplied computers and use WMI to execute `cmd.exe /c netstat -ano > <file>`. The file the output is saved to is specified by '-file'. Once the netstat command is running, the output is read via remote SMB call and then deleted.[m
 [m
 While this isn't the stealthiest of scripts (because of the cmd.exe  execution and saving to a file), sometimes you gotta do what you gotta do. An alternative would be to use WMI to remotely query netstat information, but that WMI class is only available on Win10+ systems, which isn't ideal.  This solution at least works for all levels of operating systems.[m
 [m
[36m@@ -24,7 +24,8 @@[m [mWhile this isn't the stealthiest of scripts (because of the cmd.exe  execution a[m
 [m
 [m
 ## Examples[m
[31m-[m
[32m+[m[41m          [m
[32m+[m[32m         sharpStat.exe -file "C:\Users\Public\test.txt" -computers 127.0.0.1[m
          SharpStat.exe -file "C:\Users\Public\test.txt" -domain lab.raikia.com -dc lab.raikia.com[m
          SharpStat.exe -file "C:\Users\Public\test.txt" -computers "wkstn7.lab.raikia.com,wkstn10.lab.raikia.com"[m
 [m
[36m@@ -32,10 +33,13 @@[m [mWhile this isn't the stealthiest of scripts (because of the cmd.exe  execution a[m
 [m
 ![img](https://i.imgur.com/IYsuRJG.png)[m
 [m
[31m-## Contact[m
[32m+[m[32m## OnDevlopment[m
[32m+[m[32m- Working on the file out (txt, csv)[m
[32m+[m[32m- Working on merge that result file with Neo4j (Engineered for Connected Data)[m[41m [m
 [m
[31m-If you have questions or issues, hit me up at raikiasec@gmail.com or @raikiasec[m
 [m
[32m+[m[32m## Original work[m
[32m+[m[32mhttps://github.com/Raikia/SharpStat[m
 [m
 ## License[m
 [MIT](https://choosealicense.com/licenses/mit/)[m
