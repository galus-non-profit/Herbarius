# Herbarius

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
