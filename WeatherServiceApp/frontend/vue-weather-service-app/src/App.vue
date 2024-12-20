<template>
  <div id="app">
    <header>
      <h1>Weather Forecast App</h1>
    </header>
    <main class="container">
      <section class="left-panel">
        <WeatherInput @data-fetched="handleInputDataFetched" />
        <WeatherData v-if="weatherData.length" :weatherData="weatherData" />
      </section>
      <section class="right-panel">
        <WeatherStations @data-fetched="handleStationDataFetched" />
        <WeatherStationData v-if="stationData.length" :forecastData="stationData" />
      </section>
    </main>
  </div>
</template>

<script>
import WeatherStations from "./components/WeatherStations.vue";
import WeatherInput from "./components/WeatherInput.vue";
import WeatherData from "./components/WeatherData.vue";
import WeatherStationData from "./components/WeatherStationData.vue";

export default {
  name: "App",
  components: {
    WeatherStations,
    WeatherInput,
    WeatherData,
    WeatherStationData,
  },
  data() {
    return {
      weatherData: [], // General weather data
      stationData: [], // Weather data for a specific station
    };
  },
  methods: {
    handleInputDataFetched(data) {
      this.weatherData = data; // Update general weather data
    },
    handleStationDataFetched(data) {
      this.stationData = data; // Update specific station forecast data
    },
  },
};
</script>

<style scoped>
#app {
  font-family: Arial, sans-serif;
  text-align: center;
  color: #333;
  display: flex;
  flex-direction: column;
  width: 100%;
  margin: 0 auto;
}

header {
  background-color: #007bff;
  color: white;
  padding: 20px;
  text-align: center;
  position: sticky;
  top: 0;
  z-index: 1000;
  width: 100%;
  box-sizing: border-box;
}

.container {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  width: 100%;
  padding: 20px;
  box-sizing: border-box;
  gap: 20px;
}

.left-panel,
.right-panel {
  flex: 1; 
  padding: 20px;
  border: 1px solid #ddd;
  border-radius: 8px;
  background-color: #f9f9f9;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  min-width: 400px; 
  max-width: 700px; 
  box-sizing: border-box;
}

.left-panel {
  background-color: #fdfdfd;
}

.right-panel {
  background-color: #f7faff;
}

/* Responsive adjustments for smaller screens */
@media (max-width: 1024px) {
  .container {
    flex-direction: column; 
    gap: 10px;
  }

  .left-panel,
  .right-panel {
    flex: none;
    width: 100%;
  }
}
</style>


