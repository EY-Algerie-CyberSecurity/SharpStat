# SharpStat

C# utility that uses WMI to run "cmd.exe /c netstat -ano", save the output to a file, then use SMB to read and delete the file remotely

## Description

This script will attempt to connect to all the supplied computers and use WMI to execute `cmd.exe /c netstat -ano > <file>`. The file the output is saved to is specified by '-file'. Once the netstat command is running, the output is read via remote SMB call and then deleted.
The script will save the result on an output files in two format (.txt and .csv), you have to indicate juste the name of the file.

While this isn't the stealthiest of scripts (because of the cmd.exe  execution and saving to a file), sometimes you gotta do what you gotta do. An alternative would be to use WMI to remotely query netstat information, but that WMI class is only available on Win10+ systems, which isn't ideal.  This solution at least works for all levels of operating systems.


## Usage

     Mandatory Options:
         -file         = This is the file that the output will be saved in 
                         temporarily before being remotely read/deleted
         -output       = This is the file that the output will be saved and returned to you

     Optional Options:
         -computers    = A list of systems to run this against, separated by commas
            [or]
         -dc           = A domain controller to get a list of domain computers from
         -domain       = The domain to get a list of domain computers from



## Examples
          
         SharpStat.exe -file "C:\Users\Public\test.txt" -computers 127.0.0.1 -output "C:\Users\Public\result"
         SharpStat.exe -file "C:\Users\Public\test.txt" -domain lab.raikia.com -dc lab.raikia.com
         SharpStat.exe -file "C:\Users\Public\test.txt" -computers "wkstn7.lab.raikia.com,wkstn10.lab.raikia.com"

## Screenshot

![img](https://github.com/EY-Algerie-CyberSecurity/SharpStat/tree/mehdi_DEV/SharpStat/img/Capture.PNG)

## OnDevlopment

- Working on the file out (txt, csv)
- Working on merge that result file with Neo4j (Engineered for Connected Data) 


## Forked from
https://github.com/Raikia/SharpStat

## License

[MIT](https://choosealicense.com/licenses/mit/)
