// Fill out your copyright notice in the Description page of Project Settings.


#include "BGGamePlayerController.h"
#include "Gameframework/GameModeBase.h"
#include "Blueprint/UserWidget.h"



void  ABGGamePlayerController::SetupInputComponent() {
	Super::SetupInputComponent();
	if (!InputComponent) return;
	InputComponent->BindAction("Pause", IE_Pressed, this, &ThisClass::OnPause);
}

void ABGGamePlayerController::OnPause()
{	
	SetInputMode(FInputModeUIOnly());
	bShowMouseCursor = true;
	auto PauseWidget = CreateWidget<UUserWidget>(GetWorld(), PauseWidgetClass);
		if (PauseWidget) {
			PauseWidget->AddToViewport();
		}

	if (!GetWorld() || !GetWorld()->GetAuthGameMode()) return;
       GetWorld()->GetAuthGameMode()->SetPause(this);
	
}