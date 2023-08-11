// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class UseThirdPartyLib : ModuleRules
{
	public UseThirdPartyLib(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "HeadMountedDisplay", "EnhancedInput", "GameFeatures" });

        PrivateDependencyModuleNames.AddRange(
            new string[] {                
                "LoadingScreen",
                "Slate",
                "SlateCore",
                "MoviePlayer",
                "GameplayAbilities",
                "GameplayTags",
                "GameplayTasks",
                "AIModule"
            }
        );

        LoadThirdPartyLib(Target);
    }

    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
    }

    private string CommonLibPath
    {
        get { return Path.GetFullPath(Path.Combine(ThirdPartyPath, "Common/Static")); }
    }

    private string CommonDllPath
    {
        get { return Path.GetFullPath(Path.Combine(ThirdPartyPath, "Common/Share")); }
    }

    public void LoadThirdPartyLib(ReadOnlyTargetRules Target)
    {
        //平台判断
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            //window平台的的情况下
            PublicIncludePaths.Add(CommonLibPath);
            PublicAdditionalLibraries.Add(Path.Combine(CommonLibPath, "CommonLib.lib"));            

            //添加运行时库的Dll            
            string LinuxDll = Path.Combine(CommonDllPath, "CommonDll.dll");
            PublicDelayLoadDLLs.Add("CommonDll.dll");
            RuntimeDependencies.Add(LinuxDll);
        }
        else
        {
            //android平台情况下
            PublicIncludePaths.Add(CommonLibPath);
            PublicAdditionalLibraries.Add(Path.Combine(CommonLibPath, "libCommonLib.a"));
            

            //添加运行时库的Dll
            //string BuildPath = Utils.MakePathRelativeTo(ModuleDirectory, BuildConfiguration.RelativeEnginePath);
            PublicIncludePaths.Add(CommonDllPath);
            AdditionalPropertiesForReceipt.Add("AndroidPlugin", Path.Combine(CommonDllPath, "My_APL_armv8.xml"));
            string LinuxDll = Path.Combine(CommonDllPath, "libCommonDll.so");
            PublicAdditionalLibraries.Add(LinuxDll);

            //PublicDelayLoadDLLs.Add("libCommonDll.so");
            //RuntimeDependencies.Add(LinuxDll);
        }
    }
}
