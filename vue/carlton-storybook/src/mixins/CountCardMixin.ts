// mixin.js
import { Vue, Component, Prop, Mixins } from "vue-property-decorator";

@Component
export default class CountCardMixin extends Vue {
  @Prop() count!: number;
  @Prop() messageTemplate!: string;

  //Data
  accentColor: string = "";

  // computed
  get computedMsg(): string {
    return `${this.count} ${this.messageTemplate}`;

  }
}
