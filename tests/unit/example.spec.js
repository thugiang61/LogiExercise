import { shallowMount } from "@vue/test-utils";
import Question from "@/components/Question.vue";

describe("UTC Question Component", () => {
  it("UT001: Test when right answer is chosen", async () => {
    const wrapper = shallowMount(Question, {
      propsData: {
        questionData: {
          id: 1,
          question: "Khi gặp Thúy Kiều , Kim Trọng trao cho vật gì làm tin?",
          answers: [
            "Dải yếm",
            "Miếng Lụa",
            "Chiếc châm cài tóc",
            "Chiếc khăn hồng",
          ],
          rightAnswer: "Chiếc khăn hồng",
        },
      },
    });
    const rightAnswer = wrapper.findAll("input").at(3);
    await rightAnswer.trigger("click");
    expect(wrapper.find("span").text()).toEqual("Đúng rồi, bạn giỏi quá :33");
  });

  it("UT002: Test when wrong answer is chosen", async () => {
    const wrapper = shallowMount(Question, {
      propsData: {
        questionData: {
          id: 1,
          question: "Khi gặp Thúy Kiều , Kim Trọng trao cho vật gì làm tin?",
          answers: [
            "Dải yếm",
            "Miếng Lụa",
            "Chiếc châm cài tóc",
            "Chiếc khăn hồng",
          ],
          rightAnswer: "Chiếc khăn hồng",
        },
      },
    });
    const wrongAnswer = wrapper.findAll("input").at(1);
    await wrongAnswer.trigger("click");
    expect(wrapper.find("span").text()).toEqual(
      "Tiếc quá, 'Chiếc khăn hồng' mới đúng nha =(("
    );
  });
});
