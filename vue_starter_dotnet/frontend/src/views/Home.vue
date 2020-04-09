<template>
<div class="base">
  <div class="home">
    <h1>Home</h1>
    <div>Welcome {{user.sub}}, {{user.rol}}</div>
  </div>
  <!-- <img src="../assets/2.jpg" /> -->
</div>
</template>

<script>
import auth from '../auth';

export default {
  name: 'home',
  data() {
    return{
      user: null
    }
  },
  methods: {

  },
  created() {
    this.user = auth.getUser();
  }
}
</script>

<style scoped>
.home {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
img{
  display: block;
  margin: auto;
  width:50%;
  border-radius: 50%;
}
.base{
  height: 600px;
  background-image: url('../assets/2.jpg');
}
</style>
