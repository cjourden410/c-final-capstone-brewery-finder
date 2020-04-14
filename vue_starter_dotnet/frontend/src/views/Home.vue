<template>
  <div class="base">
    <div class="home">
      <h1>Home</h1>
      <div class="text">
        Welcome {{user.sub}}, to the best craft beer website on the net. Your current role on ths site is {{user.rol}}.
        Please enjoy searching for breweries and their beers. Feel free to rate and leave comments on beers you might have tried inn the past.
        Thank you for your patronage.
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
  font-weight: bolder;
  background-color: whitesmoke;
  border-radius: 35%;
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  padding: 20px;
  padding-bottom: 50px;
  text-align: center;
  height: auto; 
  overflow-y:auto;  
  padding: 50px;
  background-image: url("../assets/te.png");
  background-size: cover;
  font-weight: bold;
 
}
.text{
  font-size: 16pt;
}
.base {
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  position: fixed;
  top: 1;
  left: 0;
  background-attachment: fixed;
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/2.jpg");
  overflow-y:auto;
}
</style>
