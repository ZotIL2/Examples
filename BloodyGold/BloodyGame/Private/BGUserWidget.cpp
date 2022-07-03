// Fill out your copyright notice in the Description page of Project Settings.


#include "BGUserWidget.h"
#include "Components/Button.h"
#include "Kismet/GameplayStatics.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Blueprint/UserWidget.h"
#include "BGGameInstance.h"


void UBGUserWidget::NativeOnInitialized()
{
	Super::NativeOnInitialized();
	if (StartGameButton) {
		StartGameButton->OnClicked.AddDynamic(this, &UBGUserWidget::OnStartGame);
	}
	if (ExitB) {
		ExitB->OnClicked.AddDynamic(this, &UBGUserWidget::QuitGame);
	}
	
}

void UBGUserWidget::OnStartGame()
{
 if (!GetWorld()) return;
	const auto BGGameInstance = GetWorld()->GetGameInstance<UBGGameInstance>();
	if (!BGGameInstance) return;
	if (BGGameInstance->GetStartLevelName().IsNone()) {
		return;
	}
	UGameplayStatics::OpenLevel(this, BGGameInstance->GetStartLevelName());
}

void UBGUserWidget::QuitGame() {
	UKismetSystemLibrary::QuitGame(this, nullptr, EQuitPreference::Quit, true);
}




