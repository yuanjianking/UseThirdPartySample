// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "UseThirdPartyLib.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "BaseBlueprintFunctionLibrary.generated.h"

/**
 * 
 */
UCLASS()
class USETHIRDPARTYLIB_API UBaseBlueprintFunctionLibrary : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()
	
public:
	UFUNCTION(BlueprintCallable, Category = "lib")
	static void Printf(FString msg);

	UFUNCTION(BlueprintCallable, Category = "lib")
	static int sum(int x, int y);

	UFUNCTION(BlueprintCallable, Category = "lib")
	static int Sub(int x, int y);

};
