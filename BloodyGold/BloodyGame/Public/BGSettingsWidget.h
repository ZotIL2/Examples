// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "BGSettingsWidget.generated.h"
class UButton;
/**
 * 
 */
UCLASS()
class BLOODYGAME_API UBGSettingsWidget : public UUserWidget
{
	GENERATED_BODY()
protected:
	UPROPERTY(meta = (BindWidget))
		UButton* SettingsCloseB;
	virtual void NativeOnInitialized() override;
private:
	UFUNCTION()
		void SettingsClose();
};
