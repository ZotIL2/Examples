// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/PlayerController.h"
#include "BGGamePlayerController.generated.h"

/**
 * 
 */
UCLASS()
class BLOODYGAME_API ABGGamePlayerController : public APlayerController
{
	GENERATED_BODY()
protected:
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "UI")
		TSubclassOf<UUserWidget> PauseWidgetClass;
		virtual void SetupInputComponent();

private:
	void OnPause();
};
