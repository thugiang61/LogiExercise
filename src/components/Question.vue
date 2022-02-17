<template>
  <b-message
    :title="questionData.id + '.' + questionData.question"
    :closable="false"
    id="b-message"
  >
    <!-- {{ questionData.id }}. {{ questionData.question }} -->
    <div v-for="answer in questionData.answers" :key="answer">
      <input
        type="radio"
        :disabled="isDisabled"
        @click="answerClicked(answer, questionData.rightAnswer)"
      />
      {{ answer }}
    </div>

    <p v-show="wrongMsgShown" class="wrongMsg">
      Tiếc quá, '{{ questionData.rightAnswer }}' mới đúng nha =((
    </p>

    <p v-show="rightMsgShown" class="rightMsg">Đúng rồi, bạn giỏi quá :33</p>
  </b-message>
</template>

<script>
export default {
  data: function () {
    return {
      isDisabled: false,
      wrongMsgShown: false,
      rightMsgShown: false,
    };
  },
  props: {
    questionData: Object,
  },
  methods: {
    answerClicked(answer, rightAnswer) {
      // disable right after the answer is chosen
      this.isDisabled = true;
      if (answer === rightAnswer) {
        this.rightMsgShown = true;
      } else this.wrongMsgShown = true;
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#b-message {
  margin-bottom: 20px;
}

.wrongMsg {
  color: red;
}

.rightMsg {
  color: teal;
}
</style>
