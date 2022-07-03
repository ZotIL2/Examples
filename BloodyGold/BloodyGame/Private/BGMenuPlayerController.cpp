// Fill out your copyright notice in the Description page of Project Settings.


#include "BGMenuPlayerController.h"

void ABGMenuPlayerController::BeginPlay() {
	Super::BeginPlay();
	SetInputMode(FInputModeUIOnly());
	bShowMouseCursor = true;
}

