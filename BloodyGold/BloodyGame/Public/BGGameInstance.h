// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/GameInstance.h"
#include "BGGameInstance.generated.h"

/**
 * 
 */
UCLASS()
class BLOODYGAME_API UBGGameInstance : public UGameInstance
{
	GENERATED_BODY()
public:
	FName GetStartLevelName() const { return StartLevelName; }
protected:
	UPROPERTY(EditDefaultsOnly, Category = "Game")
		FName StartLevelName = NAME_None;
};
