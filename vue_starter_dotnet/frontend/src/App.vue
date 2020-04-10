<template>
  <div id="app">
    <div id="nav">
      <div v-if="user">
        Logged in
        
          <button v-on:click="logout">Logout</button>
        
      </div>
      <div v-else>
        <div >
          <router-link tag="button" :to="{name: 'login'}" >Login</router-link>
          <router-link tag="button" :to="{name: 'register'}">Register</router-link>
        </div>
       
      </div>
      <router-link tag="button" class="navibar" :to="{name: 'home'}">Home</router-link>
      <router-link tag="button" class="navibar" :to="{name: 'breweryList'}">Brewery List</router-link>
      <router-link v-if="user && (user.rol === 'Admin')" tag="button" class="navibar" :to="{name: 'breweryAdd'}">Add a new Brewery</router-link>
      <router-link v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')" tag="button" class="navibar" :to="{name: 'accountUpdate'}">Update Account</router-link>
      <router-link v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')" tag="button" class="navibar" :to="{name: 'breweryInfoUpdate'}">Update Brewery</router-link>
      <router-link v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')" tag="button" class="navibar" :to="{name: 'beerAdd'}">Add a Beer</router-link>
      <router-link v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')" tag="button" class="navibar" :to="{name: 'viewRatings'}">View Ratings</router-link>
      <router-link v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')" tag="button" class="navibar" :to="{name: 'deleteBeer'}">Delete Beer</router-link>
    </div>
    <router-view v-bind:user="this.user" />
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

<style scoped>
.navibar{
  display: inline-block;
  background-color: whitesmoke;
  padding: 5px;;
  height: 30px;
  
}
</style>