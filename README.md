# Network Programming in .NET

This repository presents a sample implementation of the Socket class in .NET. 

The repository contains a client application and a server application. The server application provides weather forecast data (randomly generated) via an API, the client requests data via the API endpoint using the async methods of the Socket class and displays the response in a text box. 

In the event of an exception, the corresponding exception message is displayed in the text box.

![Response](response.png)

## Objectives
- Create an API endpoint
- Establish a client-server socket connection
- Send a GET request to the API endpoint
- Parse and display the response using a Windows Presentation Form (WPF) application

## Tools and dependencies
- Visual Studio 2022
- Microsoft.NETCore.App (8.0.0)
- Microsoft.WindowsDesktop.App.WPF (8.0.0)
- Microsoft.ASPNETCore.App (8.0.0)
- Microsoft.AspNetCore.OpenApi (8.0.0)
- Swashbuckle.AspNetCore (6.4.0)