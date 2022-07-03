// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "BGUserWidget.generated.h"
class UButton;

/**
 * 
 */
UCLASS()
class BLOODYGAME_API UBGUserWidget : public UUserWidget
{
	GENERATED_BODY()

protected:
	UPROPERTY(meta = (BindWidget))
		UButton* StartGameButton;
	UPROPERTY(meta = (BindWidget))
		UButton* SettingsB;
	UPROPERTY(meta = (BindWidget))
		UButton* ExitB;
	

	virtual void NativeOnInitialized() override;
private:
	UFUNCTION()
		void OnStartGame();
	UFUNCTION()
		void QuitGame();

};
