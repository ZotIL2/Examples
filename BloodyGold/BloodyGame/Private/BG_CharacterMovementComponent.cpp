// Fill out your copyright notice in the Description page of Project Settings.


#include "BG_CharacterMovementComponent.h"
#include "BGGameCharacter.h"
float UBG_CharacterMovementComponent::GetMaxSpeed() const{
	const float MaxSpeed = Super::GetMaxSpeed();
	const ABGGameCharacter* player = Cast<ABGGameCharacter>(GetPawnOwner());
	return player && player->isRunning() ? MaxSpeed * RunModifier:MaxSpeed;
}