# Store Game API
- [Store Game](#store-game-api)
    - [Game](#list)
      - [List](#list)
         - [Response](#list-response)
      - [Search Name](#game-search)
        - [Request](#search-request)
        - [Response](#search-response)
      - [Id](#game-id)
        - [Request](#id-request)
        - [Response](#id-response)
      - [Filter](#filter)
        - [Request](#filter-request)
        - [Response](#filter-response)


## Game

### List
```js
GET {{host}}/api/Game/list
```

#### List Response
```json	
  200 ok
```
```json
{
  "isSuccess": true,
  "data": [
    {
      "id": 1,
      "title": "S.T.A.L.K.E.R.: Shadow of Chernobyl\n",
      "description": "S.T.A.L.K.E.R.: Shadow of Chernobyl tells a story about survival in the Zone – a very dangerous place, where you fear not only the radiation, anomalies and deadly creatures, but other S.T.A.L.K.E.R.s, who have their own goals and wishes.\n",
      "releaseDate": "2007-03-20",
      "price": 2450,
      "stock": 10,
      "imagen": "STALKER_Shadow_of_Chernobly.jpg",
      "developerName": "GSC Game World",
      "platformName": "Windows",
      "website": "https://store.steampowered.com/app/4500/STALKER_Shadow_of_Chernobyl/"
    },
    {
      "id": 2,
      "title": "S.T.A.L.K.E.R.: Call of Pripyat\n",
      "description": "S.T.A.L.K.E.R.: Call of Pripyat is the direct sequel of the S.T.A.L.K.E.R.: Shadow of Chernobyl. As a Major Alexander Degtyarev you should investigate the crash of the governmental helicopters around the Zone and find out, what happened there.\n",
      "releaseDate": "2010-02-11",
      "price": 1400,
      "stock": 15,
      "imagen": "STALKER_Call_of_Pripyat.jpg",
      "developerName": "GSC Game World",
      "platformName": "Windows",
      "website": "https://store.steampowered.com/app/4500/STALKER_Shadow_of_Chernobyl/"
    }
  ],
  "message": "Juegos encontrados"
}
```

- - -

### Search
```js
GET {{host}}/api/Game/search
```

#### Search Request
```js
GET {{host}}/api/Game/search?query={{query}}
```

#### Search Response
```js
200 ok
```

```json
{
  "isSuccess": true,
  "data": [
    {
      "id": 4,
      "title": "METAL GEAR SOLID V: THE PHANTOM PAIN",
      "description": "Ushering in a new era for the METAL GEAR franchise with cutting-edge technology powered by the Fox Engine, METAL GEAR SOLID V: The Phantom Pain, will provide players a first-rate gaming experience as they are offered tactical freedom to carry out open-world missions.",
      "releaseDate": "2015-09-01",
      "price": 1000,
      "stock": 150,
      "imagen": "METAL_GEAR SOLID_V_THE_PHANTOM_PAIN.jpg",
      "developerName": "KONAMI",
      "platformName": "Windows",
      "website": "https://store.steampowered.com/app/287700/METAL_GEAR_SOLID_V_THE_PHANTOM_PAIN/"
    }
  ],
  "message": "Juegos encontrados"
}
```

- - -

### Id
```js
GET {{host}}/api/Game/search/
```

#### Id Request
```js
GET {{host}}/api/Game/search/{{id}}
```

#### Id Response
```js
200 ok
```

```json
{
  "isSuccess": true,
  "data": {
    "id": 1,
    "title": "S.T.A.L.K.E.R.: Shadow of Chernobyl\n",
    "description": "S.T.A.L.K.E.R.: Shadow of Chernobyl tells a story about survival in the Zone – a very dangerous place, where you fear not only the radiation, anomalies and deadly creatures, but other S.T.A.L.K.E.R.s, who have their own goals and wishes.\n",
    "releaseDate": "2007-03-20",
    "price": 2450,
    "stock": 10,
    "imagen": "STALKER_Shadow_of_Chernobly.jpg",
    "developerName": "GSC Game World",
    "platformName": "Windows",
    "website": "https://store.steampowered.com/app/4500/STALKER_Shadow_of_Chernobyl/"
  },
  "message": "Juego encontrado"
}
```

- - -

### Filter
```js
GET {{host}}/api/Game/filter
```

#### Filter Request
```js
POST {{host}}/api/Game/filter
```

```json
{
  "order": "string",
  "search": "string",
  "title": "string",
  "realeaseDateBefore": "2023-09-07T17:32:58.594Z",
  "realeaseDateAfter": "2023-09-07T17:32:58.594Z",
  "priceMin": 0,
  "priceMax": 0,
  "developerName": "string",
  "platformName": "string",
  "records": true
}
```

#### Filter Response
```js
200 ok
```

```json
{
  "isSuccess": true,
  "data": [
    {
      "id": 4,
      "title": "METAL GEAR SOLID V: THE PHANTOM PAIN",
      "description": "Ushering in a new era for the METAL GEAR franchise with cutting-edge technology powered by the Fox Engine, METAL GEAR SOLID V: The Phantom Pain, will provide players a first-rate gaming experience as they are offered tactical freedom to carry out open-world missions.",
      "releaseDate": "2015-09-01",
      "price": 1000,
      "stock": 150,
      "imagen": "METAL_GEAR SOLID_V_THE_PHANTOM_PAIN.jpg",
      "developerName": "KONAMI",
      "platformName": "Windows",
      "website": "https://store.steampowered.com/app/287700/METAL_GEAR_SOLID_V_THE_PHANTOM_PAIN/"
    }
  ],
  "message": "Juegos encontrados"
}
```