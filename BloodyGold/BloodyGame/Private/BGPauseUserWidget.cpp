// Fill out your copyright notice in the Description page of Project Settings.


#include "BGPauseUserWidget.h"
#include "Components/Button.h"
#include "Kismet/GameplayStatics.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Blueprint/UserWidget.h"
#include "BGGameInstance.h"

void UBGPauseUserWidget::NativeOnInitialized()
{
	Super::NativeOnInitialized();
	if (ResumeButton) {
		ResumeButton->OnClicked.AddDynamic(this, &UBGPauseUserWidget::OnResumeGame);
	}
	if (ExitG) {
		ExitG->OnClicked.AddDynamic(this, &UBGPauseUserWidget::QuitGame);
	}
}

void UBGPauseUserWidget::OnResumeGame()
{
	UGameplayStatics::SetGamePaused(GetWorld(), false);
}

void UBGPauseUserWidget::QuitGame()
{
	auto PauseWidget = CreateWidget<UUserWidget>(GetWorld(), PauseWidgetClassM);
	if (PauseWidget) {
		PauseWidget->AddToViewport();
	}
}
