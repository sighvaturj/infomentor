<template>
    <div class="weather-data">
      <h2>Weather Data</h2>
      <ul>
        <li v-for="(item, index) in weatherData" :key="index" class="weather-item">
          <h3>{{ item.title }}</h3>
          <p><strong>ID:</strong> {{ item.id }}</p>
          <p><strong>Creation:</strong> {{ item.creation }}</p>
          <p><strong>Valid From:</strong> {{ item.validFrom }}</p>
          <p><strong>Valid To:</strong> {{ item.validTo }}</p>
          <p><strong>Content:</strong> {{ item.content }}</p>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    name: "WeatherData",
    props: {
      weatherData: {
        type: Array,
        required: true,
      },
    },
  };
  </script>
  
  <style scoped>
  .weather-data {
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

  .weather-item {
    margin-bottom: 20px;
    padding: 10px;
    border-bottom: 1px solid #ddd;
  }
  
  .weather-item:last-child {
    border-bottom: none;
  }
  
  h3 {
    margin-bottom: 10px;
  }
  </style>
  