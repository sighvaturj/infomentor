<template>
  <div class="weather-input">
    <h2>Enter Weather Text IDs</h2>
    <input
      type="text"
      v-model="stationIds"
      placeholder="Enter Text IDs with a semicolon between e.g., 5;6"
      @keyup="validateIds"
      @keyup.enter="onEnter"
    />
    <button @click="fetchWeatherData" :disabled="isButtonDisabled">Fetch Weather</button>

    <div v-if="error" class="error">
      {{ error }}
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "WeatherInput",
  data() {
    return {
      stationIds: "",
      error: null,
    };
  },
  computed: {
    isButtonDisabled() {
      // Disable button if input is empty or if there is a validation error
      return !this.stationIds.trim() || this.error !== null;
    },
  },
  methods: {
    validateIds() {
      // Clear error if input is empty
      if (!this.stationIds.trim()) {
        this.error = null;
        return;
      }

      // Validate each ID in the input
      const ids = this.stationIds.split(";").map((id) => id.trim());
      const invalidIds = ids.filter((id) => isNaN(id) || id < 2 || id > 10);

      if (invalidIds.length > 0) {
        this.error = "Valid IDs are 2 to 10 - a semicolon between";
      } else {
        this.error = null; // Clear error if all IDs are valid
      }
    },
    async fetchWeatherData() {
      this.validateIds(); // Re-validate before fetching
      if (this.error || !this.stationIds.trim()) return; // Stop if validation fails or input is empty

      try {
        const response = await axios.get(
          `http://localhost:5000/Weather?ids=${encodeURIComponent(this.stationIds)}`
        );
        this.$emit("data-fetched", response.data); // Emit data to the parent
        this.error = null; // Clear error after successful fetch
      } catch (err) {
        this.error = "Failed to fetch weather data. Please try again.";
      }
    },
    onEnter() {
      // Trigger fetchWeatherData only if the button is not disabled
      if (!this.isButtonDisabled) {
        this.fetchWeatherData();
      }
    },
  },
};
</script>

<style scoped>
.weather-input {
  max-width: 400px;
  text-align: center;
  min-height: 150px;
}
input {
  width: 100%;
  padding: 8px;
  margin-bottom: 10px;
}
button {
  padding: 10px 20px;
  background-color: #007bff;
  color: white;
  border: none;
  cursor: pointer;
}
button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}
.error {
  color: red;
  margin-top: 10px;
}
</style>
