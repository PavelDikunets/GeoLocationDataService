# Сервис для работы с геоданными клиента.
***
## Возможности приложения
* Получать геоданные (широта и долгота) по адресу.
* Получать список ближайших адресов по геоданным.

***

## Технологический стек
* Язык программирования: C#
* Фреймворк: ASP.NET Core
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


3. Выполнить команду:

   `dotnet restore`

4. Запустить проект с помощью команды:

   `dotnet run --project ./src/GeoLocation/Host/GeoLocation.Host.Api/GeoLocation.Host.Api.csproj`.

5. Открыть в браузере ссылку: http://localhost:5144/swagger/
