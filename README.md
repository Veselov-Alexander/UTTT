# UTTT

Для просмотра полного функционала необходим сервер.

Чтобы его запустить необходимо:

- иметь установленную БД MySQL
- выполнить скрипт для создания БД
- заполнить БД начальными данными с помощью другого скрипта (обязательно, без этого работать не будет)
- выставить свой логин и пароль от БД в проекте сервера в классе Database.cs
(private static string connectionString = "server=localhost;user id=root;password=1234567;database=uttt;SslMode=none";) - здесь root - это логин, 1234657 - пароль
- при необходимости выставить нужный порт, если указанный в программе занят
- перекомпилировать и запустить сервер

Возможности приложения:

Создание клиент-сервеной архитектуры
Учет достижений
Реализация игровых комнат
Учет информации в БД (пользователей, статистики)
Создания ранговой системы
Возможности играть на время
Просмотр сыгранных матчей
Анализ сыгранных матчей
Три бота с различными уровнями сложности
Создания таблицы со статистикой игроков
Чат в игровом лобби
Возможность других людей просматривать чужие игры

В оффлайн режиме доступна только игра с ботами
