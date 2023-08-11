// Fill out your copyright notice in the Description page of Project Settings.


#include "BaseBlueprintFunctionLibrary.h"
#include "../ThirdParty/Common/Static/Sum.h"
#include "../ThirdParty/Common/Share/Sub.h"

void UBaseBlueprintFunctionLibrary::Printf(FString msg)
{
	if (GEngine)
	{
		GEngine->AddOnScreenDebugMessage(-1, 5.0f, FColor::Blue, msg);
	}
}

int UBaseBlueprintFunctionLibrary::sum(int x, int y)
{

#if PLATFORM_WINDOWS
	Sum s;
	return s.sum(x, y);
#else	
	Sum s;
	return s.sum(x+y, 100);
#endif

}

int UBaseBlueprintFunctionLibrary::Sub(int x, int y)
{
#if PLATFORM_WINDOWS
	typedef int(*SubFunc)(int a, int b);
	SubFunc tempFunc;

	FString dllpath = FPaths::ProjectDir() + "ThirdParty/Common/Share/CommonDll.dll";
	UE_LOG(LogTemp, Warning, TEXT("dllpath : %s"), *dllpath);
	void* pDllHandler = FPlatformProcess::GetDllHandle(*dllpath);

	if (pDllHandler)
	{
		FString funcName = "sub";
		tempFunc = (SubFunc)FPlatformProcess::GetDllExport(pDllHandler, *funcName);
		check(tempFunc);
		return tempFunc(x,y);
	}
	else
	{
		UE_LOG(LogTemp, Warning, TEXT("pDllHandler null"));
	}
	return 100;
#else	
	return sub(10, 5);
#endif
}
