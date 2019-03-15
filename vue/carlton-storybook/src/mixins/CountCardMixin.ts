// mixin.js
import { Vue, Component, Prop, Mixins } from "vue-property-decorator";

@Component
export default class CountCardMixin extends Vue {
  @Prop() count!: number;

  //Data
  accentColor!: string;
  messageTemplate!: string;

  // computed
  get computedMsg(): string {
    return `${this.count} ${this.messageTemplate}`;
  }
}
