<template>
  <div id="app">
    <div id="nav">
      <div class="navibar" v-if="user">
        Logged in
        <div class="navibar">
          <button v-on:click="logout">Logout</button>
        </div>
      </div>
      <div v-else>
        <div class="navibar">
          <router-link :to="{name: 'login'}">Login</router-link>
        </div>
        <div class="navibar">
          <router-link :to="{name: 'register'}">Register</router-link>
        </div>
      </div>
      <router-link class="navibar" to="/">Home</router-link>
      <router-link class="navibar" to="/BreweryList">Brewery List</router-link>
      <router-link class="navibar" to="/Breweryadd">Add a new Brewery</router-link>
    </div>
    <router-view />
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  data() {
    return {
      user: null,
    };
  },
  methods: {
    logout() {
      auth.logout();
      this.$router.push('/login');
      this.user = null;
    },
  },
  created() {
    this.user = auth.getUser();
  },
  watch: {
    $route: function() {
      this.user = auth.getUser();
    }
  }
};
</script>
<style>
.navibar{
  display: inline-block;
  background-color: whitesmoke;
  padding: 5px;;
  height: 50px;
  
}
</style>