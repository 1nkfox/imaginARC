# imaginARC Revit Copilot

This repository provides a sample Autodesk Revit plugin that uses the Model Context Protocol (MCP) to communicate with an external AI service.

## Quick Start

1. Clone the repository.
2. Run `dotnet restore` to install dependencies.
3. Build the project:

```bash
dotnet build
```

### Example MCP Command

The copilot understands MCP commands such as `CreateWall`. Use the following prompt to create a simple wall:

```
CreateWall 0 0 10 0 10
```

This will create a wall from `(0,0,0)` to `(10,0,10)`.

## License

This project is licensed under the MIT License.
