// Fill out your copyright notice in the Description page of Project Settings.


#include "BGMenuGameModeBase.h"
#include "BGMenuHUD.h"
#include "BGMenuPlayerController.h"


ABGMenuGameModeBase::ABGMenuGameModeBase() {
		
	//PlayerControllerClass = ABGMenuPlayerController::StaticClass();
	HUDClass = ABGMenuHUD::StaticClass();
}
