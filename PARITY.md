# Platform parity

Reviewed against Juice for macOS `v0.2.9` at `cf95dbaacd3c263e1ac1e7adfabd6473651428b4`.

Status meanings:

- **Implemented**: present in the imported Windows source and covered by tests or recorded runtime evidence.
- **Different by design**: Windows answers the same product question through different platform data or UI.
- **Not applicable**: the behavior exists only because of a macOS framework or release mechanism.
- **Pending verification**: implemented, but the new repository has not yet produced independent CI or release evidence.

| Product behavior | Windows status | Notes |
|---|---|---|
| Live system power | Different by design | Prefers ACPI Energy Meter rails and falls back to battery discharge rate. |
| Per-app energy ranking | Different by design | Divides measured CPU and GPU rail energy by process activity and reports residual platform overhead. |
| Attribution conservation | Implemented | Apps plus platform overhead reconcile to measured system energy in core tests. |
| Unknown is distinct from zero | Implemented | Unmeasured values are omitted from the JSON contract and shown as unknown in UI. |
| Session, Today, Week, and All ranges | Pending verification | Implemented in the WinUI flyout and core range builders. |
| Honest chart gaps and partial coverage | Implemented | Core chart builders pin requested windows and preserve gaps. |
| Battery charge timeline | Pending verification | Implemented with Windows battery samples. |
| Battery health | Different by design | Uses Windows battery report and WMI cross-checks. |
| Insights | Pending verification | Core engine and WinUI cards are present. |
| Mac mini server mode | Not applicable | Windows hardware rails supply the corresponding desktop measurement path. |
| Privileged powerlog helper | Not applicable | Windows sources used here do not require an elevated helper. |
| Sparkle updates and Homebrew cask | Not applicable | Windows packaging and Microsoft Store distribution are independent. |
| Versioned JSON export | Implemented on Windows | Schema `0.1`; macOS implementation remains an upstream follow-up. |
| Private by default | Pending verification | Region lookup is local and the application has no telemetry path in the imported source. |

## Current release gate

The imported source is not ready for a new public release until all of the following have current evidence:

- Windows CI passes core tests and both architecture builds.
- x64 and ARM64 package builds succeed.
- Install and upgrade preserve local history.
- The tray application launches and remains responsive.
- The `juice` execution alias resolves.
- `juice verify` passes on real Energy Meter hardware.
- A fallback-only machine reports unknown power honestly while on AC.
- Production signing and Store identity are confirmed without committing secrets.
