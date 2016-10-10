# Traffic
Traffic Jam Project Solution

The project is implemented by a .NET web application.

Model folder:
 It contains the data structures(classes) for representing the Node, Street and Traffic data.

App_Data folder:
 It contains InputParser.cs, Reader.cs and Utility.cs

 InputParse.cs:
 It includes four classes: InputParser, NodeParser, StreetParser and TrafficParser.
 InputParser is an interface for parsing the input.
 NodeParser,StreetParser and TrafficParser are the actual implementation for parsing different data (Nodes data, Street Data and Traffic Data).

 Reader.cs:
 It includes three classes: Reader, DocumentReader and DatDocumentReader.
 Reader is an interface and DocumentReader is an abstract class for reading files.
 DatDocumentReader is the actual implementation of reading files.

 Utility.cs: It is a helper class used to check if the actual number of data equal to the total number of data claimed in the file.

Controllers folder:
 TrafficController: it is responsible for controlling the flow of the application execution.

View folder:
 ShowInfo.cshtml: it is the view for displaying all the data to user by data grid (using Kendo UI framework).

 ProcessDrawingData: it shows the graphical representation of street plan. It takes the street and nodes data from the server side and draws them into lines.

Implementation explanation: 
This application is following MVC design pattern and SOLID principle. 
In the front-end, showing the data is implemented by grid of Kendo UI framework. 
This is because I think using grid to display data is more straight forward. 
The graphical representation of street plan is drawn by using HTML5 Canvas.
