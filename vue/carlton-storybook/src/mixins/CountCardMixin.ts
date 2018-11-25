// mixin.js
import { Vue, Component, Prop, Mixins } from "vue-property-decorator";

// You can declare a mixin as the same style as components.
@Component
export default class CountCardMixin extends Vue {
  @Prop() count!: number;
  @Prop() messageTempalte!: string;

  //Data
  accentColor: string = "";

  // computed
  get computedMsg(): string {
    return `${this.count} ${this.messageTemplate}`;

  }
}
