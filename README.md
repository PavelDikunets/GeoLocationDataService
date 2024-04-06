# GeoLocationDataService - Сервис для работы с геоданными клиента.
***
## Возможности приложения
* Получать геоданные (широта и долгота) по адресу.
* Получать список ближайших адресов по геоданным.

***

## Технологический стек
* Язык программирования: C#
* Фреймворк: .NET Core Web 7.0
* API и документация: Microsoft.AspNetCore.OpenApi, Swashbuckle.AspNetCore
* Работа с данными: Dadata Api, Nominatim Api, Newtonsoft.Json
* Логирование: Serilog с записью в файл.

***

## Как запустить проект
Для запуска приложения вам понадобятся следующие инструменты:

* .NET SDK 7.0 или выше
* Git

1. Клонируйте репозиторий с помощью команды:

    `git clone https://github.com/PavelDikunets/GeoLocationDataService`


2. Перейдите в папку проекта с помощью команды:

    `cd GeoLocationDataService`


3. Выполните команду `dotnet restore` для установки всех необходимых NuGet пакетов.
4. Запустите проект с помощью команды `dotnet run`.