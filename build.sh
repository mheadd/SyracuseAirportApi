#!/usr/bin/env bash
dotnet restore AirportApi/SyracuseAirportApi.csproj
dotnet build AirportApi/SyracuseAirportApi.csproj
dotnet restore AirportApi.Tests/Tests.csproj
dotnet build AirportApi.Tests/Tests.csproj
dotnet test AirportApi.Tests/Tests.csproj
