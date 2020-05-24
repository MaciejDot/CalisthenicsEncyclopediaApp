<template>
  <b-modal v-model="modalIsVisible" hide-footer hide-header size="sm">
    <b-container>
      <div class="title">Calisthenics Encyclopedia</div>
      <b-form-group>
        <div class="sub-title">Beta</div>
      </b-form-group>
      <b-form>
        <b-form-group>
          <b-form-input
            placeholder="Email"
            type="email"
            v-model="email"
            autocomplete="on"
          />
        </b-form-group>
        <b-form-group>
          <b-form-input
            autocomplete="on"
            placeholder="Password"
            type="password"
            v-model="password"
          />
        </b-form-group>
        <b-form-group>
          <b-overlay :show="loggingIn">
            <white-button @click="logIn">
              <b>LOG IN</b>
            </white-button>
          </b-overlay>
        </b-form-group>
      </b-form>
    </b-container>
  </b-modal>
</template>
<script lang="ts">
import Vue from "vue";
import { BModal, BFormInput, BFormGroup, BOverlay, BForm } from "bootstrap-vue";
import WhiteButton from "./common/WhiteButton.vue";

export default Vue.extend({
  data() {
    return {
      email: "",
      password: "",
      profileModuleActions: this.$store.direct.dispatch.profileModule,
      loggingIn: false,
      modalIsVisible: false
    };
  },
  components: { BModal, BFormInput, BFormGroup, WhiteButton, BOverlay, BForm },
  props: {
    value: Boolean
  },
  model: {
    prop: "value",
    event: "input"
  },
  watch: {
    value(val: boolean) {
      this.modalIsVisible = val;
    },
    modalIsVisible(val: boolean) {
      this.$emit("input", val);
    }
  },
  created() {
    this.modalIsVisible = this.value;
  },
  methods: {
    logIn() {
      this.loggingIn = true;
      this.profileModuleActions
        .login({
          email: this.email,
          password: this.password
        })
        .then(() =>
          this.profileModuleActions.accountInfo().then(() => {
            this.modalIsVisible = false;
            this.$emit("log-in");
          })
        )
        .finally(() => (this.loggingIn = false));
    }
  }
});
</script>
<style scoped>
.title {
  text-align: center;
  color: black;
  font-size: 28px;
  padding-top: 24px;
  letter-spacing: 0.5px;
}
.sub-title {
  text-align: center;
  color: black;
  font-size: 15px;
  padding-top: 7px;
  letter-spacing: 3px;
  text-transform: uppercase;
  font-weight: bold;
}
</style>
