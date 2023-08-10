## Date Consolidation
This project demonstrates a C# implementation of date consolidation. Given a list of unsorted date ranges, the application produces a consolidated list of ranges as output. The consolidation takes place when two consecutive ranges overlap or when one date range is right after the second date range.

## Usage
Clone this repository or download the source code.

Open the solution in your preferred C# development environment (Visual Studio, Visual Studio Code, etc.).

Build and run the project to see the implementation in action.

## How It Works
The consolidation process involves sorting the input date ranges and then iterating through them to merge overlapping or adjacent ranges. The implementation is contained within the Program class, specifically the ConsolidateDateRanges method.

## Running Tests
The project includes unit tests using the NUnit testing framework. To run the tests:

Make sure NUnit is installed in your development environment.

Navigate to the DateConsolidationTests class within the solution.

Run the tests using your testing framework.

Example
Input:
```
01.01.2024 - 10.01.2024
05.01.2024 - 15.01.2024
19.01.2024 - 20.01.2024
02.01.2024 - 05.01.2024
22.01.2024 - 22.01.2024
17.01.2024 - 18.01.2024
```
Output:
```
01.01.2024 - 15.01.2024
17.01.2024 - 20.01.2024
22.01.2024 - 22.01.2024
```
## Contributing
Feel free to contribute to this project by opening issues or submitting pull requests.