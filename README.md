<!-- SPDX-License-Identifier: BUSL-1.1 -->
# og-brawler-ue

UE plugin shell wrapping [og-brawler](https://github.com/og-framework/og-brawler).

This repo contains only the Unreal Engine integration layer (`.uplugin`, `Build.cs`). The pure C++ brawler source lives in `extern/og-brawler/` via submodule. No source is duplicated — UBT compiles it from the extern path via `ConditionalAddModuleDirectory`. Requires [og-simulation-ue](https://github.com/og-framework/og-simulation-ue) as a sibling plugin (declared via `.uplugin` `Plugins:` dependency).

## Position in the og-framework graph

```
og-simulation-ue  (sibling plugin — provides OGSimulation UE module)
og-brawler  (pure source submoduled at extern/og-brawler/)
    ↓ wrapped by
og-brawler-ue  (this repo — UE plugin shell)
    ↓ consumed as Plugins/OGBrawler/ by
og-brawler-unreal
```

## Related repos

| Repo | Role |
|---|---|
| [og-brawler](https://github.com/og-framework/og-brawler) | Pure C++ source submoduled here |
| [og-simulation-ue](https://github.com/og-framework/og-simulation-ue) | Required sibling plugin (OGSimulation module) |
| [og-brawler-unreal](https://github.com/og-framework/og-brawler-unreal) | UE project that consumes this plugin |

## Quickstart

This plugin is consumed by [og-brawler-unreal](https://github.com/og-framework/og-brawler-unreal) as a submodule at `Plugins/OGBrawler/`. For the full project setup see that repo.

To use this plugin in your own UE project, ensure `Plugins/OGSimulation/` already points at og-simulation-ue, then:

```bash
git submodule add https://github.com/og-framework/og-brawler-ue.git Plugins/OGBrawler
git submodule update --init --recursive Plugins/OGBrawler
```

Open your `.uproject` — UBT resolves the `OGSimulation` plugin dependency via the `.uplugin` declaration and compiles both plugins.

## Layout

```
OGBrawler.uplugin          Plugin descriptor; declares OGSimulation plugin dependency
Source/OGBrawler/          UE module stub + Build.cs
extern/og-brawler/         Submodule — pure brawler source
```

## Canonical workflow

See [`og-brawler-unreal/docs/cross-repo-dev-loop.md`](https://github.com/og-framework/og-brawler-unreal/blob/main/docs/cross-repo-dev-loop.md) for the multi-repo development workflow.

## License

**[Business Source License 1.1](LICENSE)** — converts to **[MPL-2.0](LICENSES/MPL-2.0.txt)** on the Change Date printed in `LICENSE` (currently `2030-06-01`).

**What this means in practice:**

| Use case | Allowed? |
|---|---|
| Non-commercial use (personal, educational, research, hobby, open-source) | ✅ Yes |
| Commercial use in any product that is *not* a multiplayer brawler | ✅ Yes |
| Use in a software product or service whose primary gameplay is multiplayer character-vs-character melee combat (a "Competing Product") | ⛔ Please contact the maintainer to discuss |
| Modify and contribute back via PR | ✅ Yes (via [CLA](https://github.com/og-framework/og-tools/blob/main/Public/license-templates/CLA-process.md)) |

After the Change Date, the codebase converts automatically to MPL-2.0 and these restrictions lift.

**Unsure if your use is permitted? Have an interesting idea?**
Reach out to [grahnen92@gmail.com](mailto:grahnen92@gmail.com) — the Licensor welcomes such conversations and is open to case-by-case exceptions.

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for the contribution decision tree and CLA signing flow.
