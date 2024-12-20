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
git clone https://github.com/sighvaturj/WeatherServiceApp.git
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
   The backend will be available in Swagger `http://localhost:5000/index.html`.

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
   The frontend will be available at `http://localhost:5173`.

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

## Running Tests

### Backend Tests

Navigate to the `backend` folder and run:

```bash
dotnet test
```

### Frontend Tests

Navigate to the `frontend/vue-weather-service-app` folder and run:

```bash
npx cypress open
```

#### Cypress Example Test

This Cypress test checks the dropdown menu for the correct weather station names:

```typescript
describe("Weather Stations Dropdown", () => {
  beforeEach(() => {
    cy.visit("/");
  });

  it("should display the correct station names and values in the dropdown", () => {
    const dropdownSelector = ".weather-stations select";

    const expectedNames = [
      "-- Select a Station --",
      "Akrafjall",
      "Akureyri",
      "Reykjanesbraut",
      "Reykjavik",
      "Vestmannaeyjar",
    ];

    const expectedIds = [
      "", // Placeholder option
      "31572",
      "3471",
      "31363",
      "1475",
      "6015",
    ];

    cy.get(dropdownSelector)
      .find("option")
      .then((options) => {
        const actualNames = [...options].map((option) => option.text.trim());
        expect(actualNames).to.deep.equal(expectedNames);
      });

    cy.get(dropdownSelector)
      .find("option")
      .then((options) => {
        const actualValues = [...options].map((option) => option.value.trim());
        expect(actualValues).to.deep.equal(expectedIds);
      });
  });

  it("should allow the user to select a weather station", () => {
    cy.get(".weather-stations select")
      .select("Akrafjall") // Select by visible text
      .should("have.value", "31572"); // Ensure the value is correct
  });
});
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
- [ ] Create a GitHub repo for the project, upload.
- [ ] Send an email to Infomentor with a link to GitHub and a ZIP file of the source code.

---

## Excluded Files and Folders

To keep the repository size small, the following files and folders are excluded using `.gitignore`:

```plaintext
# Node modules
node_modules/

# Build output
dist/
bin/
obj/

# Logs
*.log

# Environment files
.env
.env.local
appsettings.Development.json

# Cypress files
cypress/screenshots/
cypress/videos/

# Other
.DS_Store
```

---

## License

This project is licensed under the [MIT License](LICENSE).

---
