# Phase 4 logging

## Goal

Add centralized logging to the Aysan services using Serilog and place the shared logging infrastructure in `BuildingBlocks`.

## 1 - Install Serilog

Add the required Serilog packages to the shared logging project.

## 2 - Create Shared Logging Infrastructure

Create a separate Class Library for logging inside `<span>BuildingBlocks</span>`:

`src/BuildingBlocks/Logging/Common.Logging/`

Add the logging registration and configuration extension:

`DependencyInjection.cs`

This allows the same logging setup to be reused by multiple services.

## 3 - Add Common.Logging to Catalog API

Add a project reference from `Catalog.Api`to`Common.Logging`.

Register the logging infrastructure during application startup.

## 4 - Configure Serilog

Configure Serilog settings in:

`src/Services/Catalog/Catalog.Api/appsettings.json`

Environment-specific settings can be added to:

`appsettings.Development.json`

The logging configuration defines settings such as:

* Minimum log level
* Console sink
* File sink
* Log output format
* Logging overrides

## 5 - Run the Application

Start the Catalog API and verify that logs are written correctly.

The Catalog API now uses Serilog for application logging.

The logging registration is implemented as a shared BuildingBlock so it can be reused by other services as they are added.

Detailed Serilog documentation:

`documents/technologies/logging/serilog.md`

## Result

The Catalog API now uses Serilog for application logging.

The logging registration is implemented as a shared BuildingBlock so it can be reused by other services as they are added.

Detailed Serilog documentation:

`documents/technologies/logging/serilog.md`

## Related Files


* [Common.Logging](../../src/BuildingBlocks/Logging/Common.Logging/)
* [Catalog API](../../src/Services/Catalog/Catalog.Api/)
* [appsettings.json](../../src/Services/Catalog/Catalog.Api/appsettings.json)
* [appsettings.Development.json](../../src/Services/Catalog/Catalog.Api/appsettings.Development.json)
