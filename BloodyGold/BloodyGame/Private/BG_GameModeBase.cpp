// Fill out your copyright notice in the Description page of Project Settings.


#include "BG_GameModeBase.h"
#include "BGGamePlayerController.h"
#include "BGGameCharacter.h"
ABG_GameModeBase::ABG_GameModeBase()
{
	DefaultPawnClass = ABGGameCharacter::StaticClass();
	PlayerControllerClass = ABGGamePlayerController::StaticClass();

}

