# Architectural Design Task

You're now responsible for architecting a rover guidance system, it's going to be used by mission control to log
the history and current movements of the rover. The system you design needs to take into consideration the
following requirements: 

- The data is going to be stored in some form of database. What would you choose and where would you host?
- We also want to introduce a dashboard that allows users to view rovers' live movements as well as historic movements. Can you outline an architectural diagram of what technologies, patterns you would use for that data to be updated in the data store as well as viewed by a user. Include details of any frontend and backend considerations. Tips!

- The diagram can be created in a tool of your choice, if you’re struggling for options you can try
[draw.io](http://draw.io/)
- Don't worry about the cleanliness of the diagram, simple boxes and arrows will do

## Solution

- **Rover Guidance API:** • For communication with the rover I would suggest already tested technologies used by Mars rovers: UHF, x-band frequency communication, and reconnaissance orbiters. [https://mars.nasa.gov/msl/spacecraft/rover/communication/](https://mars.nasa.gov/msl/spacecraft/rover/communication/)
- **Database:** At least for this task, data is simple and well structured. Any highly scalable SQL database should do the trick. In real life, it would probably contain all sorts of instrument data. In that case, I would consider using a NoSQL database such as MongoDB.
    
    Because commands and state updates as synchronous (are executed one after another), creation date is the perfect unique primary key.
    

![image](https://user-images.githubusercontent.com/47808459/221586373-db5b3e30-c1d5-48b6-b03b-8df5d0b2dc26.png)
- **UI Dashboard:**  The dashboard client should receive real-time data from the API by using web sockets.
    
    It could use a data visualization library such as D3.js or Chart.js and display the rover movement data in a graphical format.
    
    Any modern web application JS framework (or library pack if we are talking about React.js) could do the trick - it depends on the preference of the developer or market situation.
