# Chat History Implementation

This repository contains an implementation of chat history functionality, and it requires **.NET 7.0** to run. The implementation is designed to store and display chat history data with different granularities, such as hourly or minute-by-minute.


## Folders

### Services

The `Services` folder contains two subfolders:

#### MessageFormatters

This folder contains specific message formatters implementations. These formatters are responsible for formatting messages based on the specified granularity, whether it's hourly or minute-by-minute.

#### Persistence

The `Persistence` folder contains a repository simulation used to access chat history data. This simulation operates with in-memory data without the need for external data storage.

### Other Classes

This section includes additional classes used in the project:

- **ChatRoomData.cs**: This class is responsible for loading and managing in-memory chat history data.

- **ChatRoomHistory.cs**: This class simulates the UI part that displays chat history data. You can choose the granularity type (hour or minute) to view chat history.

## Getting Started

To get started with this project, follow these steps:

1. Ensure you have **.NET 7.0** installed on your system.

2. Clone this repository to your local machine.

   ```shell
   git clone https://github.com/your-username/chat-history.git
   ```

3. Build the project using your preferred development environment or the command line.

4. Run the application

