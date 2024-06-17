## Чек-лист для создания и настройки базы данных

- [ ] Подготовить скрипты для создания таблиц
  - [ ] Airlines
  - [ ] Bookings
  - [ ] BookingStatuses
  - [ ] FavoriteFlights
  - [ ] Flights
  - [ ] FlightStatuses
  - [ ] UserLogins
  - [ ] Users
- [ ] Добавить автоинкремент для идентификаторов
  - [ ] AirlineID
  - [ ] BookingID
  - [ ] FlightID
  - [ ] UserID
- [ ] Настроить связи между таблицами (Foreign Keys)
  - [ ] Bookings -> BookingStatuses
  - [ ] Bookings -> Flights
  - [ ] Bookings -> Users
  - [ ] FavoriteFlights -> Flights
  - [ ] FavoriteFlights -> Users
  - [ ] Flights -> Airlines
  - [ ] Flights -> FlightStatuses
  - [ ] Users -> UserLogins
- [ ] Проверить и протестировать корректность создания таблиц и связей
- [ ] Заполнить таблицы тестовыми данными
  - [ ] Airlines
  - [ ] BookingStatuses
  - [ ] Flights
  - [ ] FlightStatuses
  - [ ] UserLogins
  - [ ] Users
- [ ] Документировать структуру базы данных
  - [ ] Описание таблиц
  - [ ] Описание связей
  - [ ] Примеры данных

## Чек-лист для разработки функционала
- [ ] Разработать функционал для работы с пользователями
  - [ ] Регистрация пользователя
  - [ ] Авторизация пользователя
  - [ ] Просмотр профиля пользователя
  - [ ] Редактирование профиля пользователя
- [ ] Разработать функционал для бронирования рейсов
  - [ ] Поиск рейсов
  - [ ] Просмотр информации о рейсе
  - [ ] Бронирование рейса
  - [ ] Отмена бронирования
- [ ] Разработать функционал для управления любимыми рейсами
  - [ ] Добавление рейса в избранное
  - [ ] Удаление рейса из избранного
  - [ ] Просмотр списка избранных рейсов
- [ ] Реализовать административный функционал
  - [ ] Управление авиакомпаниями
  - [ ] Управление рейсами
  - [ ] Управление статусами рейсов и бронирований

## Чек-лист для тестирования
- [ ] Разработать тестовые сценарии для пользователей
  - [ ] Регистрация
  - [ ] Авторизация
  - [ ] Просмотр и редактирование профиля
- [ ] Разработать тестовые сценарии для бронирования
  - [ ] Поиск рейсов
  - [ ] Бронирование
  - [ ] Отмена бронирования
- [ ] Разработать тестовые сценарии для избранных рейсов
  - [ ] Добавление в избранное
  - [ ] Удаление из избранного
  - [ ] Просмотр избранных рейсов
- [ ] Провести тестирование всех сценариев
- [ ] Задокументировать результаты тестирования

## Чек-лист для документации
- [ ] Подготовить README файл
  - [ ] Описание проекта
  - [ ] Установка и настройка
  - [ ] Использование
- [ ] Описание структуры базы данных
  - [ ] Таблицы и связи
  - [ ] Примеры данных
- [ ] Подготовить документацию для API
  - [ ] Описание всех конечных точек (endpoints)
  - [ ] Примеры запросов и ответов
- [ ] Подготовить руководство пользователя
  - [ ] Для пользователей
  - [ ] Для администраторов