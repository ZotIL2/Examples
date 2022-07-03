// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "BGPauseUserWidget.generated.h"

class UButton;
/**
 * 
 */
UCLASS()
class BLOODYGAME_API UBGPauseUserWidget : public UUserWidget
{
	GENERATED_BODY()

protected:
	UPROPERTY(meta = (BindWidget))
		UButton* ResumeButton;
	UPROPERTY(meta = (BindWidget))
		UButton* SettingsG;
	UPROPERTY(meta = (BindWidget))
		UButton* ExitG;
	UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "UI")
		TSubclassOf<UUserWidget> PauseWidgetClassM;


	virtual void NativeOnInitialized() override;
private:
	UFUNCTION()
		void OnResumeGame();
	UFUNCTION()
		void QuitGame();
};
