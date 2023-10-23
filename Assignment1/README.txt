Assignment #1
-------------------------------------------------------------------

The goal of the assignment is to simply combine 3 of these programs into a single
program that will recursively read a series of data files in CSV format and enter 
them into a single file.

The program must log the amount of time it takes to read the files in each directory 
and the time it takes to write the files to a file using the logger.

## IMPLEMENTATION DESCRIPTION. ##
################################
# Program Structure explain
The program files include 
- Exception.cs, 
- SimpleCSVParser.cs, 
- DirWalker.cs, 
- CustomerInfo.cs, 
- TestProgram.cs

Exception, SimpleCSVParser and DirWalker are the programs combined to recursively read a 
series of data files in CSV Format and enter thme into a single file. 

The TestProgram file is the Starter/Main program and the CustomerInfo program models customers
and their attribute/info

The Program uses the Logger to log error and information both to the console and the a file in the 
build

The intermediate and end result of the program include 
- How long it took for files in directory to be read.
- The total execution time in milliseconds
- The total number of valid row data from the csv data read
- The total number of skipped rows from the csv data read
- Total time it takes to write to file.

## Explain how to setup the program to run { const } 
To execute the program setup the static fields {OutputDataPath and InputDataPath} in TestProgram.cs.
InputDataPath references the folders/csv files to read in the customer info 
OutputDataPath references the single file where all the read in customer info will be written into.