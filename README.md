# ApiClientReference

This is a simple .NET console project that shows how to create a reusable API client using HttpClient and dependency injection.  
The goal of this project is to have a quick reference for making GET requests and handling success and error responses in a clean way.

## Project Purpose
I created this project so that I can reuse the API calling logic in future .NET projects.  
The code includes:
- A generic API client (`IApiClient` and `ApiClient`).
- Strongly typed responses using `ApiResponse<T>`.
- Error handling when API responses fail.
- Added simple logging using `ILogger`.

## How It Works
1. The console app builds a Host (dependency injection container).
2. `ApiClient` is registered as a typed HttpClient.
3. `GetAsync<T>` sends an API request and returns:
   - `IsSuccess = true` when the API call succeeds with valid JSON.
   - `IsSuccess = false` when the API fails or an exception occurs.
4. The main program prints either the data or the error details.

## Folder Structure
- **Interfaces** – Contains `IApiClient`
- **Service** – Contains `ApiClient`
- **Models** – Contains DTOs and ApiResponse models
- **Program.cs** – Main entry point

## How To Run
1. Open the project in Visual Studio 2022.
2. Restore NuGet packages.
3. Run the console app.
4. It will call a sample URL (jsonplaceholder) and print the result.

## How To Reuse This
You can copy the following into any new project:
- IApiClient interface
- ApiClient class
- ApiResponse and ApiError models
- The dependency injection setup

Then call it like:

```csharp
var api = host.Services.GetRequiredService<IApiClient>();
var result = await api.GetAsync<UserDto>("https://example.com");
