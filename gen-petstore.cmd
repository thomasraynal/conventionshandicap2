if exist ".\CodeGen\PetStore\_Generated\"  rd /s /q "./CodeGen/PetStore/_Generated"
timeout /t 3
CodegenUP -s ./CodeGen/Specs/petstore.yaml -o ./CodeGen/PetStore -t ./CodeGen/Templates
