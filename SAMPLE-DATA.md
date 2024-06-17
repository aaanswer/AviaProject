%%{init: {'theme': 'base', 'themeVariables': { 'primaryColor': '#000000', 'rowBackgroundColor': '#ffffff', 'rowOddBackgroundColor': '#f8f8f8', 'rowEvenBackgroundColor': '#ffffff'}}}%%
table
    AirlineID   NameAirline         Country
    1           Аэрофлот            Россия
    2           Lufthansa           Германия
    3           Air France          Франция
    4           British Airways     Великобритания
    5           Emirates            ОАЭ

    BookingID   UserID  FlightID    BookingDate SeatNumber  BookingStatus
    1           1       1           2024-06-01  12А         Подтверждено
    2           2       2           2024-06-05  18Б         Отменено
    3           3       3           2024-06-07  5В          Подтверждено
    4           4       4           2024-06-10  9Г          Ожидание
    5           5       5           2024-06-12  7Д          Подтверждено

    UserID      FlightID
    1           1
    2           2
    3           3
    4           4
    5           5

    FlightID    AirlineID   Origin          Destination     DepartureTime   ArrivalTime    FlightStatusName
    1           1           Москва          Санкт-Петербург 2024-06-01      2024-06-01    Вовремя
    2           2           Франкфурт        Токио           2024-06-05      2024-06-06    Задержан
    3           3           Париж           Нью-Йорк        2024-06-07      2024-06-07    Отменен
    4           4           Лондон          Сидней           2024-06-10      2024-06-11    Вовремя
    5           5           Дубай           Сингапур        2024-06-12      2024-06-12    Вовремя

    UserID      Name        Surname         Patronymic      PassportSeries  PassportNumber  Email
    1           Иван        Иванов          Сергеевич       AB              123456          user1@example.com
    2           Мария       Смирнова        Александровна   CD              234567          user2@example.com
    3           Петр        Сидоров         Иванович        EF              345678          user3@example.com
    4           Елена       Кузнецова       Викторовна      GH              456789          user4@example.com
    5           Алексей     Попов           Михайлович      IJ              567890          user5@example.com
