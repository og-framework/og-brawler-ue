// SPDX-License-Identifier: BUSL-1.1
using System.IO;
using UnrealBuildTool;

public class OGBrawler : ModuleRules
{
	public OGBrawler(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "OGSimulation" });

		// og-brawler sits directly under this module directory (no extern/ or Source/ wrapper).
		string PureLib = Path.Combine(ModuleDirectory, "og-brawler");
		PublicIncludePaths.Add(PureLib);
	}
}
