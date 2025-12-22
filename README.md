# Herbarius Day 1

```powershell
dotnet new gitignore
```

```powershell
git init
```

```powershell
dotnet new sln --format slnx --name Herbarius
```

```powershell
dotnet new classlib --framework net10.0 --output src/Domain --name Herbarius.Domain
dotnet sln add src/Domain
```

```powershell
dotnet new mstest --framework net10.0 --output tests/Domain.UnitTests --name Herbarius.Domain.UnitTests
dotnet sln add tests/Domain.UnitTests
dotnet add tests/Domain.UnitTests reference src/Domain
dotnet add tests/Domain.UnitTests package Shouldly
```

# =============================================================
# Day 2
```powershell
ssh-keygen.exe -t ecdsa -C miroslaw.hetman@gmail.com
dane pobrać z github
```

```powershell
cd c:\Workspaces\DotNet10
git clone git@github.com:galus-non-profit/Herbarius.git
cd Herbarius
code .
```

```powershell 
dotnet add .\src\Application\ package MediatR
dotnet build
dotnet test
git add .
git commit -m "add application unit test"
git push
```

# =============================================================
# Day 3
```powershell
dotnet new classlib --framework net10.0 --output src/Infrastructure --name Herbarius.Infrastructure
dotnet sln add src/Infrastructure
dotnet add src/Infrastructure reference src/Application
```

```powershell
dotnet new mstest --framework net10.0 --output tests/Application.FunctionalTests --name Herbarius.Application.FunctionalTests
dotnet sln add tests/Application.FunctionalTests
dotnet add tests/Application.FunctionalTests reference src/Infrastructure
dotnet add tests/Application.FunctionalTests package Shouldly
```

git add .
git commit -m "add application functional test"
git push

