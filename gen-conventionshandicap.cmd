if exist ".\CodeGen\ConventionsHandicap\_Generated\"  rd /s /q "./CodeGen/ConventionsHandicap/_Generated"
timeout /t 3
CodegenUP -s ./CodeGen/Specs/conventionshandicap.yaml -o ./CodeGen/ConventionsHandicap -t ./CodeGen/Templates
