# Kaloyan-Ivanov

## Geometrical Calculator

Geometrical calculator is a simple application for calculating the attributes of various geometrical figures.
It prompts the user to choose a figure type and to enter side lengths and other parameters if needed.
It prints all results on the console. 
Before exiting the program all figure types created during the execution are **stored in a JSON file** together with their respective creational messages.

### OOP principles and patterns used 
- *Interface* implementation that defines the basic functionality of all figures
- *Class inheritance* hierarchy e.g. Paralelogram -> Rectangle -> Square
- *Guard* pattern for validating user's input
- *Simple factory* pattern for creating various types of figures
- *Facade* pattern that hides the implemented functionality for creating classes and communicating with the user through the console 

### Libraries used
- The in-built System.Math library for calculating mathematical operations
- The Newtonsoft.Json third-party library used for storing information about the created figures in a JSON file.

