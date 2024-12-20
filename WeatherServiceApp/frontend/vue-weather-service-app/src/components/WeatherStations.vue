<template>
  <div class="weather-stations">
    <h2>Select a Weather Station</h2>
    <select v-model="selectedStation" @change="fetchWeatherData">
      <option disabled value="">-- Select a Station --</option>
      <option
        v-for="(station, index) in stations"
        :key="index"
        :value="station.id"
      >
        {{ station.name }}
      </option>
    </select>

    <div v-if="error" class="error">{{ error }}</div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "WeatherStations",
  data() {
    return {
      selectedStation: "",
      stations: [
        { id: "31572", name: "Akrafjall" },
        { id: "3471", name: "Akureyri" },
        { id: "31363", name: "Reykjanesbraut" },
        { id: "1475", name: "Reykjavik" },
        { id: "6015", name: "Vestmannaeyjar" },
      ],
      error: null,
    };
  },
  methods: {
    async fetchWeatherData() {
      if (!this.selectedStation) {
        this.error = "Please select a valid weather station.";
        return;
      }

      this.error = null;
      try {
        const response = await axios.get(
          `http://localhost:5000/Weather/ByStation?stationId=${this.selectedStation}`
        );

        this.$emit("data-fetched", response.data); // Emit data to the parent
      } catch (err) {
        this.error = "Failed to fetch weather data. Please try again.";
      }
    },
  },
};
</script>

<style scoped>
.weather-stations {
  max-width: 400px;
  text-align: center;
  min-height: 150px;
}
select {
  width: 100%;
  padding: 8px;
}
.error {
  color: red;
  margin-top: 10px;
}
</style>
