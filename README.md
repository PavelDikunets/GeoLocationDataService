# Сервис для работы с геоданными клиента.
***
## Возможности приложения
* Получать геоданные (широта и долгота) по адресу.
* Получать список ближайших адресов по геоданным.

***

## Технологический стек
* Язык программирования: C#
* Фреймворк: .NET 7.0
* API и документация: OpenApi, Swashbuckle
* Работа с данными: Dadata Api, Nominatim Api, Newtonsoft.Json
* Логирование: Serilog с записью в файл.

***

## Как запустить проект
Для запуска приложения понадобятся следующие инструменты:

* .NET SDK 7.0 или выше
* Git

1. Склонировать репозиторий с помощью команды:

    `git clone https://github.com/PavelDikunets/GeoLocationDataService`


2. Перейти в папку проекта с помощью команды:

    `cd GeoLocationDataService`


3. Выполнить команду `dotnet restore` для установки всех необходимых NuGet пакетов.
4. Запустить проект с помощью команды `dotnet run`.
