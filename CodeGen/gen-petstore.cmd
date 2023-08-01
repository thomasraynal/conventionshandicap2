if exist "..\PetStore\PetStore\_Generated\"  rd /s /q "../PetStore/PetStore/_Generated"
timeout /t 3
dotnet-codegen ./Specs/petstore.yaml ../PetStore/PetStore ./Templates
