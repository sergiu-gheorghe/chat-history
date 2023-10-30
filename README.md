# chat-history

Chat history implementation, the solution requires .net 7.0 in order to run.
It consists of the following folders:

Services -> MessageFormatters: 
    Contains specific message formatters implementation hourly or minute by minute

Services -> Persistence:
    Cotains repository simulation to access chat history data, it uses in memory data

Other classes:
ChatRoomData.cs -> used to load memory data
ChatRoomHistor.cs -> simulates UI application that display chat history data based on granularity type hour or minute.



