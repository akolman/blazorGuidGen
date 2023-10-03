# BlazorGuidGenerator
### A browser-based GUID generator running on Blazor Wasm.
[![pipeline status](https://gitlab.com/Akolman/blazorGUIDgen/badges/master/pipeline.svg)](https://gitlab.com/Akolman/blazorGUIDgen/-/commits/master)

## Why?
Sometimes I need a batch of GUIDs and JavaScript doesn't really have great support for GUIDs.  The easiest thing to do was to make a Blazor wasm app.  Besides the slightly slow load times, there's no server-side actions so the generation is quick.  And you can generate a million at one time and it won't hurt the server one bit.

## Features
It's really nothing special, but it is at least easy to use and quick

- Uses compiled blazor wasm app so it's web-server agnostic and has no dependencies
- GUIDs are generated in browser so no server-side lookup/ajax calls
- Allows you to pick number of GUIDs to generate
- Button that copies GUID directly to clipboard
- Now features Hex converter!!!
- Converts "U+" style Unicode codepoints to their emoji

## Updates
### 1.5.1
- Updated to net 8.0.
- Enabled AOT.

### 1.4.1
- Added sequence generator.

### 1.3.1
- Updated to final release of net6
- GUID Copy button now flips to 'Copied'

## Building
Target the latest .net6 preview and run:
`dotnet build`

### Notes
When installing, there is some additional configuration required.  Packaging should produce a web.config file for use with IIS, however, if using a different web-server such as apache or Nginx, additional configuration will be needed.  See [MSDN](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly?view=aspnetcore-6.0) for more info.


