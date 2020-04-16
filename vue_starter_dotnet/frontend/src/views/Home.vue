<template>
  <div class="base">
    <div class="home mx-auto">
      <h1>Home</h1>
      <div class="text">
        Welcome {{user.sub}}, to the best craft beer website on the net. Your current role on this site is {{user.rol}}.
        Please enjoy searching for breweries and their beers. Feel free to rate and leave comments on beers you might have tried in the past.
        Thank you for your patronage.
      </div>
      <div>
        <img class="te" src="../assets/te.png" />
      </div>
    </div>
  </div>
</template>

<script>
import auth from "../auth";

export default {
  name: "home",
  data() {
    return {
      user: null
    };
  },
  methods: {},
  created() {
    this.user = auth.getUser();
  }
};
</script>

<style scoped>
.home {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
  min-height: 500px;
}
.base {
    background-image: url("../assets/4.jpg");
  align-items: center;
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  /* position: fixed; */
  top: 1;
  left: 0;
  /* background-attachment: fixed; */
  min-width: 100%;
  min-height: 100%;
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
.te{
  width: 30%;
  padding-top: 10px;
}
.text{
  font-size: 16pt;
}
</style>
