// Fill out your copyright notice in the Description page of Project Settings.


#include "BGGameCharacter.h"
#include "Camera/CameraComponent.h"
#include "Components/InputComponent.h"
#include "GameFramework/SpringArmComponent.h"
#include "BG_CharacterMovementComponent.h"

// Sets default values
ABGGameCharacter::ABGGameCharacter(const FObjectInitializer& ObjInit)
	:Super(ObjInit.SetDefaultSubobjectClass<UBG_CharacterMovementComponent>(ACharacter::CharacterMovementComponentName))
{

	SpringArmComponent = CreateDefaultSubobject<USpringArmComponent>("SpringArmComponent");
	SpringArmComponent->TargetArmLength = 300.0f;
	SpringArmComponent->SetupAttachment(RootComponent);
	
	//SpringArmComponent->bUsePawnControlRotation = false;
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	CameraComponent = CreateDefaultSubobject<UCameraComponent>("CameraComponent");
	CameraComponent->SetupAttachment(SpringArmComponent);
}

// Called when the game starts or when spawned
void ABGGameCharacter::BeginPlay()
{
	Super::BeginPlay();
}



// Called every frame
void ABGGameCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	if (WantsRun == true && stamina > 0  && isMovingForward == true) {
		stamina = stamina - 0.5;
	}
	if(WantsRun == false && stamina <= 100.0f || WantsRun == true && isMovingForward == false)
	{
		stamina = stamina + 0.5;
	}
}


// Called to bind functionality to input
void ABGGameCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	PlayerInputComponent->BindAxis("MoveForward", this, &ABGGameCharacter::MoveForward);
	PlayerInputComponent->BindAxis("MoveRight", this, &ABGGameCharacter::MoveRight);
	PlayerInputComponent->BindAxis("LookUp", this, &ABGGameCharacter::AddControllerPitchInput);
	PlayerInputComponent->BindAxis("TurnAround", this, &ABGGameCharacter::AddControllerYawInput);
	PlayerInputComponent->BindAction("Jump",IE_Pressed,this, &ABGGameCharacter::Jump);
	PlayerInputComponent->BindAction("Run", IE_Pressed, this, &ABGGameCharacter::StarRun);
	PlayerInputComponent->BindAction("Run", IE_Released, this, &ABGGameCharacter::StopRun);


}
void ABGGameCharacter::MoveForward(float Amount)
{
	isMovingForward = Amount > 0.0f;
	if (Amount == 0.0f) return;
	AddMovementInput(GetActorForwardVector(), Amount);
}

void ABGGameCharacter::MoveRight(float Amount)
{
	if (Amount == 0.0f) return;
	AddMovementInput(GetActorRightVector(), Amount);
}
void ABGGameCharacter::StopRun()
{
	WantsRun = false;
}
void ABGGameCharacter::StarRun()
{
	WantsRun = true;

}
bool  ABGGameCharacter::isRunning() const {
	return WantsRun && isMovingForward && !GetVelocity().IsZero() && stamina>1;
}
FRotator ABGGameCharacter::GetPlayerRotationYaw() const {
	FRotator PlayerRotationYaw = FRotator::ZeroRotator;
	PlayerRotationYaw.Yaw = GetControlRotation().Yaw;
	return PlayerRotationYaw;
}


