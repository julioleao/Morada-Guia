# Morada Guia

Um Web App desenvolvido em C# e com o apoio do framework Angular e ASP.NET com o intuito de facilitar a locação de casas, quitinetes, apartamentos, repúblicas e pensionatos a estudantes, tanto calouros quanto veteranos.

Esse projeto faz parte da discipplica Oficina de Integração 2 do curso de Engenharia de Software 6º período. Grupo composto por Alexandre, Carlos, Julio (eu) e Samuel. Está sendo elaborado e baseado sobre as aulas lecionadas por [Neil Cummings](https://github.com/TryCatchLearn)

# Instruções para executar o código

**OBS.** É necessário ter o [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2) e [Angular CLI](https://cli.angular.io/) instalados.

**1.** Clonar o repositório para um diretório de sua preferência.

**2.** Pelo Visual Studio Code, abra a pasta do projeto e execute o "build" para corrigir as denpedencias.

> Terminal - Run Build Task - Build

  **ou** 

> Ctrl + SHIFT + B


**3.** Abra o terminal navegue até a pasta *MoradaGuia.API* e execute:
```
dotnet ef database update
dotnet watch run
```

**4.** Vá até a pasta *MoradaGuia-SPA* e execute:
```
ng serve
```

**5.** Caso ocorra algum erro de compilação, desinstale o angular e instale a versão mais recente como desenvolvedor, e em seguida execute o passo 4 novamente:
```
npm uninstall angular-cli
npm install @angular/cli --save-dev
```

**6.** Utilize o link (http://localhost:4200/) para ter acesso ao *Front-end* junto ao *Back-end*.
