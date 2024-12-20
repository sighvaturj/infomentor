# WeatherServiceApp - InfoMentor assignment

A demo project with a **.NET backend** and a **Vue frontend** for fetching and displaying weather data from the Icelandic national weather forecast service.

## Author

[Sighvatur Jónsson](https://github.com/sighvaturj/infomentor)

## Date

19 December 2024

## Folder Structure

```
WeatherServiceApp
├── backend
│   ├── Program.cs
│   ├── Startup.cs
│   └── src
│       ├── WeatherController.cs
│       └── WeatherService.cs
└── frontend
    └── vue-weather-service-app
        └── src
            ├── App.vue
            └── components
```

## Prerequisites

- **Backend**: [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- **Frontend**: [Node.js 18+](https://nodejs.org) and [npm](https://www.npmjs.com/)
- **Git**: [Git](https://git-scm.com/)

---

## How to Run the Project

### 1. Clone the Repository

```bash
git clone https://github.com/sighvaturj/infomentor.git
cd WeatherServiceApp
```

---

### 2. Running the .NET Backend

1. Navigate to the `backend` folder:

   ```bash
   cd backend
   ```

2. Restore the dependencies:

   ```bash
   dotnet restore
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the backend server:
   ```bash
   dotnet run
   ```
   The backend will be available in Swagger at: `http://localhost:5000/index.html`(http://localhost:5000/index.html).

---

### 3. Running the Vue Frontend

1. Navigate to the Vue app folder:

   ```bash
   cd frontend/vue-weather-service-app
   ```

2. Install the dependencies:

   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm run dev
   ```
   The frontend will be available at: `http://localhost:5173`(http://localhost:5173).

---

### 4. Running Tests

1. Backend Tests

Navigate to the `WeatherServiceApp/WeatherServiceApp.Tests` folder and run:

```bash
dotnet test
```

2. Frontend Tests

Navigate to the `frontend/vue-weather-service-app` folder and run:

```bash
npx cypress open
```

---

## Project Features

### Backend (.NET)

- A REST API to fetch weather data:
  - **`GET /Weather`**: Fetch general weather forecasts.
  - **`GET /Weather/ByStation`**: Fetch weather forecasts for specific weather stations.

### Frontend (Vue)

- A user interface to:
  - Enter weather station IDs to fetch weather forecasts.
  - Select weather stations from a dropdown menu for predefined stations.

---

## Example API Endpoints

1. **Fetch Weather by IDs**:

   ```bash
   curl "http://localhost:5000/Weather?ids=5;6"
   ```

2. **Fetch Weather by Station**:
   ```bash
   curl "http://localhost:5000/Weather/ByStation?ids=6015"
   ```

---

## Task List for the Project

- [x] Create a PROJECT.md with the description of the assignment.
- [x] Create a README.md for an overview of the project.
- [x] Create a .NET backend to get the weather data from the API.
- [x] Creata a Vue frontend, display data, dropdown for weather stations.
- [x] Add backend tests in xUnit.
- [x] Add frontend tests in Cypress.
- [x] Update documentation in README.
- [x] Create a GitHub repo for the project, upload.
- [x] Send an email to Infomentor with a link to the GitHub repo.

---
