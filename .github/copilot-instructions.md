# ClickUpMcpServer

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

ClickUpMcpServer is a .NET 9.0 C# Model Context Protocol (MCP) server that provides integration with the ClickUp API. It enables AI assistants to interact with ClickUp spaces, folders, and other project management features through the MCP standard.

## Working Effectively

### Prerequisites and Setup
- Install .NET 9.0 SDK:
  - `curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 9.0` -- takes 2-3 minutes. NEVER CANCEL.
  - `export PATH="$HOME/.dotnet:$PATH"` (add to your shell profile for persistence)
- Verify installation: `dotnet --version` should show 9.0.x

### Build and Development Commands
- Navigate to project directory: `cd /path/to/ClickUpMcpServer/src/ClickUpMcpServer.Mcp`
- Clean: `dotnet clean` -- takes 1 second
- Restore packages: `dotnet restore` -- takes 55-60 seconds first time, <1 second subsequent runs. NEVER CANCEL.
- Build (Debug): `dotnet build` -- takes 5-6 seconds. Expect 64 nullable reference warnings (non-breaking).
- Build (Release): `dotnet build -c Release` -- takes 2 seconds
- Format code: `dotnet format` -- takes 6-7 seconds. NEVER CANCEL. Always run before committing.
- Verify formatting: `dotnet format --verify-no-changes` -- takes 7 seconds

### Running the Application
- Development mode: `dotnet run`
- Run built executable: `./bin/Release/net9.0/linux-x64/ClickUpMcpServer`
- Run published single-file: `./bin/Release/net9.0/linux-x64/publish/ClickUpMcpServer`

The application runs as an MCP server using stdio transport and will display startup messages then wait for MCP protocol messages.

### Packaging and Publishing
- Publish self-contained: `dotnet publish -c Release` -- takes 1 second, creates 73MB single-file executable
- Create NuGet package: `dotnet pack -c Release` -- may have build errors, test first with `dotnet build -c Release`

### Solution-Level Operations
- Navigate to repo root: `cd /path/to/ClickUpMcpServer`
- Build entire solution: `dotnet build ClickUpMcpServer.sln` -- takes 1.5 seconds. Use the .sln file explicitly to avoid conflicts with .slnx.
- The solution has been fixed to remove the missing AppHost project reference.

## Validation

### Always Run Before Committing
- `dotnet format` -- to fix formatting issues
- `dotnet build -c Release` -- to verify clean build with only expected warnings
- Manual test with: `timeout 10s dotnet run` or use the functional test below

### Functional Testing
There are no unit tests in this project. To verify functionality:

1. Build the application: `dotnet build -c Release`
2. Test basic MCP functionality using this Python script:

```python
import json, subprocess, time
executable = "bin/Release/net9.0/linux-x64/publish/ClickUpMcpServer"
proc = subprocess.Popen([executable], stdin=subprocess.PIPE, stdout=subprocess.PIPE, text=True)
time.sleep(1)
init_msg = {"jsonrpc": "2.0", "id": 1, "method": "initialize", "params": {"protocolVersion": "2024-11-05", "capabilities": {}, "clientInfo": {"name": "test", "version": "1.0"}}}
proc.stdin.write(json.dumps(init_msg) + '\n')
proc.stdin.flush()
time.sleep(2)
print("✅ Success" if proc.poll() is None else "❌ Failed")
proc.terminate()
```

3. The application should start, accept the MCP initialization message, and continue running until terminated.

### Environment Requirements for Full Functionality
The MCP server requires these environment variables for ClickUp API access:
- `TEAM_ID` - Your ClickUp team/workspace ID
- `PERSONAL_API_KEY` - Your ClickUp personal API token

Without these, the server starts but API calls will fail.

## Codebase Structure

### Key Files and Directories
- `src/ClickUpMcpServer.Mcp/` - Main project directory
- `Program.cs` - Application entry point, MCP server setup
- `Tools/ClickUpTools.cs` - MCP tool implementations (`ListClickUpSpacesAsync`, `ListClickUpFoldersAsync`)
- `IClickUpClient.cs` - HTTP client interface using Refit
- `Models/GetSpaces.cs` - ClickUp spaces API response models
- `Models/GetFolders.cs` - ClickUp folders API response models
- `.mcp/server.json` - MCP server configuration and metadata

### Project Configuration
- Target Framework: .NET 9.0
- Package Type: McpServer (NuGet tool package)
- Runtime: Self-contained, single-file executable
- Output: Linux-x64 by default (configurable via RuntimeIdentifiers)

## Common Issues and Solutions

### Build Issues
- **"NETSDK1045: .NET SDK does not support targeting .NET 9.0"**: Install .NET 9.0 SDK using the curl command above
- **Missing AppHost project errors**: This has been fixed - use `dotnet build ClickUpMcpServer.sln`
- **64 nullable reference warnings**: These are expected and non-breaking. The build succeeds with warnings.

### Runtime Issues
- **"Authorization header missing"**: Set `PERSONAL_API_KEY` environment variable
- **API calls failing**: Verify `TEAM_ID` and `PERSONAL_API_KEY` are correct
- **MCP server not responding**: Use the Python test script above to verify basic functionality

### Performance Notes
- First restore takes 55-60 seconds, subsequent ones <1 second
- Builds are fast (1-6 seconds)
- Formatting takes 6-7 seconds
- Published executable is large (73MB) but fully self-contained

Always run `dotnet format` before committing to maintain code style consistency.