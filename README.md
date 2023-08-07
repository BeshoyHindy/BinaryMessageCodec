# BinaryMessageCodec

This project provides a simple, custom binary encoding and decoding scheme for messages to be used in a real-time communication application. The project was built in C# and includes console testing and xUnit testing applications to ensure functionality.

## Project Structure

This solution is divided into three projects:

- **BinaryMessageCodec.Library**: This is the core library, which provides the encoding and decoding functionality.
- **BinaryMessageCodec.App**: This is a console application for testing and demonstrating the usage of the library.
- **BinaryMessageCodec.Tests**: This is an xUnit project for unit testing the library.

## Class Library

The BinaryMessageCodec.Library project includes the following important components:

- **IMessageCodec**: Interface defining the methods for a message codec.
- **MessageCodec**: Class implementing the `IMessageCodec` interface and providing the encoding and decoding functionality.
- **Message**: A simple message model used for the encoding and decoding operations.
- **BinaryMessageCodec**: A helper class for handling ASCII strings.

## Console App

The BinaryMessageCodec.App is a console application that demonstrates how to use the MessageCodec for encoding and decoding messages. It encodes a message, decodes it, and validates that the decoded message matches the original one.

## Unit Tests

The BinaryMessageCodec.Tests project uses xUnit to perform unit testing on the `MessageCodec` class. This helps ensure the library is working as expected. The project contains a variety of tests for different scenarios.

## Building and Running the Project

You will need Visual Studio or another suitable IDE that supports .NET Core development. 

Once you have cloned or downloaded the repository, you can open the solution file `BinaryMessageCodec.sln` in Visual Studio. You can build the solution by selecting `Build -> Build Solution` from the menu.

To run the console application, right-click on the `BinaryMessageCodec.App` project in Solution Explorer, select `Set as StartUp Project`, and then press `F5` or select `Debug -> Start Debugging` from the menu.

To run the unit tests, open the Test Explorer (`Test -> Windows -> Test Explorer`) and click `Run All`.


