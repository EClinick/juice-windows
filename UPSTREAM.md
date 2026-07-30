# Upstream relationship

Juice for Windows is maintained independently from [EClinick/juice](https://github.com/EClinick/juice), the canonical macOS product and behavioral source.
The two applications do not share implementation code or release infrastructure.

## Imported baseline

- Upstream macOS release: `v0.2.9`
- Upstream macOS commit: `cf95dbaacd3c263e1ac1e7adfabd6473651428b4`
- Windows source pull request: [EClinick/juice#17](https://github.com/EClinick/juice/pull/17)
- Imported Windows source commit: `aa2c1ab1011ebf9e3851df5c4dee8d4e1148040d`

The initial repository history was extracted from the `windows/` subtree of that pull request so Andrew Clinick's commits and authorship remain intact.

## Shared contract

The canonical, language-neutral JSON export contract is proposed in [EClinick/juice#19](https://github.com/EClinick/juice/pull/19).
This repository keeps a tested copy under `contracts/` so Windows output and examples can be validated without sharing implementation code.
Contract changes must start in the canonical Juice repository and land here through a linked Windows pull request.

## Ownership

- Product behavior and macOS releases: [@EClinick](https://github.com/EClinick)
- Windows implementation and release maintenance: [@aclinick](https://github.com/aclinick)

Windows releases, Store signing, packaging, installation support, and hardware validation are owned here.
They are not part of the macOS Sparkle, notarization, or Homebrew workflow.

## Porting an upstream release

For each upstream release:

1. Read the release notes and linked pull requests.
2. Classify each change as shared behavior, Windows-equivalent behavior, macOS-only, or deferred.
3. Record the classification in `PARITY.md`.
4. Port shared behavior through focused Windows pull requests.
5. Reference the exact upstream pull request, commit, or tag.
6. Update shared fixtures when observable behavior changes.
7. Release Windows independently after Windows CI and runtime verification pass.

Version numbers are independent.
`PARITY.md` records the newest upstream macOS behavior reviewed by the Windows implementation.
