## Логическая модель БД

```mermaid
erDiagram
    USER {
        int userID PK
        string name
        string surname
        string patronymic
        string passportSeries
        string passportNumber
        string email FK
    }

    USERLOGIN {
        string email PK
        string hashedPassword
    }

    AIRLINE {
        int airlineID PK
        string name
        string country
    }

    FLIGHT {
        int flightID PK
        int airlineID FK
        string origin
        string destination
        datetime departureTime
        datetime arrivalTime
        string flightStatusName
    }

    FLIGHT_STATUSE {
        string flightStatusName PK
        string flightStatusDescription
    }

    BOOKING {
        int bookingID PK
        int userID FK
        int flightID FK
        datetime bookingDate
        string seatNumber
        string bookingStatus
    }

    BOOKING_STATUSE {
        string bookingStatus PK
        string bookingStatusDescription
    }

    FAVORITE_FLIGHT {
        int userID FK
        int flightID FK
    }

    USER ||--o{ BOOKING : "makes"
    BOOKING_STATUSE ||--o{ BOOKING : "of"
    FLIGHT_STATUSE ||--o{ FLIGHT : "of"
    USER ||--o{ FAVORITE_FLIGHT : "has"
    USERLOGIN ||--|| USER : "has"
    AIRLINE ||--o{ FLIGHT : "operates"
    FLIGHT ||--o{ BOOKING : "is booked in"
    FLIGHT ||--o{ FAVORITE_FLIGHT : "is favorited in"
```
