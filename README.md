# dotnet-fcdata



## Getting started
```cmd
git clone https://github.com/SSI-Securities-Corporation/dotnet-fcdata
cd dotnet-fcdata
dotnet restore
dotnet build
```
# Sample usage
## Config
Get `consumerID` and `consumerSecret` from [iBoard](https://iboard.ssi.com.vn/support/api-service/management)
Edit in file `data.json`
```json
  "ConsumerId": "<consumerID>",
  "ConsumerSecret": "<consumerSecret>",
```
## Run
```cmd
cd dotnet-fcdata
dotnet restore
dotnet build
dotnet run --project SSI.FCData.ClientExample/SSI.FCData.ClientExample.csproj
```