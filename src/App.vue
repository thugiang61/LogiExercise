<template>
  <div id="app">
    <h1>Quiz Time!!!</h1>
    <img alt="Vue logo" src="./assets/logo.png" />
    <div v-for="questionData in myJson" :key="questionData.id">
      <Question :questionData="questionData" />
    </div>
  </div>
</template>

<script>
import Question from "./components/Question.vue";
import MY_JSON from "@/questions.json";

export default {
  data: function () {
    return {
      myJson: MY_JSON,
    };
  },
  name: "App",
  components: {
    Question,
  },
  //custom option named myJson, ko nên đưa vào data
  // myJson: MY_JSON,
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  /* margin-top: 60px; */
  padding: 10%;
  padding-top: 0;
  background-color: lightblue;
}

h1 {
  font-size: 150px;
}
</style>
