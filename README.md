## Exercise

After NASA’s New Horizon successfully flew past Jupiter, they now plan to land a Jupiter Rover to further investigate the surface. You are responsible for developing an API that will allow the Rover to move around the planet. As you won’t get a chance to fix your code once it is onboard, you are expected to use test driven development. To simplify navigation, the planet has been divided up into a grid. The rover's position and location is represented by a combination of x and y coordinates and a letter representing one of the four cardinal compass points. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North. Assume that the movement directly North from (x, y) is (x, y+1). In order to control a rover, NASA sends a simple string of letters. The only commands you can give the rover are ‘F’,’B’,’L’ and ‘R’

● Implement commands that move the rover forward/backward (‘F’,’B’). The rover may only move forward/backward by one grid point, and must maintain the same heading.
● Implement commands that turn the rover left/right (‘L’,’R’). These commands make the rover spin 90 degrees left or right respectively, without moving from its current spot.

Here is an example:
● Let's say that the rover is located at 0,0 facing North on a 100x100 grid.
● Given the command "FFRFF" would put the rover at 2,2 facing East.

## Solution

This is a .NET 7 minimal API project, which demonstrates how to build a simple web API using the new minimal API feature in .NET 7.

### **Starting the Project with SDK**

To get started with this project, you'll need to have the following installed on your machine:

- .NET 7 SDK: **[Download and install](https://dotnet.microsoft.com/download/dotnet/7.0)**

Once you have the above installed, you can clone this repository and run the following command to start the application:

```bash
dotnet run
```

This will start the web API on port `:5026`

### **Starting the Project from Visual Studio**

To start the project from Visual Studio, follow these steps:

1. Open Visual Studio and select **Open a project or solution** from the start page, or go to **File > Open > Project/Solution** from the menu bar.
2. Navigate to the directory where you cloned the repository and select the **`.csproj`** file.
3. After the project has been loaded, you can run it by clicking the **Run** button or by pressing **F5** on your keyboard.
4. Visual Studio will start the project and launch a browser window displaying the Swagger UI page, where you can test the three endpoints.
5. To test the endpoints, click on the endpoint in the Swagger UI and click the **Try it out** button. Enter any required parameters and click **Execute** to see the response. You can also test the endpoints using an API client like Postman. To do this, copy the URL of the endpoint you want to test from the Swagger UI and paste it into Postman.

## **Endpoints**

This API has three endpoints:

### **`GET rover/possition`**

This endpoint returns the current position and facing direction of the rover.

### **`POST rover/commands/bulk`**

This endpoint accepts a bulk command for the rover and returns the final position of the rover after executing the commands.

The body of the POST request should be a JSON object with the following structure:

```json
{
  "commands": "FFLRLRFF"
}
```

The **`commands`** property should contain a string of commands to execute, where each character represents a command. Valid commands are **`F`** (move forward), **`B`** (move backward), **`L`** (turn left), and **`R`** (turn right).

### **`POST rover/possition/reset`**

This endpoint resets the position of the rover to the starting position (0, 0, N).
