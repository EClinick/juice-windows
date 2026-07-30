# Contributing to Juice for Windows

Thanks for helping improve Juice for Windows.

This repository is an independent Windows implementation of the behavior defined by [Juice for macOS](https://github.com/EClinick/juice).
Do not copy or merge Swift implementation code into this repository.
Port observable behavior through the C# core and Windows platform layers.

## Before opening a pull request

- Keep the pull request focused on one behavior or fix.
- Link the upstream Juice pull request, commit, issue, or release when implementing parity work.
- Update `PARITY.md` when support status changes.
- Add or update language-neutral fixtures under `contracts/` when behavior or exported JSON changes.
- Never include Store credentials, certificates, API keys, private hardware reports, or user data.

## Build and test

Run checks appropriate to the changed surface:

```powershell
dotnet test tests\Juice.Core.Tests\Juice.Core.Tests.csproj
dotnet build src\Juice.App\Juice.App.csproj -p:Platform=x64
```

On ARM64 hardware, build the native slice while iterating:

```powershell
dotnet build src\Juice.App\Juice.App.csproj -p:Platform=ARM64
```

Before reporting completion, run the full test suite and build both x64 and ARM64.
Changes to power derivation must also pass `juice verify` on real hardware.

## Pull request evidence

- Core logic: focused tests plus the full core suite.
- Hardware source: redacted source inventory and `juice verify` output.
- Tray or settings UI: screenshot and accessibility inspection on Windows.
- Packaging: unpacked bundle inventory plus install, upgrade, CLI alias, and launch proof.

Passing unit tests do not authorize publishing a release or submitting to the Microsoft Store.
