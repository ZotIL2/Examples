// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "BGGameCharacter.generated.h"
class UCameraComponent;
class USpringArmComponent;
UCLASS()
class BLOODYGAME_API ABGGameCharacter : public ACharacter
{
	GENERATED_BODY()
public:
	ABGGameCharacter(const FObjectInitializer& ObjInit);

protected:
	UPROPERTY(VisibleAnywhere, BlueprintReadWrite, Category = "Components")
		USpringArmComponent* SpringArmComponent; 
	UPROPERTY(VisibleAnywhere, BlueprintReadWrite, Category = "Components")
	UCameraComponent* CameraComponent;
	virtual void BeginPlay() override;
private:
	bool WantsRun = false;
	bool isMovingForward = false;
	bool Pause = false;
	bool BackForward = false;
	
	void MoveForward(float Amount);
	void MoveRight(float Amount);
	void StarRun();
	void StopRun();
	FRotator GetPlayerRotationYaw() const;
public:	
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Meta = (Bitmask))
		float stamina = 100.0f;
	virtual void Tick(float DeltaTime) override;
	UFUNCTION(BlueprintCallable, Category = "Movement")
		bool isRunning() const;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
};
