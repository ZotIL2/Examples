// Fill out your copyright notice in the Description page of Project Settings.


#include "BGSettingsWidget.h"
#include "Components/Button.h"
#include "Kismet/GameplayStatics.h"

void UBGSettingsWidget::NativeOnInitialized()
{
	Super::NativeOnInitialized();
	if (SettingsCloseB) {
		SettingsCloseB->OnClicked.AddDynamic(this, &UBGSettingsWidget::SettingsClose);
	}
}

void UBGSettingsWidget::SettingsClose()
{
	
}
