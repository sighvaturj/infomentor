<template>
    <div class="weather-station-data" v-if="forecastData && forecastData.length">
      <h2>Weather Forecast for Selected Station</h2>
      <ul>
        <li v-for="(forecast, index) in forecastData" :key="index">
          <p><strong>Time:</strong> {{ forecast.time }}</p>
          <p><strong>Wind Speed:</strong> {{ forecast.windSpeed }} m/s</p>
          <p><strong>Wind Direction:</strong> {{ forecast.windDirection }}</p>
          <p><strong>Temperature:</strong> {{ forecast.temperature }}°C</p>
          <p><strong>Condition:</strong> {{ forecast.weather }}</p>
          <hr />
        </li>
      </ul>
    </div>
    <div v-else>
      <p>No forecast data available. Please select a station to see the forecast.</p>
    </div>
  </template>
  
  <script>
  export default {
    name: "WeatherStationData",
    props: {
      forecastData: {
        type: Array,
        required: true,
      },
    },
  };
  </script>
  
  <style scoped>
  .weather-station-data {
    margin-top: 20px;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 8px;
    background-color: #f9f9f9;
  }
  ul {
    list-style-type: none;
    padding: 0;
  }
  li {
    margin-bottom: 20px;
  }
  hr {
    border: 0;
    height: 1px;
    background: #ddd;
    margin: 10px 0;
  }
  </style>
  